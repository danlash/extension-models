using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionModels.Core
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        void Save(T model);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        public T FindById(int id)
        {
            var person = new Person("Dan Lash", April.Fifth(1984));
            person.AddAddress("4972 Wilcox, Holt, MI 48842");
            person.AddAddress("897 N Highland Ave NE, APT BT2, Atlanta, GA 30306");
            
            return person as T;
        }

        public void Save(T model)
        {
        }
    }

    public static class April
    {
        public static DateTime Fifth(int year) { return new DateTime(year, 4, 5); }
    }
}