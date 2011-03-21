using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionModels.Core
{

    public interface IClock
    {
        DateTime Current { get; }
    }

    public class Clock : IClock
    {
        public DateTime Current
        {
            get { return DateTime.Now; }
        }
    }
}