
using System;


namespace defarge
{
    public interface IServerLogic
    {  
        // Generated methods
        List<Server> select();
        Server get(long id);
        void insert(Server server);
        void update(long id, Server server);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ServerLogic
    {
        public ServerLogic()
        {
           
        }
        
    }
}

