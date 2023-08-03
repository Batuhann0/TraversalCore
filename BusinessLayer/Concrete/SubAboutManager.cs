using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {

        ISubAboutDal _subaboutDal;

        public SubAboutManager(ISubAboutDal subaboutDal)
        {
            _subaboutDal = subaboutDal;
        }

        public void TAdd(SubAbout t)
        {
            _subaboutDal.Insert(t);
        }

        public void TDelete(SubAbout t)
        {
            _subaboutDal.Delete(t);

        }

        public SubAbout TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> TGetList()
        {
            return _subaboutDal.GetList();
        }

        public void TUpdate(SubAbout t)
        {
            _subaboutDal.Update(t);

        }
    }
}
