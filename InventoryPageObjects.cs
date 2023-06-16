using Microsoft.Playwright;
using FluentAssertions;



namespace saucedemo.PageObjects
{
    public class InventoryPageObjects
    {
        private readonly IPage _page;

        public InventoryPageObjects(IPage page)
        {
            _page = page;
        }
        private ILocator ShoppingcartButton => _page.Locator("#shopping_cart_container");


        private ILocator ShoppingCartBadgeValueLocator => _page.Locator("//span[@class='shopping_cart_badge']");

        public async Task SelectingProductBasedOnNameTask(string ProductName)
        {
            //add-to-cart-sauce-labs-backpack  add-to-cart-sauce-labs-bolt-t-shirt
            //add-to-cart-sauce-labs-bike-light
            var selector = $"#add-to-cart-sauce-{ProductName.ToLower()}";
            await _page.ClickAsync(selector);
        }

        public async Task Click_ShoppingCartTask()
        {
            await ShoppingcartButton.ClickAsync();  
        }
        public async Task Assert_CartNoItems(string noofItems)
        {
            var noofItemsValue = await ShoppingCartBadgeValueLocator.TextContentAsync();
            noofItemsValue.Should().Be(noofItems);
        }
    }
}
