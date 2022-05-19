namespace UserService.Graphql
{
    public record CourierInput
    (
       int? Id,
       string CourierName,
       string PhoneNumber
    );
}
