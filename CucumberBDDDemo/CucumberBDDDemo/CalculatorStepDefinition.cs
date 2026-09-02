using System;
using System.Collections.Generic;
using System.Text;

using Reqnroll;
using Xunit;

namespace CucumberBDDDemo
{

    [Binding]
    public class CalculatorStepDefinitions
    {
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        [Given(@"I have entered {int} into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            // First time this runs, set FirstNumber; second time, set SecondNumber
            if (_calculator.FirstNumber == 0)
            {
                _calculator.FirstNumber = number;
            }
            else
            {
                _calculator.SecondNumber = number;
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [Then(@"the result should be {int}")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.Equal(expectedResult, _result);
        }
    }
}
