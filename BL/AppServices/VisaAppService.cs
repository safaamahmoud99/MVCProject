using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;

namespace BL.AppServices
{
    public class VisaAppService : AppServiceBase
    {
        #region CURD

        public List<VisaViewModel> GetAllVisas()
        {

            return Mapper.Map<List<VisaViewModel>>(TheUnitOfWork.Visa.GetAllVisa());
        }
        public VisaViewModel GetVisa(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return Mapper.Map<VisaViewModel>(TheUnitOfWork.Visa.GetVisaById(id));
        }



        public bool SaveNewVisa(VisaViewModel VisaViewModel)
        {
            if (VisaViewModel == null)
                throw new ArgumentNullException();
            if (VisaViewModel.Id <0 || VisaViewModel.Number== string.Empty)             
                throw new ArgumentException();

            bool result = false;
            var Visa = Mapper.Map<Visa>(VisaViewModel);
            if (TheUnitOfWork.Visa.Insert(Visa))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateVisa(VisaViewModel VisaViewModel)
        {
            if (VisaViewModel == null)
                throw new ArgumentNullException();
            if (VisaViewModel.Id < 0 || VisaViewModel.Number == string.Empty)
                throw new ArgumentException();

            var Visa = Mapper.Map<Visa>(VisaViewModel);
            TheUnitOfWork.Visa.Update(Visa);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteVisa(int id)
        {

            if (id < 0)
                throw new ArgumentOutOfRangeException();
            bool result = false;

            TheUnitOfWork.Visa.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckVisaExists(VisaViewModel VisaViewModel)
        {
            if (VisaViewModel == null)
                throw new ArgumentNullException();
            Visa Visa = Mapper.Map<Visa>(VisaViewModel);
            return TheUnitOfWork.Visa.CheckVisaExists(Visa);
        }
        #endregion

    }
}
