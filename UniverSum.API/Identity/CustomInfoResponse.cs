namespace UniverSum.API.Identity
{
    public class CustomInfoResponse
    {
        public string Email { get; init; }
        public bool IsEmailConfirmed { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
