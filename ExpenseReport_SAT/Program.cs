using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport_SAT
{
    class Program
    {
        enum review
        {
            approved = 3, rejected = 1, escalated = 2
        };

        //Same as writing: enum review {ZERO, rejected, escalated, approved};

        static void Main(string[] args)
        {
            //1st Level Manager - any expense up to 250 WONT approve entertainment
            //2nd Level Manager - any exp up to 500 WONT towncars
            //Director - any exp up to 1000 WONT Hardware>5000
            //CEO - anything

            double cost = 0;
            string item = "";


            Console.WriteLine("What is the item you wish to expense?");
            item = Console.ReadLine();

            Console.WriteLine("What is the cost of the item you wish to expense?");
            cost = Double.Parse(Console.ReadLine());

            firstLevel(cost, item);
            Console.ReadLine();

        }
        public static void firstLevel(double c, string i)
        {
            int choice = 0;

            if (i.Contains("entertainment"))
            {
                choice = (int)review.rejected;
            }
            else if (c > 250)
            {
                Console.WriteLine("Manager 1: Enter 1 to reject or 2 to escalate");
                choice = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Manager 1: Enter 1 to reject, 2 to escalate, or 3 to approve");
                choice = int.Parse(Console.ReadLine());
            }

            if (choice == (int)review.escalated)
            {
                Console.WriteLine("Escalating to the second level manager");
                secondLevel(c, i);
            }
            else
            {
                decisionMade(choice);
            }
        }


        public static void secondLevel(double c, string i)
        {
            int choice = 0;

            if (i.Contains("towncars"))
            {
                choice = (int)review.rejected;
            }
            else if (c > 500)
            {
                Console.WriteLine("Manager 2: Enter 1 to reject or 2 to escalate");
                choice = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Manager 2: Enter 1 to reject, 2 to escalate, or 3 to approve");
                choice = int.Parse(Console.ReadLine());
            }

            if (choice == (int)review.escalated)
            {
                Console.WriteLine("Escalating to the director");
                director(c, i);
            }
            else
            {
                decisionMade(choice);
            }
        }


        public static void director(double c, string i)
        {
            int choice = 0;

            if (i.Contains("hardware") && c > 5000)
            {
                choice = (int)review.rejected;
            }
            else if (c > 1000)
            {
                Console.WriteLine("Director: Enter 1 to reject or 2 to escalate");
                choice = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Manager 1: Enter 1 to reject, 2 to escalate, or 3 to approve");
                choice = int.Parse(Console.ReadLine());
            }

            if (choice == (int)review.escalated)
            {
                Console.WriteLine("Escalating to the CEO");
                cEOLevel(c, i);
            }
            else
            {
                decisionMade(choice);
            }
        }


        public static void cEOLevel(double c, string i)
        {
            int choice = 0;
            Console.WriteLine("Enter 1 to reject or 3 to approve");

            choice = int.Parse(Console.ReadLine());

            decisionMade(choice);

        }

        public static void decisionMade(int choice)
        {

            switch (choice)
            {
                case (int)review.approved:
                    {
                        Console.WriteLine("Expense is approved");
                        break;
                    }
                case (int)review.rejected:
                    {
                        Console.WriteLine("Expense is rejected");
                        break;
                    }
                default:
                    break;
            }
        }

    }
}
