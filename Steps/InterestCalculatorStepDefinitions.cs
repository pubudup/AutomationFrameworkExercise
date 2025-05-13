using Microsoft.Playwright;
using PlaywrightTests.Pages;
using Reqnroll;
using Microsoft.Playwright.NUnit;


namespace PlaywrightTests
{
    [Binding]
    public class InterestCalculatorStepDefinitions
    {
        private readonly InterestCalculatorPage _interestCalculatorPage;
        private readonly int principleAmount = 9500;

        public InterestCalculatorStepDefinitions(InterestCalculatorPage page) 
        {
            this._interestCalculatorPage = page;
        }
        

        [Given(@"I am logged in to calculator")]
        public async Task givenIAmLoggedInToCalculator()
        {
            await _interestCalculatorPage.gotoCalculatorPage();
            await  _interestCalculatorPage.clickLoginButton();
            Thread.Sleep(3000);
            await _interestCalculatorPage.fillEmailTextbox();
            await _interestCalculatorPage.fillPasswordTextbox();
            await _interestCalculatorPage.clickLoginUserButton();
        }


        [Then(@"daily monthly and yearly options should be displayed")]
        public async Task thenDailyMonthlyAndYearlyOptionsShouldBeDisplayed()
        {
            Thread.Sleep(5000);
            Assert.Equals(await _interestCalculatorPage.checkDailyDurationLink(),true);
            Assert.Equals(await _interestCalculatorPage.checkMonthlyDurationLink(), true);
            Assert.Equals(await _interestCalculatorPage.checkYearlyDurationLink(), true);
        }

        [When(@"I drag principle amount slider")]
        public async Task whenIDragPrincipleAmountSlider()
        {
            await _interestCalculatorPage.fillPrincipleAmountSlider(principleAmount);
        }

        [Then(@"principle amount should be filled")]
        public async Task thenPrincipleAmountShouldBeFilled()
        {
            Assert.Equals(await _interestCalculatorPage.getPrincipleAmount(), principleAmount.ToString());
        }

        [When(@"I select duration")]
        public async Task whenISelectDuration()
        {
            await _interestCalculatorPage.checkDailyDurationLink();
        }

        [When(@"I select principle amount")]
        public async Task whenISelectPrincipleAmount()
        {
            await _interestCalculatorPage.fillPrincipleAmountSlider(principleAmount);
        }

        [When(@"I select interest rate")]
        public async Task whenISelectInterestRate()
        {
            await _interestCalculatorPage.selectInterestRate();
        }

        [When(@"I select consent checkbox")]
        public async Task whenISelectConsentCheckbox()
        {
            await _interestCalculatorPage.selectConsentCheckbox();
        }

        [Then(@"correct interest rate should be calculated")]
        public async Task thenCorrectInterestRateShouldBeCalculated()
        {
            Assert.Equals(await _interestCalculatorPage.getInterestAmountText(), "3.90");
        }

        [Then(@"selected interest rate should be (.*)%")]
        public async Task thenSelectedInterestRateShouldBe(int interestRate)
        {
            Assert.Equals(await _interestCalculatorPage.selectedInterestRateIsVisible(), true);
            //Assertion to be added to element contains 15% as selected rate
        }

        [Then(@"correct total amount should be displayed")]
        public async Task thenCorrectTotalAmountShouldBeDisplayed()
        {
            Assert.Equals(await _interestCalculatorPage.getTotalAmountWithInterestTest(), "9503.90");
        }

        [When(@"I click calculate button")]
        public async Task whenIClickCalculateButton()
        {
            await  _interestCalculatorPage.clickCalculateButton();
        }
        

        [When(@"interest rate is calculated")]
        public async Task whenInterestRateIsCalculated()
        {
            await _interestCalculatorPage.checkDailyDurationLink();
            await _interestCalculatorPage.fillPrincipleAmountSlider(principleAmount);
            await _interestCalculatorPage.selectInterestRate();
            await _interestCalculatorPage.selectConsentCheckbox();
            await  _interestCalculatorPage.clickCalculateButton();
            
        }

        [Then(@"calculated interest rate should be rounded to two decimals")]
        public Task thenCalculatedInterestRateShouldBeRoundedToTwoDecimals()
        {
            ScenarioContext.StepIsPending();
            return Task.CompletedTask;
        }

        [Then(@"total amount should be rounded to two decimals")]
        public Task thenTotalAmountShouldBeRoundedToTwoDecimals()
        {
            ScenarioContext.StepIsPending();
            return Task.CompletedTask;
        }

        [Then(@"mandatory fields should be validated")]
        public Task thenMandatoryFieldsShouldBeValidated()
        {
            ScenarioContext.StepIsPending();
            return Task.CompletedTask;
        }
    }
}
