using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecFlowProject.Resuable;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class MyHooks:Base
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            GetDriver().Navigate().GoToUrl("https://testscriptdemo.com/");
            Console.WriteLine("Browser launched");
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            driver.Quit();
        }
    }
}
