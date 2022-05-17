namespace UserService.Graphql
{
    public record RegisterUser
    (
        string FullName,
        string Email,
        string Username,
        string Password
    );
}
