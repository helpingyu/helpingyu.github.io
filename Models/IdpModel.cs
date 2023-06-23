namespace RestApi.Models
{
    public class IdpModel
    {
        public string Access_Token { get; set; }

        public int Expires_in { get; set; }

        public string Refresh_token { get; set; }

        public int Refresh_expires_in { get; set; }

        public IdpModel(string access_Token, int expires_in, string refresh_token, int refresh_expires_in)
        {
            Access_Token = access_Token;
            Expires_in = expires_in;
            Refresh_token = refresh_token;
            Refresh_expires_in = refresh_expires_in;
        }

        public IdpModel() {
            Access_Token = string.Empty;
            Expires_in = 0;
            Refresh_expires_in = 0;
            Refresh_token = string.Empty;
            
        }
    }
}
