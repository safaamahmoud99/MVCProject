using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class FavouriteProductsAppService : AppServiceBase
    {
        #region CURD

        public List<FavouriteProducts> GetAllFavouriteProducts()
        {

            return TheUnitOfWork.FavouriteProducts.GetAllFavouriteProducts();
        }
        public FavouriteProducts GetFavouriteProducts(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            return TheUnitOfWork.FavouriteProducts.GetFavouriteProductsById(id);
        }



        public bool SaveNewFavouriteProducts(FavouriteProducts favouriteProducts)
        {
            if (favouriteProducts == null)
                throw new ArgumentNullException();
            if (favouriteProducts.userId == null || favouriteProducts.userId == string.Empty
                || favouriteProducts.Product == null)
                throw new ArgumentException();

            bool result = false;
            if (TheUnitOfWork.FavouriteProducts.Insert(favouriteProducts))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateFavouriteProducts(FavouriteProducts favouriteProducts)
        {
            if (favouriteProducts == null)
                throw new ArgumentNullException();
            if (favouriteProducts.userId == null || favouriteProducts.userId == string.Empty
                || favouriteProducts.Product == null)
                throw new ArgumentException();

            TheUnitOfWork.FavouriteProducts.Update(favouriteProducts);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteFavouriteProducts(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            bool result = false;

            TheUnitOfWork.FavouriteProducts.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckFavouriteProductsExists(FavouriteProducts favouriteProducts)
        {
            if (favouriteProducts == null)
                throw new ArgumentNullException();

            return TheUnitOfWork.FavouriteProducts.CheckFavouriteProductsExists(favouriteProducts);
        }

        public void AddProductToUserList(string userId, int productId)
        {
            if(userId == null || userId == string.Empty)
                throw new ArgumentException();

            FavouriteProducts newFavList = new FavouriteProducts
            {
                userId = userId,
                productId = productId
            };
            SaveNewFavouriteProducts(newFavList);
        }
        #endregion

    }
}
