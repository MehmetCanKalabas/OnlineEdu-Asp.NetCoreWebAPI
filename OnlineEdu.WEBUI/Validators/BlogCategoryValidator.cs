using FluentValidation;
using OnlineEdu.WEBUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WEBUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Kategori adı boş olamaz.");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olmalıdır.");
        }
    }
}
