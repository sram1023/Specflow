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
        public IWebElement elementInVisible(String element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIME));
           return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menu-item-dropdown-251")));
        }


    }
}
