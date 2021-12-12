using System;

namespace Events
{
    public class BankAccount
    {
        public event EventHandler < OverdrawnEventArgs> Overdrawn;

        public decimal Balance { get; set; }
        
        public void Credit(decimal amount)
        {
            Balance += amount;
            
        }
        public void Debit(decimal amount)
        {
            if(Balance >= amount)
            {
            Balance -= amount;
            }
            else
            {
                if (Overdrawn != null) 
                {
                    Overdrawn(this, new OverdrawnEventArgs (Balance, amount));

                }

            }

        }
    }
}