
using System;


namespace legr3
{
    public interface IOrgLogic
    {
        List<Org> select();
        Org get(long id);
        void insert(Org org);
        void update(long id, Org org);
        void delete( long id );
    }


    public partial class OrgLogic
    {
        public OrgLogic()
        {
           
        }
        
    }
}

