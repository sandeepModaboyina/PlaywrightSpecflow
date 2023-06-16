using Microsoft.Playwright;
using saucedemo.PageObjects;
using TechTalk.SpecFlow;

namespace saucedemo.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPageObjects _loginPageObjects;
        private readonly ScenarioContext _scenarioContext;
        private readonly IPage _page;
        private readonly string Passowrd = "secret_sauce";

        public LoginSteps(IPage page,LoginPageObjects loginPageObjects,ScenarioContext scenarioContext)
        {
            _loginPageObjects = loginPageObjects;
            _scenarioContext = scenarioContext;
            _page = page;
        }

        [Given(@"I am Saucedemo Homepage")]
        public async Task GivenIAmSaucedemoHomepage()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
            await _loginPageObjects.AssertHomePageTask("Swag Labs");
        }

        [Given(@"A ""(.*)"" on Inventory page")]
        public async Task GivenAOnInventoryPage(string UserName)
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
            await _loginPageObjects.LoginTask(UserName, Passowrd);
        }

        [When(@"I enter valid username and password")]
        public async void WhenIEnterValidUsernameAndPassword(Table table)
        {
            var data = Drivers.TableExtension.ToDictionary(table);

            await _loginPageObjects.LoginTask(data["User"], data["Password"]);
        }

        [Then(@"it should navigate to Inventory page")]
        public async void ThenItShouldNavigateToInventoryPage()
        {
            await _loginPageObjects.AssertInventoryPageDisplayed();  
        }
        [When(@"I enter given (.*) and (.*)")]
        public async Task WhenIEnterGivenUserNameAndSecret_Sauce(string UserName, string Password)
        {
            await _loginPageObjects.LoginTask(UserName, Password);
        }

        [Then(@"it should give me expected (.*)")]
        public async Task ThenItShouldGiveMeExpectedInventoryPage(string outcome)
        {
         if (outcome == "InventoryView")
            {
                await _loginPageObjects.AssertInventoryPageDisplayed();
            }
         if( outcome == "Epic sadface")
            {
                await _loginPageObjects.AssertEpicSadFaceMessage("Epic sadface: Sorry, this user has been locked out.");
            }
         if(outcome == "CredentialValidationError")
            {
                await _loginPageObjects.AssertEpicSadFaceMessage("Epic sadface: Username and password do not match any user in this service");
            }

        }


    }
}
