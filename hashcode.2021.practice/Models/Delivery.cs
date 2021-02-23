using System.Collections.Generic;
using System.Linq;

namespace hashcode._2021.practice.Models
{
    public class Delivery
    {
        public List<Pizza> Pizzas = new List<Pizza>();

        public long Score() {
            ISet<string> distinctIngredients = new HashSet<string>();

            foreach (Pizza p in Pizzas) {
                foreach (string i in p.Ingredients)
                {
                    distinctIngredients.Add(i);
                }
            }
            return distinctIngredients.Count * distinctIngredients.Count;
        }

        public override string ToString() {
            string order = string.Join(' ', Pizzas.Select(p=>p.Id.ToString()));
            return $"{Pizzas.Count} {order}";
        }
    }
}