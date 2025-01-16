
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class TransactionLogic : BaseLogic, ITransactionLogic
    {


        public static ITransactionLogic Create()
        {

            var transaction = new TransactionLogic();


            var proxy = DispatchProxy.Create<ITransactionLogic, Proxy<ITransactionLogic>>();
            ((Proxy<ITransactionLogic>)proxy).Initialize();
            ((Proxy<ITransactionLogic>)proxy).Target = transaction;
           // ((Proxy<ITransactionLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
           // ((Proxy<ITransactionLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }



        public  List<Transaction> select()
        {
            Console.WriteLine("Processing TransactionLogic select List");

            List<Transaction> transactions = new List<Transaction>();

            void transactionCallback(System.Data.Common.DbDataReader rdr)
            {
                Transaction transaction = new Transaction();

                DBPersist.autoAssign(rdr, transaction);

                transactions.Add(transaction);
            };

            DBPersist.select(transactionCallback, $"select * from app.transaction");

            return transactions;
        }

        public  Transaction get(long id)
        {
            Console.WriteLine($"Processing TransactionLogic get ID={id}");

            Transaction transaction = new Transaction();
            transaction.id = id;

            DBPersist.get(transaction);

            return transaction;
        }

        public  void insert(Transaction transaction)
        {
            Console.WriteLine($"Processing TransactionLogic insert: {transaction}");

            transaction.is_active = 1;

            DBPersist.insert(transaction);
        }

        public  void update(long id, Transaction transaction)
        {
            Console.WriteLine($"Processing TransactionLogic update: ID = {id}\n{transaction}");

            transaction.id = id;
            DBPersist.update(transaction);
        }

        public  void delete(long id)
        {
            Transaction transaction = get(id);
            transaction.is_active = 0;
            DBPersist.update(transaction);
        }
    }
}
