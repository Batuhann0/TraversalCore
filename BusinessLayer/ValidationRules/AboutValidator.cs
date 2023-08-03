﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel seçiniz");
            RuleFor(x => x.Description).MinimumLength(30).WithMessage("Lütfen en az 30 karakterlik açıklama giriniz");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Lütfen açıklamayı kısaltın");

        }
    }
}
