using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Repositories.EntityFramework
{
    public class EFItemRepository     : IItemRepository
    {
        private readonly AppDbContext context;
        public EFItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Item> GetServiceItems()
        {
            return context.Items;
        }

        public Item GetServiceItemById(Guid id)
        {
            return context.Items.FirstOrDefault(x => x.Id == id);
        }

        public void SaveServiceItem(Item entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid id)
        {
            context.Items.Remove(new Item() { Id = id });
            context.SaveChanges();
        }
    }
}
