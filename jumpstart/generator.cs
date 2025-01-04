using Microsoft.AspNetCore.Mvc;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Threading.Tasks;

namespace jumpstart {


    public class TemplateDef
    {
        public TemplateDef( string templateFile, string outputFolder, bool force)
        {
            this.templateFile = templateFile;
            this.outputFolder = outputFolder;
            this.force = force;
        }
        public string templateFile {get;set;}
        public string outputFolder {get;set;}
        public bool force {get;set;}
    }


    public class Generator
    {   
        
        private readonly RazorLightEngine razorEngine;
        
    
        private Dictionary<Type, List<TemplateDef>> templates = new();

        public delegate void FileWrittenEventHandler(string outputFolder, string outputFile);
        
        public event FileWrittenEventHandler OnFileWriteEvent;

        protected virtual void FireFileWriteEvent(string outputFolder, string outputFile)
        {
            OnFileWriteEvent?.Invoke(outputFolder, outputFile);
        }
        public Generator()
        {
            
            razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(MetaObject))
                .SetOperatingAssembly(typeof(MetaObject).Assembly)
                .UseMemoryCachingProvider()
                .Build();
        }

        public void AddTemplate(Type templateType, TemplateDef templateDef)
        {
            if (!templates.ContainsKey(templateType))
            {
                templates[templateType] = new List<TemplateDef>();
            }
            templates[templateType].Add(templateDef);
        }

        

       public async Task GenerateApp( MetaModel metaModel )
        {
            await GenTemplates<MetaModel>(metaModel);
            
        }


        public async Task  GenerateSchemas( MetaModel metaModel )
        {
            foreach (MetaSchema metaSchema in metaModel.Schemas.Values)
            {
                await GenTemplates<MetaSchema>( metaSchema);
            }
            
        }        

        public async Task GenerateObjects( MetaModel metaModel )
        {
            foreach (MetaObject metaObject in metaModel.Objects)
            {
                await GenTemplates<MetaObject>(metaObject);
            }
            
        }


        public async Task GenerateBuild( MetaModel metaModel )
        {
            List<TemplateDef> templateList =  templates[metaModel.build.GetType()];
            foreach( TemplateDef td in templateList)
            {
                metaModel.build.SetOutputFolder( td.outputFolder );
                await GenCode<MetaBuild>( metaModel.build, td);
            }
        }
        

        protected async Task GenTemplates<T>( T model) where T : MetaBaseElement
        {
            List<TemplateDef> templateList =  templates[model.GetType()];
            foreach( TemplateDef td in templateList)
            {
                await GenCode<T>( model, td);
            }
        }

    

        protected async Task GenCode<T>(T model, TemplateDef td) where T : MetaBaseElement
        {
            if (model == null)
            {
                throw new Exception("Model is null.");
            }

            if (td == null)
            {
                throw new Exception("Template Definition is null.");
            }

            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", td.templateFile);

            Console.WriteLine("Processing template " + templatePath);

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template not found: {templatePath}");
            }

            

            string template = File.ReadAllText(templatePath);

            if (string.IsNullOrEmpty(template))
            {
                throw new Exception($"Template content is null or empty. Cannot read template {templatePath}");
            }

            string generatedCode = await razorEngine.CompileRenderStringAsync<T>(td.templateFile, template, model );

            if (generatedCode.Length > 0)
            {
                generatedCode = generatedCode.Replace("&#xD;", "\r");
                generatedCode = generatedCode.Replace("&#xA;", "\n");
                generatedCode = generatedCode.Replace("&#x9;", "\t");
                generatedCode = generatedCode.Replace("&lt;", "<");
                generatedCode = generatedCode.Replace("&gt;", ">");
              
                MetaBaseElement metaType = (MetaBaseElement) model;
                string templateFile = Path.GetFileName(td.templateFile);
                string targetFile = templateFile.Replace("template", model.Name).Replace(".cshtml", "");
                string outputPath = Path.Combine(td.outputFolder, targetFile);

                if (!Directory.Exists(td.outputFolder))
                {
                    Directory.CreateDirectory(td.outputFolder);
                }

                if (!File.Exists(outputPath) || td.force)
                {
                    File.WriteAllText(outputPath, generatedCode);
                }

                FireFileWriteEvent(td.outputFolder, outputPath);
            }
        }


        
    }
}