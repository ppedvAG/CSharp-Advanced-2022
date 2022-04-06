using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksClient
{
    internal class BookRules : AbstractValidator<Volumeinfo>
    {
        public BookRules()
        {
            RuleFor(x => x.pageCount).GreaterThan(10);
            RuleFor(x => x.title).NotEmpty();
            RuleFor(x => x.description).NotEmpty().WithSeverity(Severity.Warning);
        }
    }
}
