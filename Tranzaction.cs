using System;

namespace EconomicApplication
{
    public class Transaction
    {
        // Private fields
        private string _transactionId;
        private DateTime _date;
        private double _amount;

        // Public properties for transactionId, date, and amount
        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        // Constructor
        public Transaction(string transactionId, DateTime date, double amount)
        {
            _transactionId = transactionId;
            _date = date;
            _amount = amount;
        }

        // Method to display transaction details
        public string GetTransactionDetails()
        {
            return "Transaction ID: " + TransactionId + ", Date: " + Date.ToShortDateString() + ", Amount: " + Amount.ToString("C");
        }
    }
}