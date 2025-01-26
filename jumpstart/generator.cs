using Microsoft.AspNetCore.Mvc;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Threading.Tasks;

namespace jumpstart {


   


    public class Generator
    {   
        
        private readonly RazorLightEngine razorEngine;
        
    
        private Dictionary<Type, List<TemplateDef>> templates = new();

        public delegate void FileWrittenEventHandler(string outputFolder, string outputFile);
        
        public event FileWrittenEventHandler OnFileWriteEvent;

        protected MetaModel metaModel = null;

        protected virtual void FireFileWriteEvent(string outputFolder, string outputFile)
        {
            OnFileWriteEvent?.Invoke(outputFolder, outputFile);
        }
        public Generator(MetaModel metaModel)
        {
            
            this.metaModel = metaModel;
            OnFileWriteEvent += metaModel.build.AddToOutputFolderMap;
            metaModel.SortMetaObjectsByReference();

            razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(MetaObject))
                .SetOperatingAssembly(typeof(MetaObject).Assembly)
                .UseMemoryCachingProvider()
                .Build();
        }

        public void AddTemplates( List<TemplateDef> templateDefs )
        {
            foreach( TemplateDef td in templateDefs )
            {
                if (!templates.ContainsKey(td.templateType))
                {
                    templates[td.templateType] = new List<TemplateDef>();
                }

                templates[td.templateType].Add(td);
            }
        }

        

        public async Task Generate()
        {
            await GenerateApp();
            await GenerateSchemas();
            await GenerateObjects();
            await GenerateBuild();
        }

       public async Task GenerateApp()
        {
            await GenTemplates<MetaModel>(metaModel);
            
        }


        public async Task  GenerateSchemas()
        {

            foreach (MetaSchema metaSchema in metaModel.Schemas.Values)
            {
                await GenTemplates<MetaSchema>( metaSchema);
            }
            
        }        

        public async Task GenerateObjects()
        {
            foreach (MetaObject metaObject in metaModel.Objects)
            {
                await GenTemplates<MetaObject>(metaObject);
            }
            
        }


        public async Task GenerateBuild()
        {
            if (templates.ContainsKey(metaModel.build.GetType()))
            {
                List<TemplateDef> templateList =  templates[metaModel.build.GetType()];
                foreach( TemplateDef td in templateList)
                {
                    metaModel.build.SetOutputFolder( td.outputFolder );
                    await GenCode<MetaBuild>( metaModel.build, td);
                }
            }
        }
        

        protected async Task GenTemplates<T>( T model) where T : MetaBaseElement
        {
            if (templates.ContainsKey(model.GetType()))
                {
                List<TemplateDef> templateList =  templates[model.GetType()];
                

                foreach( TemplateDef td in templateList)
                {
                    await GenCode<T>( model, td);
                }
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

            Console.WriteLine("Processing " + td.templateFile);

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
