using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pizzastore
{
    public class Menucatalog
    {
        List<Pizza> _pizzas;

        public Menucatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }

        public void Printmenu()
        {
            foreach (var p in _pizzas)
            {
                Console.WriteLine(p);
                Console.WriteLine("______________________________");
            }
        }
        public Pizza Read(int number)
        {
            foreach (Pizza p in _pizzas)
            {

                if (p.ID==number)
                {
                    return p;
                }

            }
            return null;
        }

        public Pizza SearchPizza(string Criteria)
        {
            foreach (var p in _pizzas)
            {
                if (p.Name == Criteria)
                    return p;
            }
            return null;

        }
        public void Update(Pizza pizza)
        {
            foreach (var p in _pizzas)
            {
                if (p.ID == pizza.ID)
                {
                    p.Name = pizza.Name;
                    p.Price = pizza.Price;
                    return;
                }
            }
        }
        public void Delete(Pizza pizza)
        {

            foreach (var p in _pizzas)
            {
                if (p.ID == pizza.ID)
                {
                    pizza = p;
                    break;
                }

            }
            _pizzas.Remove(pizza);
        }
        

    }

}