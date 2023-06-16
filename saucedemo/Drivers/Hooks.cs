﻿using saucedemo.Support;
using Microsoft.Playwright;
using NUnit.Framework;
using BoDi;
using TechTalk.SpecFlow;



namespace saucedemo.Drivers
{
    [Binding]
    internal class Hooks
    {
        public IBrowser browser;
        public IBrowserContext context;
        public IPage page;
        public IPlaywright playwright;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private string? WebAppUrl;
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            if (_scenarioContext.TestError != null)
            {
                await Support.Screenshot.ScreenShotTask(page);
            }
            await browser.DisposeAsync();
        }

        [BeforeScenario()]
        public async Task createBrowser()
        {
         //   WebAppUrl = TestContext.Parameters["WebAppUrl"] ?? throw new Exception("App url is missing");
            playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions { Headless = true };
            browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions);
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(page);
          //  await page.GotoAsync(WebAppUrl);
        }
    }
}