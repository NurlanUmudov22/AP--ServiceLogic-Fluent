using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Intro.DTOs.Sliders
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }

        public IFormFile UploadImage { get; set; }

    }


    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator() 
        {
            RuleFor(m => m.Title).NotNull().WithMessage("Title is required");
            RuleFor(m => m.Title).NotNull().NotEmpty();
        }

    }

}
