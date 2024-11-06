using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class VendorLogic : Logic
    {
    
        public static List<Vendor> select()
        {
            Console.WriteLine("Processing VendorLogic select List" );

            List<Vendor> vendors = [];

            void vendorCallback(System.Data.Common.DbDataReader rdr) 
            {
                Vendor vendor = [];

                DBPersist.autoAssign(rdr, vendor);

                vendors.Add(vendor);
            };

            DBPersist.select(vendorCallback, "select * from app.vendor");

            return vendors;
        }

        
        public static Vendor get(long id)
        {
            Console.WriteLine("Processing VendorLogic get ID=" + id.ToString());

            Vendor vendor = [];
            vendor.id = id;

            DBPersist.get(vendor);

            return vendor;
        }

        
        public static void insert( Vendor vendor)
        {
            Console.WriteLine("Processing VendorLogic insert: " + vendor.ToString()  );

            vendor.is_active = "Y";

            DBPersist.insert(vendor);
        }

       
        public static void update(long id,  Vendor vendor)
        {
            Console.WriteLine("Processing VendorLogic update: ID = " + id.ToString() + "\n" + vendor.ToString()  );

            vendor.id = id;
            DBPersist.update(vendor);
        }

        
        public static void delete(long id)
        {
            Vendor vendor = get(id);
            vendor.is_active = "N";
             DBPersist.update(vendor);
        }
    }
}
