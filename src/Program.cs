using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using jumpstart;

namespace jumpstart {


    class Program
    {
        static async Task<int> Main(string[] args)
        {

            
            string modelPath = string.Empty;
            List<string> templDefNames = new List<string>();
            string homePath = string.Empty;
            try
            {
                if (args.Length == 2)
                {
                    // Command line arguments provided
                    modelPath = args[0];

                    if (!File.Exists(modelPath))
                    {
                        Console.WriteLine($"Error: File not found at path {modelPath}");
                        return 1; // File not found error
                    }

                    templDefNames.Add(args[1]);
                }
                else if (args.Length == 0)
                {
                    // No command line arguments - look for JSON file in user's home directory
                    homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string jsonPath = Path.Combine(homePath, ".jumpstart.json");
                    
                    if (!File.Exists(jsonPath))
                    {
                        Console.WriteLine($"Error: No command line arguments provided and JSON file '{jsonPath}' not found.");
                        Console.WriteLine("Usage: jumpstart <model.csv> <template-definition>");
                        Console.WriteLine("   OR: Create a ~/.jumpstart.json file with modelpath and templatedefs");
                        return 2; // Usage error
                    }

                    // Read and deserialize JSON file
                    string jsonContent = File.ReadAllText(jsonPath);
                    var jumpStartParams = JsonSerializer.Deserialize<JumpStartParams>(jsonContent);
                    
                    if (jumpStartParams == null)
                    {
                        Console.WriteLine($"Error: Failed to deserialize JSON file '{jsonPath}'");
                        return 2; // Usage error
                    }

                    // Expand tilde in modelpath
                    modelPath = jumpStartParams.modelpath;
                    if (modelPath.StartsWith("~/") || modelPath.StartsWith("~"))
                    {
                        if (string.IsNullOrEmpty(homePath))
                        {
                            homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        }
                        modelPath = Path.Combine(homePath, modelPath.Substring(2));
                    }

                    // Convert to absolute path if relative
                    if (!Path.IsPathRooted(modelPath))
                    {
                        modelPath = Path.GetFullPath(modelPath);
                    }

                    if (!File.Exists(modelPath))
                    {
                        Console.WriteLine($"Error: File not found at path {modelPath}");
                        return 1; // File not found error
                    }

                    templDefNames = jumpStartParams.templatedefs ?? new List<string>();
                    
                    if (templDefNames.Count == 0)
                    {
                        Console.WriteLine("Error: No template definitions specified in JSON file");
                        return 2; // Usage error
                    }
                }
                else 
                {
                    Console.WriteLine("Usage: jumpstart <model.csv> <template-definition>");
                    Console.WriteLine("   OR: Create a ~/.jumpstart.json file with modelpath and templatedefs");
                    return 2; // Usage error
                }


                Console.WriteLine($"Using model path {modelPath} with template definition(s): {string.Join(", ", templDefNames)}.");
           
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

                metaModel.Process();
                
                // Instantiate the code generator
                Generator g = new Generator(metaModel);

                // Load all template definitions
                foreach(var templDefName in templDefNames)
                {
                    g.AddTemplates( TemplateDefLoader.Load( templDefName) ) ;
                }

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
