using ElevatorCheckAPI.Entity.DTO.Structure;
using FluentValidation;

namespace ElevatorCheckAPI.Api.Validation.FluentValidation
{
    public class StructureValidator:AbstractValidator<StructureDTORequest>
    {

        public StructureValidator() 
        {
            RuleFor(x => x.StructureName).NotEmpty().WithMessage("Bina Adı Boş Olamaz");

        }
    }
}
