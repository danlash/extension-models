using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtensionModels.Core;

namespace ExtensionModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClock _clock;

        public HomeController()
        {
            _clock = new Clock();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var view = View();
            
            view.ViewData["CurrentDate"] = _clock.Current;
            view.ViewData["MinimumDate"] = _clock.Current.Subtract(122.Years()); //http://en.wikipedia.org/wiki/Oldest_people
            view.ViewData["MaximumDate"] = _clock.Current;

            return view;
        }

        [HttpPost]
        public ActionResult CalculateAge(string Name, DateTime DateOfBirth)
        {
            var person = new Person(Name, DateOfBirth);
            var age = person.CalculateAge(_clock);

            var view = PartialView();
            view.ViewData["Age"] = age;

            return view;
        }

        [HttpPost]
        public ActionResult AddAddress(int personId, string address)
        {
            var repository = new Repository<Person>();
            var person = repository.FindById(personId);
            
            person.AddAddress(address);

            repository.Save(person);

            var view = PartialView();
            view.ViewData["person"] = person;

            return view;
        }
    }

    public static class DateExtensions
    {
        public static TimeSpan Years(this int years)
        {
            return TimeSpan.FromDays(365 * years);
        }
    }
}
