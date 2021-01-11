
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data
{
    public interface ICategoryService
    {

        IEnumerable<CategoryModel> GetAllCategoty();

        Task<IEnumerable<CategoryModel>> GetAll_Categoty();

        Task<CategoryModel> GetCategoryById(int? id);

        Task<IEnumerable<CategoryModel>> GetCategoryByCondition(CategoryModel cat);

        Task<string> CreateCategory(CategoryModel cat);

        Task<string> UpdateCategory(CategoryModel cat);

        Task<string> DeleteCategory(int? id);
        
    }
}
