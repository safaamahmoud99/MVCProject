using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class OrderedProductsAppService : AppServiceBase
    {
        #region CURD

        public List<OrderedProducts> GetAllOrderedProducts()
        {

            return TheUnitOfWork.OrderedProducts.GetAllOrderedProducts();
        }
        public OrderedProducts GetOrderedProducts(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            return TheUnitOfWork.OrderedProducts.GetOrderedProductsById(id);
        }



        public bool SaveNewOrderedProducts(OrderedProducts orderedProducts)
        {
            if (orderedProducts == null)
                throw new ArgumentNullException();

            bool result = false;
            if (TheUnitOfWork.OrderedProducts.Insert(orderedProducts))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrderedProducts(OrderedProducts orderedProducts)
        {
            if (orderedProducts == null)
                throw new ArgumentNullException();

            TheUnitOfWork.OrderedProducts.Update(orderedProducts);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrderedProducts(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            bool result = false;

            TheUnitOfWork.OrderedProducts.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderedProductsExists(OrderedProducts orderedProducts)
        {
            if (orderedProducts == null)
                throw new ArgumentNullException();

            return TheUnitOfWork.OrderedProducts.CheckOrderedProductsExists(orderedProducts);
        }
        #endregion

    }
}
