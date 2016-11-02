using RestSharp;
using GameConsoleClient.Helpers.Common;
using System.Collections.Generic;
using System.Text;

namespace GameConsoleClient.Webservice
{
    public class DRestClient
    {
        private static DRestClient instance;

        public static DRestClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DRestClient();
                }
                return DRestClient.instance;
            }
            set { DRestClient.instance = value; }
        }

        public string SignIn(Dictionary<string, string> dictParamenter)
        {
            string result = SendRequest(GameConsoleClient.Helpers.Common.Common.UrlLogin, "Player/SignIn", dictParamenter);
            return result;
        }

        public string SignUp(Dictionary<string, string> dictParamenter)
        {
            string result = SendRequest(GameConsoleClient.Helpers.Common.Common.UrlLogin, "Player/SignUp", dictParamenter);
            return result;
        }

        private string SendRequest(string url, string path, Dictionary<string, string> dictParamenter)
        {
            RestClient client = new RestClient(url) { Encoding = Encoding.UTF8 };

            var restRequest = CreateRestRequest(path, dictParamenter);

            IRestResponse response = client.Execute(restRequest);
            var content = response.Content; // raw content as string
            return content;
        }

        private RestRequest CreateRestRequest(string path, Dictionary<string, string> dictParamenter)
        {
            var request = new RestRequest(path, Method.POST);
            request.AddHeader("Content-Type", "multipart/form-data");
            foreach (var paramenter in dictParamenter)
            {
                request.AddParameter(paramenter.Key, paramenter.Value);
            }
            return request;
        }
    }
}
