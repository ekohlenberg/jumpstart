
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class VendorLogic : BaseLogic, IVendorLogic
    {


        public static IVendorLogic Create()
        {

            var vendor = new VendorLogic();


            var proxy = DispatchProxy.Create<IVendorLogic, Proxy<IVendorLogic>>();
            ((Proxy<IVendorLogic>)proxy).Initialize();
            ((Proxy<IVendorLogic>)proxy).Target = vendor;
           // ((Proxy<IVendorLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
           // ((Proxy<IVendorLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }



        public  List<Vendor> select()
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

        public  Vendor get(long id)
        {
            Console.WriteLine($"Processing VendorLogic get ID={id}");

            Vendor vendor = new Vendor();
            vendor.id = id;

            DBPersist.get(vendor);

            return vendor;
        }

        public  void insert(Vendor vendor)
        {
            Console.WriteLine($"Processing VendorLogic insert: {vendor}");

            vendor.is_active = 1;

            DBPersist.insert(vendor);
        }

        public  void update(long id, Vendor vendor)
        {
            Console.WriteLine($"Processing VendorLogic update: ID = {id}\n{vendor}");

            vendor.id = id;
            DBPersist.update(vendor);
        }

        public  void delete(long id)
        {
            Vendor vendor = get(id);
            vendor.is_active = 0;
            DBPersist.update(vendor);
        }
    }
}
