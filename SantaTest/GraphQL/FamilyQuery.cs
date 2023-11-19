using Microsoft.EntityFrameworkCore;
using SantaTest.Data;
using SantaTest.Models;

namespace SantaTest.GraphQL
{
    public class FamilyQuery
    {
        public IEnumerable<Family> GetAllChildren(GiftContext context) => 
            context.Families.Include(family => family.Children).ThenInclude(child => child.Gifts).Include(family => family.Address);
        
        [UseProjection]
        [UseFiltering]
        public IQueryable<Family> GetAllChildrenProjected(GiftContext context) =>
            context.Families;
    }


}
