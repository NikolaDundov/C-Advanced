using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;
        public string Name { get; private set; }
        

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            int totalCal = 0;
            return totalCal = products.Sum(x => x.Calories);

        }

        public int GetProductCount()
        {
            return products.Count;
        }


        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");

            foreach (var product in products)
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString();
        }
    }
}
