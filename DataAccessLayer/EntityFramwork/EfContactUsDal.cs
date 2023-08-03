using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramwork
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            using (var c = new Context())
            {
                var values = c.ContactUses.Find(id);
                values.MessageStatus = false;
                c.SaveChanges();
            }
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (var c = new Context())
            {
                var values = c.ContactUses.Where(x => x.MessageStatus == false).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var c = new Context())
            {
                var values = c.ContactUses.Where(x => x.MessageStatus == true).ToList();
                return values;
            }
        }
    }
}
