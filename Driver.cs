using Microsoft.Playwright;

namespace saucedemo.Drivers
{
    public class Driver:IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;
        public Driver()
        {
            _page = Init();
        }
        public IPage page => _page.Result;

        private async Task<IPage> Init()
        {
            using var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            return await _browser.NewPageAsync();
        }
        public void Dispose()
        {
            _browser?.CloseAsync();
        }
    }
}   
