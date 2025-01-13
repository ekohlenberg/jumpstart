
using System;


namespace legr3
{
    public interface ITransactionLogic
    {
        List<Transaction> select();
        Transaction get(long id);
        void insert(Transaction transaction);
        void update(long id, Transaction transaction);
        void delete( long id );
    }


    public partial class TransactionLogic
    {
        public TransactionLogic()
        {
           
        }
        
    }
}

