using System.Collections.Generic;

namespace jumpstart
{
    /// <summary>
    /// Represents the JSON configuration file structure for jumpstart code generator
    /// </summary>
    public class JumpStartParams
    {
        public string modelpath { get; set; } = string.Empty;
        public List<string> templatedefs { get; set; } = new List<string>();
    }
}

