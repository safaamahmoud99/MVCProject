using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModel;
using DAL;

namespace BL.AppServices
{
    public class CategoryAppService : AppServiceBase
    {
        #region CURD

        public List<CategoryViewModel> GetAllCategories()
        {

            return Mapper.Map<List<CategoryViewModel>>(TheUnitOfWork.Category.GetAllCategories());
        }
        public CategoryViewModel GetCategory(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return Mapper.Map<CategoryViewModel>(TheUnitOfWork.Category.GetCategoryById(id));
        }



        public bool SaveNewCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
                throw new ArgumentNullException();
            if (categoryViewModel.Name == string.Empty || categoryViewModel.Name == null)
                throw new ArgumentException("Name is empity or null");

            bool result = false;
            var category = Mapper.Map<Category>(categoryViewModel);
            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
                throw new ArgumentNullException();
            if (categoryViewModel.Name == string.Empty || categoryViewModel.Name == null)
                throw new ArgumentException("Name is empity or null");

            var category = Mapper.Map<Category>(categoryViewModel);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCategoryExists(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
                throw new ArgumentNullException();
            if (categoryViewModel.Name == string.Empty || categoryViewModel.Name == null)
                throw new ArgumentException("Name is empity or null");

            Category category = Mapper.Map<Category>(categoryViewModel);
            return TheUnitOfWork.Category.CheckCategoryExists(category);
        }
        #endregion

    }
}
