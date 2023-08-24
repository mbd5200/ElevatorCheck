using ElevatorCheckAPI.Entity.DTO.User;
using FluentValidation;

namespace ElevatorCheckAPI.Api.Validation.FluentValidation
{
    public class UserRegisterValidation : AbstractValidator<UserRequestDTO>
    {
        public UserRegisterValidation()
        {
            RuleFor(q => q.AdiSoyadi).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullancı Adı Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.Firma).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.Tel).NotEmpty().WithMessage("Telefon Boş Olamaz");
        }
    }
}
