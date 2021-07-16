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
        String jsonPostBodyString = null;
        String jsonPutBodyString = null;
        String jsonDeleteBodyString = null;
        PostResponse postResponseObj;
        GetResponse getResponseObj;
        PutResponse putResponseObj;
        DeleteResponse deleteResponseObj;
        private readonly String endPoint = "https://rahulshettyacademy.com";
        private readonly String postResource = "/maps/api/place/add/json?key=qaclick123";
        private readonly String getResource = "/maps/api/place/get/json?key=qaclick123";
        private readonly String putResource = "/maps/api/place/update/json?key=qaclick123";
        private readonly String deleteResource = "/maps/api/place/delete/json?key=qaclick123";
        ApiUtil apiUtil = new ApiUtil();

        [Given(@"the rest api for post is ready")]
        public void GivenTheRestApiForPostIsReady()
        {

            using (StreamReader str = new StreamReader("C:\\Users\\ramkumar.raja\\source\\repos\\Specflow\\SpecFlowProject\\SpecFlowProject\\InputJson\\Post.json"))
            {
                jsonPostBodyString = str.ReadToEnd();
            }
        }

        [When(@"post the record with some details")]
        public void WhenIPostTheRecordWithSomeDetails()
        {
             client = new RestClient(endPoint);
             request = new RestRequest(Method.POST);
            request.Resource = postResource;
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(jsonPostBodyString);
            response = client.Execute(request);

            Console.WriteLine(response.Content);

        }

        [Then(@"validate the success status OK")]
        public void ThenValidateTheSuccessStatusOK()
        {
            postResponseObj = apiUtil.Deserialize<PostResponse>(response);
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

        [Then(@"validate the address (.*) from get response")]
        public void ThenValidateTheAddressSdfdfdFromGetResponse(String houseName)
        {
            getResponseObj = apiUtil.Deserialize<GetResponse>(response);
            Assert.AreEqual(houseName, getResponseObj.address);

        }

        [Then(@"the rest api for put is ready")]
        public void GivenTheRestApiForPutIsReady()
        {

            using (StreamReader str = new StreamReader("C:\\Users\\ramkumar.raja\\source\\repos\\Specflow\\SpecFlowProject\\SpecFlowProject\\InputJson\\Put.json"))
            {
                jsonPutBodyString = str.ReadToEnd();
            }
        }

        [Then(@"update the address as (.*)")]
        public void UpdateTheAddress(String houseName)
        {
            client = new RestClient(endPoint);
            request = new RestRequest(Method.PUT);
            request.Resource = putResource + "&place_id=" + postResponseObj.place_id;
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(jsonPutBodyString.Replace("placeId", postResponseObj.place_id));
            response = client.Execute(request);

            Console.WriteLine(response.Content);

            
        }

        [Then(@"validate the message (.*)")]
        public void updateResponse(String message)
        {
            putResponseObj = apiUtil.Deserialize<PutResponse>(response);
            Assert.AreEqual(message, putResponseObj.msg);
        }

        [Then(@"the rest api for delete is ready")]
        public void GivenTheRestApiForDeleteIsReady()
        {
            using (StreamReader str = new StreamReader("C:\\Users\\ramkumar.raja\\source\\repos\\Specflow\\SpecFlowProject\\SpecFlowProject\\InputJson\\Delete.json"))
            {
                jsonDeleteBodyString = str.ReadToEnd();
            }
       }

        [Then(@"delete the record with place id")]
        public void deleteTheRecord()
        {
            client = new RestClient(endPoint);
            request = new RestRequest(Method.DELETE);
            request.Resource = deleteResource;
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(jsonDeleteBodyString.Replace("placeId", postResponseObj.place_id));
            response = client.Execute(request);

            Console.WriteLine(response.Content);
        }

        [Then(@"validate the delete success status as OK")]
        public void ThenValidateTheDeleteSuccessStatusOK()
        {
            deleteResponseObj = apiUtil.Deserialize<DeleteResponse>(response);
            Assert.AreEqual("OK", deleteResponseObj.status);
        }
    }
}
