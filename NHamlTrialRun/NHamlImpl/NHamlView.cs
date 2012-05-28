using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHaml;
using System.IO;

namespace NHamlTrialRun.NHamlImpl
{
    public abstract class NHamlView : NHaml.Template
    {
        public string Render()
        {
            var text = "";
            using (var writer = new StringWriter())
            {
                base.Render(writer);
                text = writer.ToString();
            }
            return text;
        }

        public override string ToString()
        {
            return Render();
        }
    }

    public class NHamlView<T> :  NHamlView
    {
        public NHamlView()
        {
        }

        public T Model { get; set; }
    }

    public class NHamlLayout : NHamlView
    {
        public NHamlLayout()
        {
        }

        public object Content { get; set; }
    }
}
