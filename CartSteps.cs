using saucedemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saucedemo.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private readonly CartPageObjects _cartPageObjects;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPage _page;

        public CartSteps(CartPageObjects cartPageObjects, ScenarioContext scenarioContext, IPage page)
        {
            _cartPageObjects = cartPageObjects;
            _scenarioContext = scenarioContext;
            _page = page;
        }
        [When(@"User clicks continueShopping")]
        public async Task WhenClickContinueShopping()
        {
            await _cartPageObjects.Click_ContinueShoppingButtonTask();
        }
        [Then(@"Correct Product details are displayed")]
        public async void ThenCorrectProductDetailsAreDisplayed(Table table)
        {
            var data = Drivers.TableExtension.ToDictionary(table);
            await _cartPageObjects.Assert_ItemName(data["ItemName"]);
            await _cartPageObjects.Assert_Itemdesc(data["ItemDescription"]);
            await _cartPageObjects.Assert_ItemPrice(data["Price"]);

        }



    }
}
