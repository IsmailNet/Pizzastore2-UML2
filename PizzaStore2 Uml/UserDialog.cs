using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Pizzastore
{
    public class UserDialog
    {
        Menucatalog _menucatalog;
        public UserDialog(Menucatalog menucatalog)
        {
            _menucatalog = menucatalog;
        }
        Pizza PrintPizza()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("|    Pizza menu   | ");
            Console.WriteLine("--------------------");
            _menucatalog.Printmenu();
            return null;
        }
        Pizza DeletePizza()
        {
            Pizza pizzaitem2 = new Pizza();
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("|   Delete pizza  | ");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            _menucatalog.Printmenu();
            Console.Write("enter pizza number: ");


            string input = "";

            try
            {
                input = Console.ReadLine();
                pizzaitem2.ID = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"unable to parse {input} - message: {e.Message}");
                throw;
            }
            return pizzaitem2;
        }
        Pizza UpdatePizza()
        {
            Pizza pizzaitem1 = new Pizza();
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Updating pizza  | ");
            Console.WriteLine("--------------------");
            Console.WriteLine("enter new pizza name: ");
            pizzaitem1.Name = Console.ReadLine();

            string input = "";
            Console.Write("enter new price: ");
            try
            {
                input = Console.ReadLine();
                pizzaitem1.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"unable to parse {input} - message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("enter new pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaitem1.ID = Int32.Parse(input);
            }

            catch (FormatException e)
            {
                Console.WriteLine($"unable to parse {input} - message {e.Message}");
                throw;
            }
            return pizzaitem1;
        }

        Pizza Getnewpizza()
        {
            Pizza pizzaitem = new Pizza();
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Creating pizza  | ");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.Write("enter pizza name: ");
            pizzaitem.Name = Console.ReadLine();

            string input = "";
            Console.Write("enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaitem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"unable to parse {input} - message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("enter pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaitem.ID = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"unable to parse {input} - message {e.Message}");
                throw;
            }
            return pizzaitem;
        }
        int MainMenuChoice(List<string> menuitems)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Ismail Pizzamenu |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("options:");
            foreach (string choice in menuitems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine($"unable to parse {input}");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainmenulist = new List<string>()
            {
                "0.quit",
                "1.Create new pizza",
                "2.print menu",
                "3.Update pizza",
                "4.Delete pizza",
                "5. Search pizza"
            };

            while (proceed)
            {
                int menuchoice = MainMenuChoice(mainmenulist);
                Console.WriteLine();
                switch (menuchoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = Getnewpizza();
                            _menucatalog.Create(pizza);
                            Console.WriteLine($"you created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No pizza created");
                        }
                        Console.Write("hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        PrintPizza();
                        Console.Write("hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                       
                        try
                        {
                            Pizza pizza1 = UpdatePizza();
                            _menucatalog.Update(pizza1);
                            Console.WriteLine($"you have updated: {pizza1}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("no pizza to update");
                        }
                        Console.Write("hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 4:
                        try
                        {
                            Pizza pizza = DeletePizza();
                            _menucatalog.Delete(pizza);
                            Console.WriteLine($"you have deleted: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("no pizza to delete");
                        }
                        Console.Write("hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Pleasse choose wich pizza to search for by writing name");
                        _menucatalog.Printmenu();

                        string nametosearch = Console.ReadLine();
                        Pizza SearchedPizza = _menucatalog.SearchPizza(nametosearch);
                        Console.WriteLine($"{SearchedPizza}");
                        break;
                    default:
                        Console.Write("hit any key to continue");
                        Console.ReadKey();
                        break;




                }
            }
        }
    }
}