namespace UserService.Graphql
{
    public record ProfileInput
    (
        int? Id,
        int UserId,
        string Name,
        string Address,
        string City,
        string Phone
     );
}
