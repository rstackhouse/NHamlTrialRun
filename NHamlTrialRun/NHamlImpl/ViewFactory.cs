using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHaml;
using NHaml.TemplateResolution;
using NHamlTrialRun.Model;

namespace NHamlTrialRun.NHamlImpl
{
    public class ViewFactory
    {
        private TemplateOptions GetOptions() //rstackhouse: wondering about the sanity of creating multiple options classes
        {
            var templateOptions = new TemplateOptions();
            templateOptions.EncodeHtml = false;
            templateOptions.AutoRecompile = true; //TODO: figure out what this does
            templateOptions.IndentSize = 2;
            templateOptions.AddReferences(typeof(Task));

            //class providing content to the engine, should implement ITemplateContentProvider
            var fileTemplateResolver = new FileTemplateContentProvider();
            fileTemplateResolver.PathSources = new[] { GetBaseTemplatePath() }.ToList();

            templateOptions.AddUsing("NHamlTrialRun.Helpers");

            templateOptions.TemplateContentProvider = fileTemplateResolver;

            return templateOptions;
        }

        private string GetBaseTemplatePath()
        {
            return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\", "Views");
        }

        private TemplateEngine GetEngine(Type t)
        {
            var options = GetOptions();
            options.TemplateBaseType = t;
            return new TemplateEngine(options);
        }

        public NHamlView<T> Create<T>(string viewName)
        {
            var engine = GetEngine(typeof(NHamlView<T>));
            return (NHamlView<T>)GetCompiledTemplate(engine, viewName).CreateInstance();
        }

        public NHamlLayout CreateLayout(string layoutName)
        {
            var engine = GetEngine(typeof(NHamlLayout));
            return (NHamlLayout)GetCompiledTemplate(engine, layoutName).CreateInstance();
        }

        private CompiledTemplate GetCompiledTemplate(TemplateEngine engine, string templateName)
        {
            return  engine.Compile(templateName + ".haml");
        }
    }
}
