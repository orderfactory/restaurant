using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IOrderService
    {
        Task<bool> ReserveIngredients(IDictionary<Ingredient, decimal> ingredients);
    }

    public class OrderService : IOrderService
    {
        public Task<bool> ReserveIngredients(IDictionary<Ingredient, decimal> ingredients)
        {
            throw new NotImplementedException();
        }
    }
}