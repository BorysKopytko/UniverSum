namespace UniverSum.API.Identity
{
    public class CustomRegisterRequest
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string MiddleName { get; init; }
        public required string Group { get; init; }
    }
}
