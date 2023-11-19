using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SantaTest.Data;
using SantaTest.Models;
using System.Security.Cryptography.Xml;

namespace SantaTest.GraphQL
{
    public class FamilyMutation
    {
        public async Task<AddGiftPayload> AddGift(GiftContext context, AddGiftRequest request)
        {
            Family family;
            // Look up the family
            family = await context.Families.Include(family => family.Children).
                ThenInclude(child => child.Gifts).
                FirstOrDefaultAsync(family => family.Name == request.FamilyName);
                
            if (family == null)
            {
                family = new Family
                {
                    Name = request.FamilyName
                };
            }
            
            // Look up the child in family
            var child = family.Children.FirstOrDefault(child => child.Name == request.ChildName);

            if (child == null)
            {
                child = new Child
                {
                    Name = request.ChildName
                };
                family.Children.Add(child);
            }

            // Add the gift to the child
            child.Gifts.Add(new Gift
            {
                Name = request.GiftName,
                Description = request.GiftDescription
            });

            // Save the changes async
            await context.SaveChangesAsync();

            return new AddGiftPayload { Error = "None" };
        }
    }
}
