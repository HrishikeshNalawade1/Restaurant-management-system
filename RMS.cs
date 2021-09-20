using System;
using Dal;
namespace Rsystem
{
    class RMS
    {
        static void Main(string[] args)
        {
            Rmethods c = new Rmethods();
            start:
            Console.WriteLine("Press 1 to see all Restaurant in Rsystem");
            Console.WriteLine("Press 2 to Search Restaurant in Rsystem");
            Console.WriteLine("Press 3 to Add new Restaurant in Rsystem");
            Console.WriteLine("Press 4 to make changes in Existing Restaurant in Rsystem");
            Console.WriteLine("Press 5 to Delete Restaurant in Rsystem");
            Console.WriteLine("Press 6 to see List of Active Restaurant in Rsystem");
            Console.WriteLine("Enter your choice");
            int condition = Convert.ToInt32(Console.ReadLine());
            switch(condition)
            {

                case 1:
                    c.DisplayRestaurant();
                    break;
                case 2:
                    c.SearchRestaurant();
                    break;
                case 3:
                    c.AddNewRestaurant();
                    c.DisplayRestaurant();
                    break;
                case 4:
                    c.EditRestaurant();
                    c.DisplayRestaurant();
                    break;
                case 5:
                    c.DeleteRestaurant();
                    c.DisplayRestaurant();
                    break;
                case 6:
                    c.ShowActive();
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
            Console.WriteLine("Press 1 to continue\n Press 2 to Exit");
            int op = Convert.ToInt32(Console.ReadLine());
            if(op==1)
            {
                goto start;
            }
            else
            {
                Console.WriteLine("Thank you ");
            }
        }
    }
}
