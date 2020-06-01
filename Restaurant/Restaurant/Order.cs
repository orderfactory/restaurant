using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Order
    {
        private readonly IDictionary<MenuItem, int> _orderItems = new Dictionary<MenuItem, int>();
        private readonly IOrderService _orderService;

        public Order(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Add(MenuItem menuItem, int quantity)
        {
            var ingredientsToReserve = menuItem.Ingredients.Select(pair =>
                    new KeyValuePair<Ingredient, decimal>(pair.Key, pair.Value * quantity))
                .ToDictionary(item => item.Key, item => item.Value);

            await _orderService.ReserveIngredients(ingredientsToReserve);

            if (_orderItems.ContainsKey(menuItem))
                _orderItems[menuItem] += quantity;
            else
                _orderItems.Add(new KeyValuePair<MenuItem, int>(menuItem, quantity));
        }
    }
}