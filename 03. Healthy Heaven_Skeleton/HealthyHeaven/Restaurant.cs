using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;
        public string Name { get; private set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            if (this.data.FirstOrDefault(x => x.Name == name) == null)
            {
                return false;
            }

            data.Remove(this.data.FirstOrDefault(x => x.Name == name));
            return true;
        }

        public string GetHealthiestSalad()
        {
            Salad healties = null;
            healties = data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
            return healties.Name;
        }


        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
