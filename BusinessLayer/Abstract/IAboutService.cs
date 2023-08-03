using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    //her bir entity için service oluşturmamızın sebebi o entitye özel bir metot tanımlayabiliriz
    public interface IAboutService :IGenericService<About>
    {
    }
}
