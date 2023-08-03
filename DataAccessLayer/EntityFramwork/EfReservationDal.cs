using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramwork
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            //Include metodu, Reservation tablosundaki Destination ve AppUser gibi ilişkili tabloları yüklemek için kullanılır.

            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Include(x=>x.AppUser).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                //Include metodu, LINQ sorguları ile birlikte kullanılarak, ilişkili verilerin yüklenmesini sağlar.

                //şehir ismini getirebilmek için yaptık
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
            }
        }
    }
}
