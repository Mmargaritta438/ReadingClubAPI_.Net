﻿using ReadingClubSPI_.Net.BusinessReadClBookLayer.Models.ReadingClBook;

namespace ReadingClubSPI_.Net.BusinessReadClBookLayer.Infrastructure.Validators.ReadingClubBook
{
    public class UpdateReadingClBookValidator : AbstractValidator<UpdateReadingClBook>
    {
        public UpdateReadingClBookValidator()
        {
            RuleFor(dto => dto.Isbn).NotEmpty().Length(13);
            RuleFor(dto => dto.Title).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.Genre).NotEmpty().MaximumLength(50);
            RuleFor(dto => dto.Description).MaximumLength(500);
            RuleFor(dto => dto.Author).NotEmpty().MaximumLength(100);
            RuleFor(dto => dto.IssuedDate).NotEmpty().LessThanOrEqualTo(dto => dto.ReturnDate);
            RuleFor(dto => dto.ReturnDate).NotEmpty().GreaterThanOrEqualTo(dto => dto.IssuedDate);
        }
    }
}