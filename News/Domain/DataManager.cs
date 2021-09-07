using News.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IItemRepository Items { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IItemRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            Items = serviceItemsRepository;
        }
    }
}
