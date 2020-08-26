using System;
using Section11_146_PorposedExercise.Entities;
using System.Collections.Generic;
using Section11_146_PorposedExercise.Entities.Exception;

namespace Section11_146_PorposedExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            bool tFlag = true;            
            int whileCount = 0;            
            List<Account> f1Account = new List<Account>();

            while (tFlag)
            {                
                string tName = "";
                int tID = 0;

                if(whileCount < 1)
                {
                    Console.WriteLine("\n\n   Éoq of account manager program ");
                }                

                Console.Write("\n   Do you want to open your account including initial deposit AND special extra withdraw limit? (y/n) ");
                char tAnswer = char.Parse(Console.ReadLine());

                while (tAnswer != 'y' && tAnswer != 'Y' && tAnswer != 'n' && tAnswer != 'N')
                {
                    Console.Write("\n   You've entered a invalid answer. Please, try it again! ");
                    Console.Write("\n   Do you want to open your account including initial deposit AND special extra withdraw limit? (y/n) ");
                    tAnswer = char.Parse(Console.ReadLine());
                }                

                Console.WriteLine("\n   YOU SHOULD ENTER THE HOLDER INFORMATION BELOW ");

                Console.Write("\n   Holder name: ");
                tName = Console.ReadLine();

                Console.Write("\n   ID number: ");
                tID = int.Parse(Console.ReadLine());

                Console.Write("\n   Is your account default or economic? (1/2) ");
                int eAnswer = int.Parse(Console.ReadLine());

                while (eAnswer != 1 && eAnswer != 2)
                {
                    Console.Write("\n   You've entered a invalid answer. Please, try it again! ");
                    Console.Write("\n   Is your account default or economic? (1/2) ");
                    eAnswer = int.Parse(Console.ReadLine());
                }

                if (tAnswer == 'y' || tAnswer == 'Y')
                {
                    Console.Write("\n   Initial deposit: $");
                    double iDeposit = double.Parse(Console.ReadLine());

                    Console.Write("\n   Special extra withdraw limit: $");
                    double iLimit = double.Parse(Console.ReadLine());

                    if (eAnswer == 1)
                    {                        
                        f1Account.Add(new DefaultAccount(tID, tName, iDeposit, iLimit));
                    }
                    else
                    {
                        f1Account.Add(new Economic(tID, tName, iDeposit, iLimit));
                    }                    
                }
                else
                {
                    if (eAnswer == 1)
                    {
                        f1Account.Add(new DefaultAccount(tID, tName));
                    }
                    else
                    {
                        f1Account.Add(new Economic(tID, tName));
                    }                                      
                }

                // WITHDRAW OR DEPOSIT? 

                Console.Write("\n   Do you want to make a withdraw or deposit (1/2) or '3' to skip? ");
                int Answer2 = int.Parse(Console.ReadLine());

                while (Answer2 != 1 && Answer2 != 2 && Answer2 != 3)
                {
                    Console.Write("\n   You've entered a invalid answer. Please, try it again! ");
                    Console.Write("\n   Do you want to make withdraw or deposit (1/2)? ");
                    Answer2 = int.Parse(Console.ReadLine());
                }

                bool Flag2 = true; // THIS FLAG DECLARATION # HAS # TO BE LOCAL
                while (Flag2)
                {
                    try
                    {                        
                        if (Answer2 == 1)
                        {
                            Console.Write("\n   How much do you want to withdraw? $");
                            double tWithdraw = double.Parse(Console.ReadLine());
                            f1Account[f1Account.Count - 1].Withdraw(tWithdraw);
                            
                        }                        
                        else if (Answer2 == 2)
                        {
                            Console.Write("\n   How much do you want to deposit? $");
                            double tDeposit = double.Parse(Console.ReadLine());
                            f1Account[f1Account.Count - 1].Deposit(tDeposit);
                        }
                        Flag2 = false;
                        break;
                    }
                    catch (DomainExceptions e)
                    {
                        Console.WriteLine("\n   Error: " + e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n   Error: " + e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n   Error: " + e.Message);
                    }
                }

                // PRINTING OUT / EXPORTING

                List<string> Conv = new List<string>();
                foreach (Account obj in f1Account)
                {
                    Console.Write("\n   " + f1Account[f1Account.IndexOf(obj)].UserInfo());
                    Conv.Add(f1Account[f1Account.IndexOf(obj)].UserInfo());
                }

                using (System.IO.StreamWriter File = new System.IO.StreamWriter(@"G:\CS TXT Files\Section 11 Proposed Exercise\Relatory " + (whileCount + 1) + ".txt"))
                    foreach (string str in Conv)
                    {
                        File.WriteLine(str);
                    }

                // LOOP QUESTION

                Console.Write("\n\n\n   Do you want to add a new user? (y/n): ");
                char LAnswer = char.Parse(Console.ReadLine());

                while (LAnswer != 'y' && LAnswer != 'Y' && LAnswer != 'n' && LAnswer != 'N')
                {
                    Console.Write("\n   You've entered a invalid answer. Please, try it again! ");
                    Console.Write("\n   Do you want to add a new user? (y/n): ");
                    LAnswer = char.Parse(Console.ReadLine());
                }

                whileCount += 1;

                if (LAnswer == 'n' || LAnswer == 'N')
                {                    
                    tFlag = false;
                    Console.WriteLine();
                }                
            }
        }            
    }
}
