﻿using FoodDeliveryDomain.Models;
using HotChocolate.AspNetCore.Authorization;

namespace FoodService.Graphql
{
    public class Mutation
    {
        [Authorize(Roles = new[] { "Manager" })]
        public async Task<Food> AddFoodAsync(
            FoodInput input,
            [Service] FoodDeliveryContext context)
        {

            // EF
            var food = new Food
            {
                Name = input.Name,
                Stock = input.Stock,
                Price = input.Price,
                Created = DateTime.Now
            };

            var ret = context.Foods.Add(food);
            await context.SaveChangesAsync();

            return ret.Entity;
        }
    }

    //[Authorize(Roles = new[] { "Admin", "Manager" })]
    public async Task<Food> UpdateFoodAsync(
            FoodInput input,
            [Service] FoodDeliveryContext context)
    {
        var food = context.Foods.Where(o => o.Id == input.Id).FirstOrDefault();
        if (food != null)
        {
            food.Name = input.Name;
            food.Stock = input.Stock;
            food.Price = input.Price;

            context.Foods.Update(food);
            await context.SaveChangesAsync();
        }


        return await Task.FromResult(food);
    }

    //[Authorize(Roles = new[] { "Manager" })]
    public async Task<Food> DeleteFoodByIdAsync(
        int id,
        [Service] FoodDeliveryContext context)
    {
        var food = context.Foods.Where(o => o.Id == id).FirstOrDefault();
        if (food != null)
        {
            context.Foods.Remove(food);
            await context.SaveChangesAsync();
        }


        return await Task.FromResult(food);
    }

}
