using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {

            ShowProducts();
            CreateOrder();
            if (!CheckOrder())
                return;
            FinishOrder();

            /* string[] name = { "хлеб", "молоко", "сыр", "колбаса", "масло" };
             int[] price = { 45, 80, 350, 420, 120 };
             int[] stock = { 30, 25, 12, 20, 18 };
             int[] order = new int[5];

             for (int i = 0; i < 5; i++)
                 Console.WriteLine($"{i + 1}. {name[i]} - {price[i]} руб., {stock[i]} шт.");
             int number;

             do
             {
                 number = Input("Номер товара (0 - конец): ", 0, 5);

                 if (number != 0)
                     order[number - 1] += Input("Количество: ", 1, 1000);
             }
             while (number != 0);
             for (int i = 0; i < 5; i++)
             {
                 if (order[i] > stock[i])
                 {
                     Console.WriteLine($"Не хватает товара: {name[i]}");
                     return;
                 }
             }
             int sum = 0;

             for (int i = 0; i < 5; i++)
             {
                 sum += order[i] * price[i];
                 stock[i] -= order[i];
             }

             Console.WriteLine($"Стоимость заказа: {sum} руб.");

             for (int i = 0; i < 5; i++)
                 Console.WriteLine($"{name[i]}: {stock[i]} шт.");*/
        }
        /* static int Input(string text, int min, int max)
         {
             int number;

             do
             {
                 Console.Write(text);
             }
             while (!int.TryParse(Console.ReadLine(), out number) ||
                    number < min || number > max);

             return number;
         }*/
        static string[] name =
     {
        "анальгин", "аспирин", "йод",
        "амоксициллин", "витамины"
    };

        static int[] price = { 35, 40, 120, 650, 480 };
        static int[] stock = { 30, 25, 20, 12, 15 };
        static int[] order = new int[5];

        static void ShowProducts()
        {
            for (int i = 0; i < name.Length; i++)
                Console.WriteLine($"{i + 1}. {name[i]} - {price[i]} руб., {stock[i]} уп.");
        }
        static void CreateOrder()
        {
            int number;

            do
            {
                number = Input("Номер препарата (0 - конец): ", 0, 5);

                if (number > 0)
                    order[number - 1] += Input("Количество упаковок: ", 0, 1000);
            }
            while (number > 0);
        }
        static int Input(string text, int min, int max)
        {
            int number;

            while (true)
            {
                Console.Write(text);

                if (int.TryParse(Console.ReadLine(), out number) &&
                    number >= min && number <= max)
                    return number;

                Console.WriteLine("Ошибка ввода");
            }
        }
        static bool CheckOrder()
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (order[i] > stock[i])
                {
                    Console.WriteLine($"Не хватает препарата: {name[i]}");
                    return false;
                }
            }

            return true;
        }
        static void FinishOrder()
        {
            int sum = 0;

            for (int i = 0; i < name.Length; i++)
            {
                sum += order[i] * price[i];
                stock[i] -= order[i];
            }

            Console.WriteLine($"Стоимость заказа: {sum} руб.");

            for (int i = 0; i < name.Length; i++)
                Console.WriteLine($"{name[i]}: {stock[i]} уп.");
        }
    }

}
