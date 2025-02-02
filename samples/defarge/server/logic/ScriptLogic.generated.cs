
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScriptLogic : IScriptLogic
    {


        public static IScriptLogic Create()
        {
            var script = new ScriptLogic();

            var proxy = DispatchProxy.Create<IScriptLogic, Proxy<IScriptLogic>>();
            ((Proxy<IScriptLogic>)proxy).Initialize();
            ((Proxy<IScriptLogic>)proxy).Target = script;
            ((Proxy<IScriptLogic>)proxy).DomainObj = "Script";

            return proxy;
        }



        public  List<Script> select()
        {
            Console.WriteLine("Processing ScriptLogic select List");

            List<Script> scripts = new List<Script>();

            void scriptCallback(System.Data.Common.DbDataReader rdr)
            {
                Script script = new Script();

                DBPersist.autoAssign(rdr, script);

                scripts.Add(script);
            };

            DBPersist.select(scriptCallback, $"select * from core.script");

            return scripts;
        }

        public  Script get(long id)
        {
            Console.WriteLine($"Processing ScriptLogic get ID={id}");

            Script script = new Script();
            script.id = id;

            DBPersist.get(script);

            return script;
        }

        public  void insert(Script script)
        {
            Console.WriteLine($"Processing ScriptLogic insert: {script}");

            script.is_active = 1;

            DBPersist.insert(script);
        }

        public  void update(long id, Script script)
        {
            Console.WriteLine($"Processing ScriptLogic update: ID = {id}\n{script}");

            script.id = id;
            DBPersist.update(script);
        }

        public  void delete(long id)
        {
            Script script = get(id);
            script.is_active = 0;
            DBPersist.update(script);
        }
    }
}
