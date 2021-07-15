using RestSharp;
using RestSharp.Serialization.Json;
using SpecFlowProject.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Resuable
{
    class ApiUtil
    {
        public T Deserialize<T>(IRestResponse response)
        {
            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            return jsonDeserializer.Deserialize<T>(response);
        }
    }
}
