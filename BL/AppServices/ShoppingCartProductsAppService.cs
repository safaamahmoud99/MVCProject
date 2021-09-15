using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModel;
using DAL;
using BL.Bases;

namespace BL.AppServices
{
    public class ShoppingCartProductsAppService : AppServiceBase
    {
        #region CURD

        public List<ShoppingCartProducts> GetAllShoppingCartProducts()
        {

            return TheUnitOfWork.ShoppingCartProducts.GetAllShoppingCartProducts();
        }
        public ShoppingCartProducts GetShoppingCartProducts(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return TheUnitOfWork.ShoppingCartProducts.GetShoppingCartProductsById(id);
        }



        public bool SaveNewShoppingCartProducts(ShoppingCartProducts ShoppingCartProducts)
        {
            bool result = false;
            if (TheUnitOfWork.ShoppingCartProducts.Insert(ShoppingCartProducts))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateShoppingCartProducts(ShoppingCartProducts ShoppingCartProducts)
        {
            TheUnitOfWork.ShoppingCartProducts.Update(ShoppingCartProducts);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteShoppingCartProducts(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            bool result = false;

            TheUnitOfWork.ShoppingCartProducts.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckShoppingcartproductsExists(ShoppingCartProducts ShoppingCartProducts)
        {
            if (ShoppingCartProducts == null)
                throw new ArgumentNullException();
            return TheUnitOfWork.ShoppingCartProducts.CheckShoppingCartProductsExists(ShoppingCartProducts);
        }
        #endregion

    }
}
