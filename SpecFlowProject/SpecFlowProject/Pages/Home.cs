using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProject.Resuable;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    class Home:Base
    {
        public readonly int WAIT_TIME = 10;
        public IWebElement elementInVisibleById(String element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIME));
           return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(element)));
        }

        public IWebElement elementInVisibleByXpath(String element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIME));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
        }

        public IWebElement elementClickableByXpath(String element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIME));
            return wait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
        }

        public void jsExecutorClick(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

    }
}
