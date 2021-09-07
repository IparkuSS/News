using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace News.Domain.Repositories.Abstract
{
    public interface IItemRepository
    {
        IQueryable<Item> GetServiceItems();
        Item GetServiceItemById(Guid id);
        void SaveServiceItem(Item entity);
        void DeleteServiceItem(Guid id);
    }
}
