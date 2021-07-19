﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using SpecFlowProject.Resuable;
using SpecFlowProject.Pages;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class PurchaseClothesSteps : Base
    {


        Home homePage = new Home();

        [Given(@"user on the homepage and selecting the single product option")]
        public void WhenTheySelectingTheSingleProductOption()
        {
            IWebElement element = homePage.elementInVisibleById("menu-item-dropdown-251");
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

        [Then(@"they clicking the shop menu options")]
        public void ThenTheyClickShopMenu()
        {
            homePage.elementInVisibleByXpath("//a[@title='Shop']").Click();
           
        }

        [Then(@"they add the (.*) watches")]
        public void ThenTheyAddWatch(String watch)
        {
            IWebElement itemName = homePage.elementInVisibleByXpath("//a/h2[contains(text(),'Modern')]");
            if (watch.Equals(itemName.Text))
            {
                //homePage.elementInVisibleByXpath("//a/h2[contains(text(),'Modern')]/../../a[2]").Click();
                IWebElement element = driver.FindElement(By.XPath("//a/h2[contains(text(),'Modern')]/../../a[2]"));
                homePage.jsExecutorClick(element);
            }
        }

        [Then(@"verify the (.*) items in the cart")]
        public void ThenVerifyTwoItems(String noOfItems)
        {

            IWebElement cartCount = homePage.elementClickableByXpath("//div[contains(@class,'header-right')]//i[@class='la la-shopping-bag']/span");

            //IWebElement tableElement = homePage.elementInVisibleByXpath("//form[@class='woocommerce-cart-form']/table");
            //IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            Assert.AreEqual(noOfItems,cartCount.Text);
        }
    }
}
