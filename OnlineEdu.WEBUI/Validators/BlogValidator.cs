using FluentValidation;
using OnlineEdu.WEBUI.DTOs.BlogDtos;

namespace OnlineEdu.WEBUI.Validators
{
    public class BlogValidator : AbstractValidator<CreateBlogDto>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı boş olamaz.");
            RuleFor(x => x.Content).MinimumLength(30).WithMessage("Blog içeriği en az 5 karakter olmalıdır.");
        }
    }
}
