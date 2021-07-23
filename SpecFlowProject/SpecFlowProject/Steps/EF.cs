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
        DemoEntities context = new DemoEntities();

        [Given(@"able to read the record")]
        public void GivenTestDbRecords()
        {
           
            var query = from p in context.MyTests where p.ID == 1 select p;
            var myTable = query.FirstOrDefault<MyTest>();
            Console.WriteLine(myTable.FirstName);
            Assert.AreEqual("John", myTable.FirstName);
            
        }

        [Then(@"insert the new record")]
        public void insertRecords()
        {
            var MyTest = new MyTest
            {
                ID = 3,
                FirstName = "Abbey",
                LastName = "Filton",
                Age = 32
            };

            context.MyTests.Add(MyTest);
    
            context.SaveChanges();

        }
    }
}
