using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class InterestCalculatorPage: BasePage
    {
        
        private static string url = "https://ten10techtest-dnd6bgfzcqdggver.uksouth-01.azurewebsites.net/";
        private static ILocator loginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private static ILocator emailTextbox => _page.GetByRole(AriaRole.Textbox, new() { Name = "Email" });
        private static ILocator passwordTextbox => _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        private static ILocator loginUserButton => _page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
        private static ILocator dailyDuration => _page.GetByRole(AriaRole.Link, new() { Name = "Daily" });
        private static ILocator monthlyDuration => _page.GetByRole(AriaRole.Link, new() { Name = "Monthly" });
        private static ILocator yearlyDuration => _page.GetByRole(AriaRole.Link, new() { Name = "Yearly" });
        private static ILocator principleAmountSlider =>
            _page.GetByRole(AriaRole.Slider, new() { Name = "Principal Amount:" });
        private static ILocator currentPrincipleAmount => _page.Locator("//*[@id=\"selectedValue\"]");
        private static ILocator interestRateDropdown =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Select Interest Rate" });
        private static ILocator interestRateValue15 => _page.GetByRole(AriaRole.Checkbox, new() { Name = "15%" });
        private static ILocator selectedInterestRate =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Selected Rate: 15%" });
        private static ILocator consentCheckbox =>
            _page.GetByRole(AriaRole.Checkbox, new() { Name = "Please accept this mandatory" });
        private static ILocator calculateButton => _page.GetByRole(AriaRole.Button, new() { Name = "Calculate" });
        private static ILocator interestAmountText =>
            _page.GetByRole(AriaRole.Heading, new() { Name = "Interest Amount:" }); //3.90
        private static ILocator totalAmountWithInterestText =>
            _page.GetByRole(AriaRole.Heading, new() { Name = "Total Amount with Interest:" }); //9503.90
        
        
        public InterestCalculatorPage(IPage page) : base(page) {}
        
        public async Task gotoCalculatorPage() {

            await _page.GotoAsync(url);
        }

        public async Task clickLoginButton()
        {
            await loginButton.ClickAsync();
        }

        public async Task fillEmailTextbox()
        {
            await emailTextbox.ClickAsync();
            await emailTextbox.FillAsync("[USEREMAIL]");
        }
        public async Task fillPasswordTextbox()
        {
            await passwordTextbox.ClickAsync();
            await passwordTextbox.FillAsync("[PASSWORD]");
        }
        public async Task clickLoginUserButton()
        {
            await loginUserButton.ClickAsync();
        }
        public async Task<bool> checkDailyDurationLink()
        {
            return await dailyDuration.IsVisibleAsync();
        }
        public async Task<bool> checkMonthlyDurationLink()
        {
            return await monthlyDuration.IsVisibleAsync();
        }
        public async Task<bool> checkYearlyDurationLink()
        {
            return await yearlyDuration.IsVisibleAsync();
        }
        public async Task fillPrincipleAmountSlider(int principleAmount)
        {
            await principleAmountSlider.FillAsync(principleAmount.ToString());
        }
        public async Task<string> getPrincipleAmount()
        {
            return await currentPrincipleAmount.InnerTextAsync();
        }
        public async Task selectInterestRate()
        {
            await interestRateDropdown.CheckAsync();
            await interestRateValue15.CheckAsync();
        }
        public async Task<bool> selectedInterestRateIsVisible()
        {
            return await selectedInterestRate.IsVisibleAsync();
        }
        
        public async Task<string> getSelectedInterestRate()
        {
            return await interestRateValue15.InnerTextAsync();
        }
        public async Task selectConsentCheckbox()
        {
            await consentCheckbox.CheckAsync();
        }
        public async Task clickCalculateButton()
        {
            await calculateButton.ClickAsync();
        }
        public async Task<string> getInterestAmountText()
        {
            return await interestAmountText.InnerTextAsync();
        }
        public async Task<string> getTotalAmountWithInterestTest()
        {
            return await totalAmountWithInterestText.InnerTextAsync();
        }

    }
}
