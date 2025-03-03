
using System;


namespace legr3
{
    public interface ITransactionLogic
    {  
        // Generated methods
        List<Transaction> select();
        Transaction get(long id);
        void insert(Transaction transaction);
        void update(long id, Transaction transaction);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class TransactionLogic
    {
        public TransactionLogic()
        {
           
        }
        
    }
}

