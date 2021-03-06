using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Domain.Entities;

namespace News.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextFileds> GetTextFields();
        TextFileds GetTextFieldById(Guid id);
        TextFileds GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextFileds entity);
        void DeleteTextField(Guid id);
    }
}
