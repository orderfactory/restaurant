using System;

namespace Restaurant
{
    public class Ingredient
    {
        public Ingredient(Guid id, string name, UnitOfMeasure unitOfMeasure)
        {
            Id = id;
            Name = name;
            UnitOfMeasure = unitOfMeasure;
        }

        public Guid Id { get; }
        public string Name { get; }
        public UnitOfMeasure UnitOfMeasure { get; }
    }
}