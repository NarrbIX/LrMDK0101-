using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_3
{
    public class Nomenclature
    {
        private Dictionary<ProductGroup, List<string>> products_;

        public Nomenclature()
        {
            products_ = new Dictionary<ProductGroup, List<string>>();
        }

        public List<string> GetAllProductsGroup(ProductGroup productGroup)
        {
            if (products_.ContainsKey(productGroup))
            {
                return products_[productGroup];
            }
            List<string> emptyResult = new List<string>();
            return emptyResult;
        }

        public void AddProduct(ProductGroup productGroup, string productName)
        {
            List<string> products = products_[productGroup];
            products.Add(productName);
        }

        public ProductGroup? GetProductGroupByProduct(string product)
        {
            foreach (KeyValuePair<ProductGroup, List<string>> productGroups
                in products_)
            {
                ProductGroup group = productGroups.Key;
                List<string> allProducts = productGroups.Value;

                if (allProducts.Contains(product))
                {
                    return group;
                }
            }

            return null;
        }


    }
}
