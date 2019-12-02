using MediatR;
using System;

namespace SilverQueen.Presentation.Domain.Commands
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public Guid Id { get; set; }

    }
}
