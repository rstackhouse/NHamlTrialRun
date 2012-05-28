using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHamlTrialRun.Model
{
    public class Task
    {
        public DateTime Start {get;set;}
        public DateTime End {get;set;}
        public TimeSpan Duration { get { return End - Start; } }
        public string Name { get; set; }
        public Double PercentComplete { get; set; }
    }
}
