using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCore.CQRS.Queries.DestinationQueries;
using TraversalCore.CQRS.Results.DestinationResults;

namespace TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price

            }).AsNoTracking().ToList();


            return values;

            //Çoğu zamanda okuma işlemi yaptığımız için bu performans kaybına yol açar.İşte bu durumda izleme yapmadan, sadece okunabilir işlemler için AsNoTracking kullanılır.  AsNoTracking kullanıldığında Entity üzerinde değişiklik var mı yok mu  Context tarafından izlenenmez.
        }
    }
}
