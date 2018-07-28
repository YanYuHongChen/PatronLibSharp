using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace PatronLibSharp{
    /// <summary>
    /// 
    /// </summary>
    public class PatreonOAuth{
        private string GRANT_TYPE_AUTHORIZATION;
        private string GRANT_TYPE_REFRESH;

        private string ClientID;
        private string ClientSecret;
        private string RedirectUri;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientID">Your Patreon API Client ID</param>
        /// <param name="ClientSecret">Your Patreon API Client Secret</param>
        /// <param name="RedirectUri">Your Patreon API Re-direct Uri</param>
        public PatreonOAuth(string ClientID, string ClientSecret, string RedirectUri){
            this.ClientID = ClientID;
            this.ClientSecret = ClientSecret;
            this.RedirectUri = RedirectUri;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizationURL(){
            Dictionary<string, string> parameters = new Dictionary<string, string>{
                { "response_type", "code"},
                { "client_id", ClientID},
                { "redirect_uri", RedirectUri}
                };

            string uri = "";

            try {
                uri = QueryHelpers.AddQueryString(PatreonAPI.BASE_URI + "/oauth2/authorize", parameters);
            }
            catch(Exception ex){
                throw new Exception(ex.ToString());
            }

            return uri;
        }

        public TokensResponse GetTokens(string code){
            Dictionary<string, string> parameters = new Dictionary<string, string>{
                 { "grant_type", GRANT_TYPE_AUTHORIZATION},
                { "code", "code"},
                { "client_id", ClientID},
                 { "client_secret", ClientSecret},
                { "redirect_uri", RedirectUri}
                };

            string uri = "";
            try{
                uri = QueryHelpers.AddQueryString(PatreonAPI.BASE_URI + "/api/oauth2/token", parameters);
                var x = Connect(uri);

                return ToObject<TokensResponse>(x.ToString());
            }
            catch(Exception ex){
                throw new Exception(ex.ToString());
            } 
        }

        public TokensResponse RefreshTokens(string RefreshToken){
            Dictionary<string, string> parameters = new Dictionary<string, string>{
                 { "grant_type", GRANT_TYPE_REFRESH},
                { "client_id", ClientID},
                 { "client_secret", ClientSecret},
                { "redirect_uri", RedirectUri}
                };

            string uri = "";
            try
            {
                uri = QueryHelpers.AddQueryString(PatreonAPI.BASE_URI + "/api/oauth2/token", parameters);
                var x = Connect(uri);

                return ToObject<TokensResponse>(x.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private byte[] Connect(string URI){
            WebClient web = new WebClient();
           return web.DownloadData(URI);
        }

        /// <summary>
        /// De-serialzie JSON to a specified Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        private T ToObject<T>(String str){
            Type type = typeof(T);
            return (T)JsonConvert.DeserializeObject(str,type);
        }
    }
}