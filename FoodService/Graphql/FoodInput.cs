namespace FoodService.Graphql
{
    public record FoodInput
   (
        int? Id,
        string Name,
        int Stock,
        double Price
    );
}
