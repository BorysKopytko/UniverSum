namespace UniverSum.Client.Identity
{
    public class ResponseModel
    {
        public string TokenType { get; } = "Bearer";
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
