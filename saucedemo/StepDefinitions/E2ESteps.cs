using saucedemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saucedemo.StepDefinitions
{
    [Binding]
    public class E2ESteps
    {
        private readonly LoginPageObjects _loginPageObjects;
        private readonly InventoryPageObjects _inventoryPageObjects;
        private readonly CartPageObjects _cartPageObjects;
        private readonly CheckOutPageObjects _checkoutPageObjects;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPage _page;

        public E2ESteps(LoginPageObjects loginPageObjects, InventoryPageObjects inventoryPageObjects, CartPageObjects cartPageObjects, CheckOutPageObjects checkoutPageObjects, ScenarioContext scenarioContext, IPage page)
        {
            _loginPageObjects = loginPageObjects;
            _inventoryPageObjects = inventoryPageObjects;
            _cartPageObjects = cartPageObjects;
            _checkoutPageObjects = checkoutPageObjects;
            _scenarioContext = scenarioContext;
            _page = page;
        }
        [Given(@"standard user on Inventory page")]
        public async Task GivenStandardUserOnInventoryPage()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
            await _loginPageObjects.LoginTask("standard_user", "secret_sauce");
        }
      
        [When(@"a product is added to cart")]
        public async Task WhenAProductIsAddedToCart()
        {
            await _inventoryPageObjects.SelectingProductBasedOnNameTask("labs-bolt-t-shirt");
            await _inventoryPageObjects.Click_ShoppingCartTask();
            await _cartPageObjects.Click_CheckOutButtonTask();
        }

        [When(@"filled in required form to checkout")]
        public async Task WhenFilledInRequiredFormToCheckout()
        {
            await _checkoutPageObjects.FillCheckOutForm();
            await _checkoutPageObjects.Click_ContinueButtonTask();
            await _checkoutPageObjects.Click_FinishButtonTask();
        }

        [Then(@"confirmation message displayed")]
        public async Task ThenConfirmationMessageDisplayed()
        {
            await _checkoutPageObjects.Assert_ThankYoyMessageTask("Thank you for your order!");
            await _checkoutPageObjects.Assert_CompleteMessageTask("Your order has been dispatched, and will arrive just as fast as the pony can get there!");
        }
        [When(@"user add a products to cart")]
        public async Task WhenUserAddAProductsToCart(Table table)
        {
            var data = Drivers.TableExtension.ToDictionary(table);
            await _inventoryPageObjects.SelectingProductBasedOnNameTask(data["Product1"]);
        }

        [When(@"user add two products to cart")]
        public async void WhenUserAddTwoProductsToCart(Table table)
        {
            var data = Drivers.TableExtension.ToDictionary(table);
            await _inventoryPageObjects.SelectingProductBasedOnNameTask(data["Product1"]);
            await _inventoryPageObjects.SelectingProductBasedOnNameTask(data["Product2"]);
            await _inventoryPageObjects.Click_ShoppingCartTask();
            await _cartPageObjects.Click_CheckOutButtonTask();

        }



    }
}
