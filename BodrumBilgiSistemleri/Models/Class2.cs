using System.Collections.Generic;
using BodrumBilgiSistemleri.Models;
using Newtonsoft.Json;

namespace GifToolz.Models
{
    public class Captcha
    {
        public static void Validate()
        {
            var client = new System.Net.WebClient();
            var CLIENT_ID = "L4UK14EMS0MCEZOVVUYX2UO5ULFHJN3EHOFVQFSW0Z1MSFSR";
            var CLIENT_SECRET = "YKJB0JRFDPPSGTHALFOEP5O1NDDATHKQ2IZ5RO2GOX452SFA";

            var API_ENDPOINT = "https://api.foursquare.com/v2/venues/search" +
                               "?client_id=CLIENT_ID" +
                               "&client_secret=CLIENT_SECRET" +
                               "&v=20130816" +
                               "&ll=LATLON" +
                               "&query=cafe" +
                               "&radius=100000" +
                               "&callback=?";
            //  Todo:Replace leri değiştir.Gelen stringi objeye ata veritabanına kaydet.
            API_ENDPOINT.Replace("CLIENT_ID", CLIENT_ID).Replace("CLIENT_SECRET", CLIENT_SECRET).Replace("LATLON", "37.0341, 27.4207");

            var serverResponseString = client.DownloadString(API_ENDPOINT);

            var rootObj = JsonConvert.DeserializeObject<Rootobject>(serverResponseString);

            //  return captchaResponse;
        }

        [JsonProperty("success")]
        public bool Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private bool m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}


