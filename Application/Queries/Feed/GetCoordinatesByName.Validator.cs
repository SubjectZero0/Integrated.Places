using FluentValidation;

namespace Application.Queries.Feed
{
    internal sealed class GetCoordinatesByNameValidator : AbstractValidator<GetCoordinatesByName>
    {
        public GetCoordinatesByNameValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Place Name is Required.");

            RuleFor(x => x.Country)
                .MaximumLength(2)
                .MinimumLength(2)
                .When(x => !string.IsNullOrEmpty(x.Country))
                .WithMessage("Country must be empty or have 2 characters.");

            RuleFor(x => x.Language)
                .Must((x, language) => language is "ru" or "en")
                .When(x => !string.IsNullOrEmpty(x.Language))
                .WithMessage("Language has to either be 'ru', or 'en'(default).");
        }
    }
}