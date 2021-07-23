using NUnit.Framework;
using SpecFlowProject.DataBase;
using System;
using TechTalk.SpecFlow;
using System.Linq;
namespace SpecFlowProject.Steps
{
    [Binding]
    public class EFSteps
    {
        [Given(@"test db records")]
        public void GivenTestDbRecords()
        {
            DemoEntities context = new DemoEntities();

            var query = from p in context.MyTests where p.ID == 1 select p;

            var myTable = query.FirstOrDefault<MyTest>();
            Console.WriteLine(myTable.FirstName);
            Assert.AreEqual("John", myTable.FirstName);

        }
    }
}
