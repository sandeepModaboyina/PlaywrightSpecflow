

namespace saucedemo.PageObjects
{
    public class CartPageObjects
    {
        private readonly IPage _page;
        public CartPageObjects(IPage page)
        {
            _page = page;
        }
        private ILocator CartCheckoutButton => _page.Locator("[id='checkout']");
        private ILocator CartContinueShoppingButton => _page.Locator("[id='continue-shopping']");
        private ILocator CarRemoveButton => _page.Locator("(//button[normalize-space()='Remove'])[1]");
        private ILocator ItemNameTextLocator => _page.Locator("//div[@class='inventory_item_name']").First;
        private ILocator ItemDescritptionLocator => _page.Locator("//div[@class='inventory_item_desc']");
        private ILocator ItemPriceLocator => _page.Locator("//div[@class='inventory_item_price']");

        // private ILocator CartContinueShoppingButton => _page.Locator("[id='continue-shopping']");

        public async Task Click_CheckOutButtonTask()
        {
            await CartCheckoutButton.ClickAsync();
        }
        public async Task Click_ContinueShoppingButtonTask()
        {
            await CartContinueShoppingButton.ClickAsync();
        }
        public async Task RemoveItemsFromCartTask(string ProdcutName)
        {
            //remove-sauce-labs-bolt-t-shirt , 
            var element = $"#/remove-sauce-{ProdcutName.ToLower()}";
            await _page.ClickAsync(element);
        }
        public async Task Assert_Text(ILocator locator, string textvalue)
        {
            var text = await locator.TextContentAsync();
            text.Should().Be(textvalue);
        }
        public async Task Assert_ItemName(string text)
        {
            await Assert_Text(ItemNameTextLocator, text);
        }
        public async Task Assert_Itemdesc(string text)
        {
            await Assert_Text(ItemDescritptionLocator, text);
        }
        public async Task Assert_ItemPrice(string text)
        {
            await Assert_Text(ItemPriceLocator, text);
        }
    }
}
