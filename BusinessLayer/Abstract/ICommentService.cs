using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        //comment servisine özel bir metot olduğu için sadece bu serviste yazıldı
        public List<Comment> TGetDestinationById(int id);
        public List<Comment> TGetListCommentWithDestination();
    }
}
