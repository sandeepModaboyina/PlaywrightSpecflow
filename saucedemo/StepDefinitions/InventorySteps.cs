using saucedemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saucedemo.StepDefinitions
{
    [Binding]
    public class InventorySteps
    {
        private readonly InventoryPageObjects _inventoryPageObjects;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPage _page;

        public InventorySteps(InventoryPageObjects inventoryPageObjects, ScenarioContext scenarioContext, IPage page)
        {
            _inventoryPageObjects = inventoryPageObjects;
            _scenarioContext = scenarioContext;
            _page = page;
        }
        [Given(@"I have ""([^""]*)"" items in my cart")]
        [Then(@"I should have ""(.*)"" item in the cart")]
        public async void ThenIShouldHaveItemInTheCart(string CartItemsValue)
        {
            await _inventoryPageObjects.Assert_CartNoItems(CartItemsValue);
        }



        [Then(@"it redirects to Inventory Page")]
        public async Task ThenItRedirectsToInventoryPage()
        {
            var url = _page.Url;
            url.Should().Be("https://www.saucedemo.com/inventory.html");
        }

        [Given(@"A product is added to cart")]
        public async Task GivenAProductIsAddedToCart()
        {
            await _inventoryPageObjects.SelectingProductBasedOnNameTask("labs-bolt-t-shirt");
            await _inventoryPageObjects.Click_ShoppingCartTask();
        }

    }
}
