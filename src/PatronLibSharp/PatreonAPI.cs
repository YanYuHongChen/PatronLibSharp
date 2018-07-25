using System;

namespace PatronLibSharp{

    public class PatreonAPI{
        public static string BASE_URI = "https://www.patreon.com";

        private string AccessToken;
        
        public PatreonAPI(string AccessToken){
            this.AccessToken = AccessToken;
        }


    }
}