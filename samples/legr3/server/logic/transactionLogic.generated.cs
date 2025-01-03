
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class TransactionLogic : BaseLogic
    {
        public static List<Transaction> select()
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

        public static Transaction get(long id)
        {
            Console.WriteLine($"Processing TransactionLogic get ID={id}");

            Transaction transaction = new Transaction();
            transaction.id = id;

            DBPersist.get(transaction);

            return transaction;
        }

        public static void insert(Transaction transaction)
        {
            Console.WriteLine($"Processing TransactionLogic insert: {transaction}");

            transaction.is_active = 1;

            DBPersist.insert(transaction);
        }

        public static void update(long id, Transaction transaction)
        {
            Console.WriteLine($"Processing TransactionLogic update: ID = {id}\n{transaction}");

            transaction.id = id;
            DBPersist.update(transaction);
        }

        public static void delete(long id)
        {
            Transaction transaction = get(id);
            transaction.is_active = 0;
            DBPersist.update(transaction);
        }
    }
}