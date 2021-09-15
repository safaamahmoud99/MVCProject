using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BL.AppServices
{
    public class UserAppService : AppServiceBase
    {
        #region CURD

        public List<ApplicationUserIDentity> GetAllApplicationUserIDentity()
        {
            return TheUnitOfWork.ApplicationUserIDentity.GetAllApplicationUserIDentity();
        }
        public ApplicationUserIDentity GetApplicationUserIDentity(string id)
        {
            if (id =="")
                throw new ArgumentNullException();

            return TheUnitOfWork.ApplicationUserIDentity.GetApplicationUserIDentityById(id);
        }



        public bool SaveNewApplicationUserIDentity(ApplicationUserIDentity ApplicationUserIDentity)
        {
            if (ApplicationUserIDentity == null)
                throw new ArgumentNullException();
            if (ApplicationUserIDentity.Id == null || ApplicationUserIDentity.Address == null ||ApplicationUserIDentity.UserName
                == string.Empty)
                throw new ArgumentException();

            bool result = false;
            if (TheUnitOfWork.ApplicationUserIDentity.Insert(ApplicationUserIDentity))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateApplicationUserIDentity(ApplicationUserIDentity ApplicationUserIDentity)
        {
            if (ApplicationUserIDentity == null)
                throw new ArgumentNullException();
            if (ApplicationUserIDentity.Id == null || ApplicationUserIDentity.Address == null || ApplicationUserIDentity.UserName
                == string.Empty)
                throw new ArgumentException();

            TheUnitOfWork.ApplicationUserIDentity.Update(ApplicationUserIDentity);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteApplicationUserIDentity(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            bool result = false;

            TheUnitOfWork.ApplicationUserIDentity.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckApplicationUserIDentityExists(ApplicationUserIDentity ApplicationUserIDentity)
        {
            if (ApplicationUserIDentity == null)
                throw new ArgumentNullException();
            return TheUnitOfWork.ApplicationUserIDentity.CheckApplicationUserIDentityExists(ApplicationUserIDentity);
        }
        public List<ApplicationUserIDentity> GetUserWhere(Expression<Func<ApplicationUserIDentity, bool>> filter = null, string includeProperties = "")
        {
            return TheUnitOfWork.ApplicationUserIDentity.GetUserWhere(filter, includeProperties);
        }

        
        #endregion

    }
}
