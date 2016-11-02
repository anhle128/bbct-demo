using GameServer.Common;
using LitJson;
using RestSharp;
using System.Collections;
using System.Net;
using System.Threading.Tasks;


namespace GameServer.ServerWebClient
{
    public class WebClientController
    {
        #region Singleton
        private static WebClientController instance;

        public static WebClientController Instance
        {
            get
            {
                if (instance == null)
                    instance = new WebClientController();

                return instance;
            }
        }
        #endregion

        public async Task<byte[]> DownloadData()
        {
            string url = GetUrlDownLoad();
            CommonLog.Instance.PrintLog("url: " + url);
            byte[] arrByte = DownloadBinary(url);
            return arrByte;
        }

        private string GetUrlDownLoad()
        {
            string url = "";

            var client = new RestClient(Settings.Instance.urlDataVersion);
            var request = new RestRequest("", Method.POST);
            request.AddParameter("version", Settings.Instance.game_verion, ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);

            string result = response.Content;

            Hashtable tableResponse = JsonMapper.ToObject<Hashtable>(result);
            JsonData data = tableResponse["data"] as JsonData;
            JsonData dataStaticDb = data["staticdb_version"];

            url = dataStaticDb["url"].ToString();

            return url;
        }

        private byte[] DownloadBinary(string url)
        {
            using (WebClient myWebClient = new WebClient())
            {
                return myWebClient.DownloadData(url);
            }
        }
    }
}
