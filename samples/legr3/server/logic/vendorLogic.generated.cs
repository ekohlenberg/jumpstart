
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class VendorLogic : BaseLogic
    {
        public static List<Vendor> select()
        {
            Console.WriteLine("Processing VendorLogic select List");

            List<Vendor> vendors = new List<Vendor>();

            void vendorCallback(System.Data.Common.DbDataReader rdr)
            {
                Vendor vendor = new Vendor();

                DBPersist.autoAssign(rdr, vendor);

                vendors.Add(vendor);
            };

            DBPersist.select(vendorCallback, $"select * from app.vendor");

            return vendors;
        }

        public static Vendor get(long id)
        {
            Console.WriteLine($"Processing VendorLogic get ID={id}");

            Vendor vendor = new Vendor();
            vendor.id = id;

            DBPersist.get(vendor);

            return vendor;
        }

        public static void insert(Vendor vendor)
        {
            Console.WriteLine($"Processing VendorLogic insert: {vendor}");

            vendor.is_active = 1;

            DBPersist.insert(vendor);
        }

        public static void update(long id, Vendor vendor)
        {
            Console.WriteLine($"Processing VendorLogic update: ID = {id}\n{vendor}");

            vendor.id = id;
            DBPersist.update(vendor);
        }

        public static void delete(long id)
        {
            Vendor vendor = get(id);
            vendor.is_active = 0;
            DBPersist.update(vendor);
        }
    }
}