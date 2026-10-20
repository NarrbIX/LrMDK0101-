using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_3
{
    using System;
    using System.Collections.Generic;

    namespace ConsoleApp1
    {
        public class Accountant /// бухгалтер
        {
            public static ProfitByPeriodReport MakeReport(SaleHistory history,
                                                          DateTime startPeriod,
                                                          DateTime endPeriod)
            {
                Dictionary<string, ReportRow> totalRows = new Dictionary<string, ReportRow>();

                List<SaleItem> items = history.GetSales();

                foreach (SaleItem item in items)
                {
                    string saleProduct = item.GetProductName();
                    DateTime saleDate = item.GetSaleDate();

                    if (startPeriod > saleDate || saleDate > endPeriod)
                    {
                        continue;
                    }


                    if (totalRows.ContainsKey(saleProduct))
                    {
                        ReportRow row = totalRows[saleProduct];
                        row.Count_ += item.GetCount();
                        row.Cost_ += item.GetCount() * item.GetPrice();
                    }
                    else
                    {
                        totalRows.Add(saleProduct, new ReportRow
                        {
                            Product_ = saleProduct,
                            Count_ = item.GetCount(),
                            Cost_ = item.GetCount() * item.GetPrice()
                        });
                    }

                }

                ProfitByPeriodReport result = new ProfitByPeriodReport();

                foreach (KeyValuePair<string, ReportRow> row in totalRows)
                {
                    result.AddRow(row.Value);
                }


                return result;
            }
        }
    }
}

