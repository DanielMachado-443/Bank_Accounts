using System.Text;
using Section11_146_PorposedExercise.Entities.Enums;
using Section11_146_PorposedExercise.Entities.Exception;

namespace Section11_146_PorposedExercise.Entities
{
    class DefaultAccount : Account
    {
        public DefaultAccount() : base()
        {            
        }

        public DefaultAccount(int id, string holder) // Main constructor
            : base(id, holder)
        {            
        }

        public DefaultAccount(int id, string holder, double initialDeposit, double specialLimit) // Main constructor
        {
            ID = id;
            Holder = holder;
            Balance += initialDeposit;      // Balance property here INHERIT the super class VOID constructor VALUE
            WithdrawLimit += specialLimit;  // WithdrawLimit property here INHERIT the super class VOID constructor VALUE
            Status = (AccountTypes)0;
        }
                        
        public DefaultAccount(int id, string holder, double balance, double withdrawLimit, double initialDeposit, double specialLimit) // COMPLETE OBJECT INSTANCIATION        
        {
            ID = id;
            Holder = holder;
            Balance = balance + initialDeposit;
            WithdrawLimit = withdrawLimit + specialLimit;
            Status = (AccountTypes)0;
        }       

        public override void Deposit(double amount)
        {
            if(amount <= 0)
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
            if(Balance <= 0 || Balance < amount)
            {
                throw new DomainExceptions("Sorry, you cannot do a withdraw while its value is bigger than your current account BALANCE or lesser than the amount you required!");
            }
            else if(amount > WithdrawLimit)
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
