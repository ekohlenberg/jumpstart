using System;


namespace jumpstart
{
    public class TemplateDef
    {
        public TemplateDef( string templateType, string templateFile, string outputFolder, string  force)
        {
            setType( templateType );
            setForce( force );
            this.templateFile = templateFile;
            this.outputFolder = outputFolder;
            
        }

        protected void setType( string templateType )
        {
            switch (templateType)
            {
                case "model":
                    this.templateType = typeof(MetaModel);
                    break;
                case "schema":
                    this.templateType = typeof(MetaSchema);
                    break;
                case "object":
                    this.templateType = typeof(MetaObject);
                    break;
                case "build":
                    this.templateType = typeof(MetaBuild);
                    break;
                default:
                    throw new Exception($"Invalid type {templateType}");

            }
        }

        protected void setForce( string force )
        {
            switch (force)
            {
                case "true":
                    this.force = true;
                    break;
                case "false":
                    this.force = false;
                    break;
                default:
                    throw new Exception($"Force is {force}. Value must be true or false.");                    
            }
        }
        public Type templateType {get; set;}
        public string templateFile {get;set;}
        public string outputFolder {get;set;}
        public bool force {get;set;}
    }
}