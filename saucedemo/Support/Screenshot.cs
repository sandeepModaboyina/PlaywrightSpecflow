using Microsoft.Playwright;

namespace saucedemo.Support
{
    public static class Screenshot
    {
        public static async Task ScreenShotTask(IPage page)
        {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var title = await page.TitleAsync();
            var path = $"../../../Screenshots/{date}_{title}.png";
            var ss = new PageScreenshotOptions()
            {
                Path = path,
                FullPage=true

            };
            await page.ScreenshotAsync(ss);
        }
    }
}
