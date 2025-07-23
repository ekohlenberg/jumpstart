using System;
using System.IO;
using System.Threading.Tasks;
using jumpstart;

namespace jumpstart {


    class Program
    {
        static async Task Main(string[] args)
        {

            
            string modelPath = "./test.csv";
            string templDefName = string.Empty;

            try
            {

                if (args.Length == 2)
                {
                    modelPath = args[0];

                    if (!File.Exists(modelPath))
                    {
                    Console.WriteLine($"Error: File not found at path {modelPath}");

                    return;
                    }

                    templDefName = args[1];


                }
                else 
                {
                    throw new Exception("Usage: jumpstart <model.csv> <template-definition>");
                }


                Console.WriteLine($"Using model path {modelPath} with template definition {templDefName}.");
           
                // infer the namespace based on the model filename
                string _namespace = Path.GetFileNameWithoutExtension(modelPath);
                var metaModel = new MetaModel(_namespace);

                // Create an instance of the CSVLoader
                var csvLoader = new CSVLoader();

                // Load the model from the specified path
                csvLoader.Load(modelPath, metaModel);

                // Load the core functionality in common to all apps
                CoreLoader coreLoader = new CoreLoader();
                coreLoader.Load("core.csv", metaModel );

                // Add the standard columns to each object
                GlobalCSVLoader gloader = new GlobalCSVLoader();
                gloader.Load( "global.csv", metaModel);

                // Instantiate the code generator
                Generator g = new Generator(metaModel);

                // Load the template definition
                g.AddTemplates( TemplateDefLoader.Load( templDefName) ) ;

                // go!
                await g.Generate();

                
            }
            catch (Exception ex)
            {
                
                Exception x = ex;
                while(x != null)
                {
                    Console.WriteLine($"Error: {x.Message}\n{x.StackTrace}");

                    x = x.InnerException;
                }
            }

                return;
        }
    }
}
