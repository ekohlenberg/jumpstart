using System;
using Microsoft.AspNetCore.Mvc;
using RazorLight;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Threading.Tasks;


namespace legr3
{
	public class ScriptHost 
	{

		private readonly RazorLightEngine razorEngine;

		public ScriptHost()
		{
			razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(BaseObject))
                .SetOperatingAssembly(typeof(BaseObject).Assembly)
                .UseMemoryCachingProvider()
                .Build();
		}

		public async void Invoke()
		{
			string script = "@using System; @{ Console.WriteLine(\"hello from script\"); }";

			await ExecCode<BaseObject>(new BaseObject(), script);

		}

		protected async Task ExecCode<T>(T model, string script) where T : BaseObject
        {
            if (model == null)
            {
                throw new Exception("Model is null.");
            }

            if (string.IsNullOrEmpty(script))
            {
                throw new Exception($"Script content is null or empty.");
            }

            string generatedCode = await razorEngine.CompileRenderStringAsync<T>("hello-world", script, model );

        }

	}

}