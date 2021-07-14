using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using SpecFlowProject.Resuable;
using SpecFlowProject.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class PurchaseClothesSteps:Base
    {
     
       
        Home homePage = new Home();
    
        [Given(@"user on the homepage and selecting the single product option")]
        public void WhenTheySelectingTheSingleProductOption()
        { 
            IWebElement element = homePage.elementInVisible("menu - item - dropdown - 251");
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();

            driver.FindElement(By.XPath("//a[@title='Single Product']")).Click();
          
        }
        
        [Then(@"they can see the (.*) product")]
        public void ThenTheyCanSeeTheBlackTrousersProduct(String expectedClothName)
        {
            IWebElement clothName = driver.FindElement(By.XPath("//div[@class='summary entry-summary']/h1[contains(text(),'Black trousers')]"));
            Assert.That(clothName.Text, Is.EqualTo(expectedClothName));
        }
        
        [Then(@"they add it into the cart")]
        public void ThenTheyAddItIntoTheCart()
        {
            driver.FindElement(By.Name("add-to-cart")).Click();
            Console.WriteLine("Item has been added into the cart");
            
        }
    }
}
