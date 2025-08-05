using System;
using System.IO;
using System.Threading.Tasks;
using jumpstart;

namespace jumpstart {


    class Program
    {
        static async Task<int> Main(string[] args)
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
                        return 1; // File not found error
                    }

                    templDefName = args[1];


                }
                else 
                {
                    Console.WriteLine("Usage: jumpstart <model.csv> <template-definition>");
                    return 2; // Usage error
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

                Console.WriteLine("Code generation completed successfully.");
                return 0; // Success
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found error: {ex.Message}");
                return 1; // File not found error
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid argument error: {ex.Message}");
                return 2; // Invalid argument error
            }
            catch (Exception ex)
            {
                Exception x = ex;
                while(x != null)
                {
                    Console.WriteLine($"Error: {x.Message}");
                    if (x.StackTrace != null)
                    {
                        Console.WriteLine($"Stack trace: {x.StackTrace}");
                    }
                    x = x.InnerException;
                }
                return 3; // General error
            }
        }
    }
}
