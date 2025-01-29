
using System;


namespace legr3
{
    public interface IScriptLogic
    {  
        // Generated methods
        List<Script> select();
        Script get(long id);
        void insert(Script script);
        void update(long id, Script script);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScriptLogic
    {
        public ScriptLogic()
        {
           
        }
        
    }
}

