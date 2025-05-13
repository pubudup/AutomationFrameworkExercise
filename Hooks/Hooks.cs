using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;

namespace PlaywrightTests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext) {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task setUp()
        {
 
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions { });
            var page = await browserContext.NewPageAsync();
            _objectContainer.RegisterInstanceAs(browser);
            _objectContainer.RegisterInstanceAs(page);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}