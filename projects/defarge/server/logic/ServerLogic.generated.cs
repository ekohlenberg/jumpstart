
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ServerLogic : IServerLogic
    {


        public static IServerLogic Create()
        {
            var server = new ServerLogic();

            var proxy = DispatchProxy.Create<IServerLogic, Proxy<IServerLogic>>();
            ((Proxy<IServerLogic>)proxy).Initialize();
            ((Proxy<IServerLogic>)proxy).Target = server;
            ((Proxy<IServerLogic>)proxy).DomainObj = "Server";

            return proxy;
        }



        public  List<Server> select()
        {
            Console.WriteLine("Processing ServerLogic select List");

            List<Server> servers = new List<Server>();

            void serverCallback(System.Data.Common.DbDataReader rdr)
            {
                Server server = new Server();

                DBPersist.autoAssign(rdr, server);

                servers.Add(server);
            };

            DBPersist.select(serverCallback, $"select * from core.server");

            return servers;
        }

        public  Server get(long id)
        {
            Console.WriteLine($"Processing ServerLogic get ID={id}");

            Server server = new Server();
            server.id = id;

            DBPersist.get(server);

            return server;
        }

        public  void insert(Server server)
        {
            Console.WriteLine($"Processing ServerLogic insert: {server}");

            server.is_active = 1;

            DBPersist.insert(server);
        }

        public  void update(long id, Server server)
        {
            Console.WriteLine($"Processing ServerLogic update: ID = {id}\n{server}");

            server.id = id;
            DBPersist.update(server);
        }

        public  void delete(long id)
        {
            Server server = get(id);
            server.is_active = 0;
            DBPersist.update(server);
        }
    }
}
