
using System;


namespace legr3
{
    public interface IOrgLogic
    {  
        // Generated methods
        List<Org> select();
        Org get(long id);
        void insert(Org org);
        void update(long id, Org org);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OrgLogic
    {
        public OrgLogic()
        {
           
        }
        
    }
}

