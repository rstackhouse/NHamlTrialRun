using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHaml;
using NHamlTrialRun.Model;
using NHamlTrialRun.NHamlImpl;
using NHamlViewFactory = NHamlTrialRun.NHamlImpl.ViewFactory;

namespace NHamlTrialRun
{
    class Program
    {
        static Random _random = new Random();

        static void Main(string[] args)
        {
            Console.Out.WriteLine(RenderNHamlView());
            Console.In.ReadLine();
        }

        static Task CreateTask()
        {
            return new Task
            {
                Start = new DateTime(2012, 5, 24, 14, 0, 0),
                End = new DateTime(2012, 5, 25, 8, 15, 0),
                Name = "NHaml trial run",
                PercentComplete = _random.Next(101)
            };
        }

        static string RenderNHamlView()
        {
            var viewFactory = new NHamlViewFactory();
            NHamlLayout layout = viewFactory.CreateLayout("layout");
            NHamlView<Project> view = viewFactory.Create<Project>("Project");
            view.Model = CreateProject();
            layout.Content = view;
            return layout.Render();
        }

        static Project CreateProject()
        {
            var project = new Project();
            project.AddTasks(CreateTasks());
            return project;
        }

        private static IEnumerable<Task> CreateTasks()
        {
            List<Task> tasks = new List<Task>();

            for (var i = 0; i < 10; i++) tasks.Add(CreateTask());

            return tasks;
        }
    }
}
