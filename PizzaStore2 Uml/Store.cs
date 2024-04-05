using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pizzastore
{
    public class Store
    {
        Menucatalog menuCatalog;

        public Store()
        {
            menuCatalog = new Menucatalog();
            Test();
            Run();
        }




        public void Test()
        {
            Pizza p = new Pizza() { ID = 1, Name = "Mamamias pizza", Price = 50 };
            menuCatalog.Create(p);

            p = new Pizza() { ID = 2, Name = "magahritta", Price = 55 };
            menuCatalog.Create(p);

            p = new Pizza() { ID = 3, Name = "Andre tate", Price = 65 };
            menuCatalog.Create(p);

            p = new Pizza() { ID = 4, Name = "The Matrix", Price = 65 };
            menuCatalog.Create(p);

            menuCatalog.Printmenu();

            
        }

        public void Run()
        {
            new UserDialog(menuCatalog).Run();

        }
    }



}
