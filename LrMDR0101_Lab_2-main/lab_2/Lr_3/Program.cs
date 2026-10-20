using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaleHistory history = new SaleHistory();
            Receipt receipt = new Receipt();

            SaleItem firstItem = new SaleItem(
                DateTime.Now, "Хлеб", 2, 45.50);

            SaleItem secondItem = new SaleItem(
                DateTime.Now, "Молоко", 1, 89.90);

            history.AddSale(firstItem);
            history.AddSale(secondItem);

            receipt.AddItem(firstItem);
            receipt.AddItem(secondItem);

            receipt.Print();
            receipt.Save("Чек.txt");

            Console.WriteLine("Чек сохранён в файл Чек.txt");
        }

    }
}
