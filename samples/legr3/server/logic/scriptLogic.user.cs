
using System;


namespace 
{
    public interface IScriptLogic
    {
        List<Script> select();
        Script get(long id);
        void insert(Script script);
        void update(long id, Script script);
        void delete( long id );
    }


    public partial class ScriptLogic
    {
        public ScriptLogic()
        {
           
        }
        
    }
}

