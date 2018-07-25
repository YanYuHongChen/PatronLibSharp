using System;

namespace PatronLibSharp{
    /// <summary>
    /// 
    /// </summary>
    public class TokensResponse{
        private string AccessToken;
        private string RefreshToken;
        private int ExpiresIn;
        private string Scope;
        private string TokenType;
        private DateTime ExpiresAt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccessToken">Patreon OAuth Access Token</param>
        /// <param name="RefreshToken">Patreon OAuth Refresh Token</param>
        /// <param name="ExpiresIn">Time in seconds</param>
        /// <param name="Scope">Scope of Token</param>
        /// <param name="TokenType">Token type</param>
        public TokensResponse(string AccessToken, string RefreshToken, int ExpiresIn, string Scope, string TokenType){
            this.AccessToken = AccessToken;
            this.RefreshToken = RefreshToken;
            this.ExpiresIn = ExpiresIn;
            this.Scope = Scope;
            ExpiresAt = DateTime.Now.AddSeconds(ExpiresIn);
        }
        /// <summary>
        /// Returns the access Token
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken(){
            return AccessToken;
        }
        /// <summary>
        /// Returns the refresh Token
        /// </summary>
        /// <returns></returns>
        public string GetRefreshToken(){
            return RefreshToken;
        }
        /// <summary>
        /// Returns the amount of time it expires in seconds
        /// </summary>
        /// <returns></returns>
        public int GetExpiresIn(){
            return ExpiresIn;
        }
        /// <summary>
        /// Returns the scope of the TokensResponse
        /// </summary>
        /// <returns></returns>
        public string GetScope(){
            return Scope;
        }
        /// <summary>
        /// Returns the Token Type
        /// </summary>
        /// <returns></returns>
        public string GetTokenType(){
            return TokenType;
        }
    }
}