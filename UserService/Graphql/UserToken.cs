namespace UserService.Graphql
{
    public record UserToken
    (
        string? Token,
        string? Expired,
        string? Message
    );
}
