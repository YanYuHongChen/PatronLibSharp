using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;

namespace PatronLibSharp{
    /// <summary>
    /// 
    /// </summary>
    public class PatreonOAuth<E>{
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

        }

        public TokensResponse RefreshTokens(string RefreshToken)
        {

        }

        private E toObject(String str, Class<E> clazz){
            return gson.fromJson(str, clazz);
        }
    }
}