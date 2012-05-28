using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NHamlTrialRun.Helpers
{
    public class Html
    {
        public class v5
        {
            public static string time(DateTime dt)
            {
                return new XElement("time", 
                    new XAttribute("datetime", dt.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz")), dt.ToString("yyyy-MM-dd"))
                    .ToString();
            }
        }
    }
}
