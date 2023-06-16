using saucedemo.Support;

namespace saucedemo.PageObjects
{
    public class CheckOutPageObjects
    {

        private readonly IPage _page;
        public CheckOutPageObjects(IPage page)
        {
            _page = page;
        }
        private ILocator FirstNameInput => _page.Locator("[id='first-name']");
        private ILocator LastNameInput => _page.Locator("[id='last-name']");
        private ILocator PostalCodeInput => _page.Locator("[id='postal-code']");
        private ILocator CancelButton => _page.Locator("[id='cancel']");
        private ILocator ContinueButton => _page.Locator("#continue");
        private ILocator FinishButton => _page.Locator("#finish");
        private ILocator CompleteMessageLocator => _page.Locator("//div[@class='complete-text']");
        private ILocator ThankyouLocator => _page.Locator("//h2[normalize-space()='Thank you for your order!']");
        //private ILocator CancelButton => _page.Locator("#cancel");
       
        public async Task FillCheckOutForm()
        {
            await FirstNameInput.FillAsync(RandomString.RandomStringGenerator(5));
            await LastNameInput.FillAsync(RandomString.RandomStringGenerator(5));
            await PostalCodeInput.FillAsync(RandomString.RandomStringGenerator(5));
        }
        public async Task Click_ContinueButtonTask()
        {
            await ContinueButton.ClickAsync();
        }
        public async Task Click_CancelButtonTask()
        {
            await CancelButton.ClickAsync();
        }
        public async Task Click_FinishButtonTask()
        {
            await FinishButton.ClickAsync();
        }
        public async Task Assert_ThankYoyMessageTask(string message)
        {
            var text = await ThankyouLocator.TextContentAsync();
            text.Should().Be(message);
        }
        public async Task Assert_CompleteMessageTask(string messaage)
        {
            var text = await CompleteMessageLocator.TextContentAsync();
            text.Should().Be(messaage);
        }
    }
}
