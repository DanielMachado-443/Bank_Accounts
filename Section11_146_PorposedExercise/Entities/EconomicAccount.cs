using System.Text;
using Section11_146_PorposedExercise.Entities.Enums;
using Section11_146_PorposedExercise.Entities.Exception;

namespace Section11_146_PorposedExercise.Entities
{
    class Economic : Account
    {        
        public Economic()
        {
            ID = 0;
            Holder = "None";
            Balance = 100.00;
            WithdrawLimit = 250.00;
            Status = (AccountTypes)2;
        }

        public Economic(int id, string holder) // Main constructor
        {
            ID = id;
            Holder = holder;
            Balance = 100.00;
            WithdrawLimit = 250.00;
            Status = (AccountTypes)2;
        }

        public Economic(int id, string holder, double initialDeposit, double specialLimit) // Main constructor
        {
            ID = id;
            Holder = holder;
            Balance = 100.00 + initialDeposit;
            WithdrawLimit = 250.00 + specialLimit;
            Status = (AccountTypes)2;        
        }

        public Economic(int id, string holder, double balance, double withdrawLimit, double initialDeposit, double specialLimit) // COMPLETE OBJECT INSTANCIATION        
        {
            ID = id;
            Holder = holder;
            Balance = balance + initialDeposit;
            WithdrawLimit = withdrawLimit + specialLimit;
            Status = (AccountTypes)2;
        }

        public override void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new DomainExceptions("Sorry, you can not make a null deposit and its value must be positive! ");
            }
            else
            {
                Balance += amount;
            }
        }

        public override void Withdraw(double amount)
        {
            if (Balance <= 0 || Balance < amount)
            {
                throw new DomainExceptions("Sorry, you cannot do a withdraw while its value is bigger than your current account BALANCE or lesser than the amount you required!");
            }
            else if (amount > WithdrawLimit)
            {
                throw new DomainExceptions("Sorry, you cannot do a withdraw while its value is bigger than your WITHDRAW LIMIT!");
            }
            else
            {
                Balance -= amount;
            }
        }

        public override string UserInfo()
        {
            StringBuilder s1 = new StringBuilder();
            s1.Append("\n   USER INFO ");
            s1.Append("\n   Name: " + Holder);
            s1.Append("\n   ID Number: " + ID);
            s1.Append("\n   Balance: $" + Balance.ToString("F2"));
            s1.Append("\n   Withdraw limit: $" + WithdrawLimit.ToString("F2"));
            return s1.ToString();
        }
    }
}