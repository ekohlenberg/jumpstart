using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace jumpstart {

public enum TemplateType {
            domainobject,
            application,
            schema,
            build
        }

    public class TemplateDef
    {
        public string type {get;set;}
        public string templateFile {get;set;}
        public string outputFolder {get;set;}
        public bool force {get;set;}
    }


    public class Generator
    {   
        
        private readonly RazorLightEngine razorEngine;
        
        private Dictionary<string, List<string>> outputFolderMap = new();
        private Dictionary<TemplateType, List<TemplateDef>> templates = new();

    

        public Generator()
        {
            razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Generator))
                .SetOperatingAssembly(typeof(Generator).Assembly)
                .UseMemoryCachingProvider()
                .Build();
        }

        public void AddTemplate(TemplateType templateType, TemplateDef templateDef)
        {
            if (!templates.ContainsKey(templateType))
            {
                templates[templateType] = new List<TemplateDef>();
            }
            templates[templateType].Add(templateDef);
        }

        

        private void AddToOutputFolderMap(string outputFolder, string outputFile)
        {
            if (!outputFolderMap.ContainsKey(outputFolder))
            {
                outputFolderMap[outputFolder] = new List<string>();
            }
            outputFolderMap[outputFolder].Add(Path.GetFileName(outputFile));
        }


        public async Task GenerateObjects( MetaModel metaModel )
        {
            foreach (MetaObject metaObject in metaModel.Objects.Values)
            {
                

                await GenTemplates( metaObject, TemplateType.domainobject);
            }
            
        }

        public async Task  GenerateSchemas( MetaModel metaModel )
        {
            foreach (MetaSchema metaSchema in metaModel.Schemas.Values)
            {
    
                await GenTemplates( metaSchema, TemplateType.schema);
            }
            
        }

        public async Task GenerateApp( MetaModel metaModel)
        {
            MetaModel model = metaModel;

            await GenTemplates( model, TemplateType.application);
        }

        protected async Task GenTemplates( MetaBaseElement model, TemplateType templateType )
        {
            List<TemplateDef> schemaTemplates =  templates[templateType];
            foreach( TemplateDef td in schemaTemplates)
            {
                await GenCode   ( model, td);
            }
        }

        protected async Task GenCode(MetaBaseElement model, TemplateDef td)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", td.templateFile);

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template not found: {templatePath}");
            }

            string template = File.ReadAllText(templatePath);

            string generatedCode = await razorEngine.CompileRenderAsync(td.templateFile, model);

            if (generatedCode.Length > 0)
            {

                string targetFile = td.templateFile.Replace("template", model.Name).Replace(".cshtml", "");
                string outputPath = Path.Combine(td.outputFolder, targetFile);

                if (!Directory.Exists(td.outputFolder))
                {
                    Directory.CreateDirectory(td.outputFolder);
                }

                if (!File.Exists(outputPath) || td.force)
                {
                    File.WriteAllText(outputPath, generatedCode);
                }

                AddToOutputFolderMap(td.outputFolder, outputPath);
            }
        }

    }
}