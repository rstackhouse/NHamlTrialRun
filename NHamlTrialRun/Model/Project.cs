using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHamlTrialRun.Model
{
    public class Project
    {
        public List<Task> Tasks { get; private set; }

        public Project()
        {
            Tasks = new List<Task>();
        }

        public void AddTasks(IEnumerable<Task> tasks)
        {
            Tasks.AddRange(tasks);
        }
    }
}
