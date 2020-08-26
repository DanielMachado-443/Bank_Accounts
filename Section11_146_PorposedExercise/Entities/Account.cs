using Section11_146_PorposedExercise.Entities.Enums;

namespace Section11_146_PorposedExercise.Entities
{
    abstract class Account
    {
        public int ID { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }
        public AccountTypes Status { get; set; }

        public Account()
        {
            ID = 0;
            Holder = "None";
            Balance = 1000.00;
            WithdrawLimit = 500.00;
            Status = (AccountTypes)0;
        }

        public Account(int id, string holder)
        {
            ID = id;
            Holder = holder;
            Balance = 1000.00;
            WithdrawLimit = 500.00;
            Status = (AccountTypes)0;
        }

        public Account(int id, string holder, AccountTypes status)
        {
            ID = id;
            Holder = holder;
            Balance = 1000.00;
            WithdrawLimit = 500.00;
            Status = status;
        }

        public Account(int id, string holder, double initialDeposit, double specialLimit)
        {
            ID = id;
            Holder = holder;
            Balance = 1000 + initialDeposit;
            WithdrawLimit = 500.00 + specialLimit;
            Status = (AccountTypes)0;
        }

        public Account(int id, string holder, double initialDeposit, double specialLimit, AccountTypes status)
        {
            ID = id;
            Holder = holder;
            Balance = 1000 + initialDeposit;
            WithdrawLimit = 500.00 + specialLimit;
            Status = status;
        }            

        public Account(int id, string holder, double balance, double withdrawLimit, double initialDeposit, double specialLimit, AccountTypes status)
        {
            ID = id;
            Holder = holder;
            Balance = balance + initialDeposit;
            WithdrawLimit = withdrawLimit + specialLimit;
            Status = status;
        }

        public abstract void Deposit(double amount);       // IT WAS NECESSARY TO PUT THE ARGUMENT TYPE IN THE METHOD

        public abstract void Withdraw(double amount);        

        public abstract string UserInfo();    

    }
}
