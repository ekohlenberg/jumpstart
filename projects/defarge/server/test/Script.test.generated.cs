using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScriptTest : BaseTest
    {
        public static void testInsert()
        {
            var script = new Script();


                    script.name = Convert.ToString(BaseTest.getTestData(script, "VARCHAR", TestDataType.random));
                    
                    script.source = Convert.ToString(BaseTest.getTestData(script, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing ScriptLogic insert: " + script.ToString());
                ScriptLogic.Create().insert(script);
                BaseTest.addLastId("script", script.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Script");
            var script = ScriptLogic.Create().get(lastId);


                        script.name = (string) BaseTest.getTestData(script, "VARCHAR", TestDataType.random);
                    
                        script.source = (string) BaseTest.getTestData(script, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ScriptLogic update: " + script.ToString());
                ScriptLogic.Create().update(lastId, script);
                    }
    }
}
