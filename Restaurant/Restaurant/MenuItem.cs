using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class MenuItem
    {
        public MenuItem(Guid id, string name, IDictionary<Ingredient, decimal> ingredients)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
        }

        public Guid Id { get; }
        public string Name { get; }
        public IDictionary<Ingredient, decimal> Ingredients { get; }
    }
}