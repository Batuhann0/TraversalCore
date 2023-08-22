
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Başlığı boş geçmeyin");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin");

            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
        }
    }
}
