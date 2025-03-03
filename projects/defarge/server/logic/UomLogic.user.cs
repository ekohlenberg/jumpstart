
using System;


namespace defarge
{
    public interface IUomLogic
    {  
        // Generated methods
        List<Uom> select();
        Uom get(long id);
        void insert(Uom uom);
        void update(long id, Uom uom);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class UomLogic
    {
        public UomLogic()
        {
           
        }
        
    }
}

