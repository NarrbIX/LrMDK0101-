using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lr_3
{
    public class Receipt
    {
        private readonly List<SaleItem> items_ = new List<SaleItem>();

        public void AddItem(SaleItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            items_.Add(item);
        }

        public string BuildText()
        {
            StringBuilder text = new StringBuilder();
            double total = 0;

            text.AppendLine("             ЧЕК");
            text.AppendLine("----------------------------------------");

            foreach (SaleItem item in items_)
            {
                double itemTotal = item.GetCount() * item.GetPrice();
                total += itemTotal;

                text.AppendLine(
                    $"{item.GetProductName()} — {item.GetCount()} шт. × " +
                    $"{item.GetPrice().ToString("F2", CultureInfo.GetCultureInfo("ru-RU"))} = " +
                    $"{itemTotal.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"))}");
            }

            text.AppendLine("----------------------------------------");
            text.AppendLine(
                $"ИТОГО: {total.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"))}");
            text.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");

            return text.ToString();
        }

        public void Print()
        {
            Console.WriteLine(BuildText());
        }

        public void Save(string filePath)
        {
            File.WriteAllText(filePath, BuildText(), new UTF8Encoding(true));
        }
    }
}
