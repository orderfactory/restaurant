using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Restaurant.Tests
{
    public class OrderTests
    {
        private readonly IOrderService _orderService = Substitute.For<IOrderService>();

        [Fact]
        public async Task GivenMenuItemAndQuantityWhenAddThenReserveIngredients()
        {
            var ingredientOne = new Ingredient(default, "foo", default);
            var ingredientTwo = new Ingredient(default, "bar", default);

            var ingredientsPerItem = new Dictionary<Ingredient, decimal>
            {
                {ingredientOne, 10},
                {ingredientTwo, 20}
            };
            var menuItem = new MenuItem(default, "some menu item", ingredientsPerItem);
            var order = new Order(_orderService);

            const int portionsCount = 3;
            var ingredientsExpected = new Dictionary<Ingredient, decimal>
            {
                {ingredientOne, 10 * portionsCount},
                {ingredientTwo, 20 * portionsCount}
            };

            await order.Add(menuItem, portionsCount);

            await _orderService.Received(1)
                .ReserveIngredients(
                    Arg.Is<IDictionary<Ingredient, decimal>>(d => d.SequenceEqual(ingredientsExpected)));
        }
    }
}