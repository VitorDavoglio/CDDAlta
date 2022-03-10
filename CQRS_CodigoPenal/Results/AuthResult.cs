namespace CQRS_CodigoPenal.Results
{
    public class AuthResult
    {
        public AuthResult(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
