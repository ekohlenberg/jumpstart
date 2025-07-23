using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ServerTest : BaseTest
    {
        public static void testInsert()
        {
            var server = new Server();


                    server.name = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                    
                    server.type = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                    
                    server.address = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                    
                    server.port = Convert.ToInt32(BaseTest.getTestData(server, "INTEGER", TestDataType.random));
                    
                    server.is_default = Convert.ToInt32(BaseTest.getTestData(server, "INTEGER", TestDataType.random));
                    
                Console.WriteLine("Testing ServerLogic insert: " + server.ToString());
                ServerLogic.Create().insert(server);
                BaseTest.addLastId("server", server.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Server");
            var server = ServerLogic.Create().get(lastId);


                        server.name = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.type = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.address = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.port = (int) BaseTest.getTestData(server, "INTEGER", TestDataType.random);
                    
                        server.is_default = (int) BaseTest.getTestData(server, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing ServerLogic update: " + server.ToString());
                ServerLogic.Create().update(lastId, server);
                    }
    }
}
