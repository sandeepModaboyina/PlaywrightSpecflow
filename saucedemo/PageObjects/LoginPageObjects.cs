using Microsoft.Playwright;
using FluentAssertions;

namespace saucedemo.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IPage _page;
        public LoginPageObjects(IPage page)
        {
            _page = page;
        }
        //Selectors
        private ILocator UserNameInput => _page.GetByPlaceholder("Username");
        private ILocator PasswordInput => _page.GetByPlaceholder("Password");
        private ILocator HomePageTextLocator => _page.Locator("//div[@class='login_logo']");
        private ILocator LoginButton => _page.Locator("[id='login-button']");
        private ILocator EpicSadFaceMessageLocator => _page.Locator("//div[@class='error-message-container error']");

        //Reuable Methods
        public async Task LoginTask(string userName, string password)
        {
            await UserNameInput.FillAsync(userName);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }
        //Asserations
        public async Task AssertInventoryPageDisplayed()
        {
            var url = _page.Url;
            url.Should().Be("https://www.saucedemo.com/inventory.html");
        }
        public async Task AssertHomePageTask(string expectedHomePageMessage)
        {
            var text = await HomePageTextLocator.TextContentAsync();
            text.Should().Be(expectedHomePageMessage);
        }
        public async Task AssertEpicSadFaceMessage(string expectedHomePageMessage)
        {
            var text = await EpicSadFaceMessageLocator.TextContentAsync();
            text.Should().Be(expectedHomePageMessage);
        }
    }
}
