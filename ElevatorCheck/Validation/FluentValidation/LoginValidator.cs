using ElevatorCheckAPI.Entity.DTO.Login;
using FluentValidation;

namespace ElevatorCheckAPI.Api.Validation.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");

        }
    }
}
