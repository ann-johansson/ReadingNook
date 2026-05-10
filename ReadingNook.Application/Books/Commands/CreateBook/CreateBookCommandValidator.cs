using FluentValidation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Titel is required")
                .MaximumLength(200).WithMessage("Titel can't exceed 200 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required")
            .MaximumLength(200);

            RuleFor(x => x.TotalPages)
            .GreaterThan(0).WithMessage("Total pages must be greater than 0");

            RuleFor(x => x.Genre)
            .NotEmpty()
            .MaximumLength(50);
        }
    }
}
