namespace UserService.Graphql
{
    public record CourierProfileInput
    (
       int? Id,
       string CourierName,
       string PhoneNumber,
       bool? Availability,
       int UserId
    );
}
