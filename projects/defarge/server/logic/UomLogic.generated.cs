
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class UomLogic : IUomLogic
    {


        public static IUomLogic Create()
        {
            var uom = new UomLogic();

            var proxy = DispatchProxy.Create<IUomLogic, Proxy<IUomLogic>>();
            ((Proxy<IUomLogic>)proxy).Initialize();
            ((Proxy<IUomLogic>)proxy).Target = uom;
            ((Proxy<IUomLogic>)proxy).DomainObj = "Uom";

            return proxy;
        }



        public  List<Uom> select()
        {
            Console.WriteLine("Processing UomLogic select List");

            List<Uom> uoms = new List<Uom>();

            void uomCallback(System.Data.Common.DbDataReader rdr)
            {
                Uom uom = new Uom();

                DBPersist.autoAssign(rdr, uom);

                uoms.Add(uom);
            };

            DBPersist.select(uomCallback, $"select * from app.uom");

            return uoms;
        }

        public  Uom get(long id)
        {
            Console.WriteLine($"Processing UomLogic get ID={id}");

            Uom uom = new Uom();
            uom.id = id;

            DBPersist.get(uom);

            return uom;
        }

        public  void insert(Uom uom)
        {
            Console.WriteLine($"Processing UomLogic insert: {uom}");

            uom.is_active = 1;

            DBPersist.insert(uom);
        }

        public  void update(long id, Uom uom)
        {
            Console.WriteLine($"Processing UomLogic update: ID = {id}\n{uom}");

            uom.id = id;
            DBPersist.update(uom);
        }

        public  void delete(long id)
        {
            Uom uom = get(id);
            uom.is_active = 0;
            DBPersist.update(uom);
        }
    }
}
