using System;
using System.Diagnostics;
using RestSharp;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using SpecFlowProject.Resuable;
using NUnit.Framework;
using SpecFlowProject.Steps;
using RestSharp.Serialization.Json;
using System.IO;
using SpecFlowProject.Models;

namespace SpecFlowProject.Features
{
    [Binding]
    public class RestApi
    {
        public static IRestResponse response;
        public static RestClient client;
        public static IRestRequest request;
        String jsonBodyString = null;
        PostResponse postResponseObj;
        GetResponse getResponseObj;
        private readonly String endPoint = "https://rahulshettyacademy.com";
        private readonly String postResource = "/maps/api/place/add/json?key=qaclick123";
        private readonly String getResource = "/maps/api/place/get/json?key=qaclick123";
        ApiUtil apiUtil = new ApiUtil();

        [Given(@"the rest api for post is ready")]
        public void GivenTheRestApiForPostIsReady()
        {

            StreamReader str = new StreamReader("C:\\Users\\ramkumar.raja\\source\\repos\\Specflow\\SpecFlowProject\\SpecFlowProject\\InputJson\\Post.json");
            // StreamReader str = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"InputJson\", "Post.json"));
            jsonBodyString = str.ReadToEnd();
        }

        [When(@"post the record with some details")]
        public void WhenIPostTheRecordWithSomeDetails()
        {
             client = new RestClient(endPoint);
             request = new RestRequest(Method.POST);
            request.Resource = postResource;
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(jsonBodyString);
            response = client.Execute(request);

            Console.WriteLine(response.Content);

            postResponseObj = apiUtil.Deserialize<PostResponse>(response);
            

        }

        [Then(@"validate the success status OK")]
        public void ThenValidateTheSuccessStatusOK()
        {
            Assert.AreEqual("OK", postResponseObj.status);
        }

        [Then(@"get the record with place id")]
        public void ThenGetTheRecordWithPlaceId()
        {
            client = new RestClient(endPoint);
            request = new RestRequest(Method.GET);
            request.Resource = getResource+"&place_id="+ postResponseObj.place_id;
            request.AddHeader("Content-Type", "application/json");
            response = client.Execute(request);

        }

        [Then(@"validate the house name (.*) from get response")]
        public void ThenValidateTheAddressSdfdfdFromGetResponse(String houseName)
        {
            getResponseObj = apiUtil.Deserialize<GetResponse>(response);
            Assert.AreEqual(houseName, getResponseObj.name);

        }
    }
}
