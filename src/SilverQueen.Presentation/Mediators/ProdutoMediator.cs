using MediatR;
using SilverQueen.Presentation.Domain.Commands;
using SilverQueen.Presentation.Domain.Entities;
using SilverQueen.Presentation.Infra.Contracts;
using SilverQueen.Presentation.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SilverQueen.Presentation.Mediators
{
    public class ProdutoMediator : 
        IRequestHandler<ProdutoCreateCommand, string>, 
        IRequestHandler<ProdutoUpdateCommand, string>, 
        IRequestHandler<ProdutoDeleteCommand, string>

    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _repository;

        public ProdutoMediator(IMediator mediator, IProdutoRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Preco = request.Preco,
                Quantidade = request.Quantidade
            };

            await _repository.CreateAsync(produto);

            await _mediator.Publish(new ProdutoActionNotification { Produto = produto, Action = EActionNotification.Criado});

            return await Task.FromResult("Produto Criado com sucesso");
        }

        public async Task<string> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Id = request.Id,
                Nome = request.Nome,
                Preco = request.Preco,
                Quantidade = request.Quantidade
            };

            await _repository.CreateAsync(produto);

            await _mediator.Publish(new ProdutoActionNotification { Produto = produto, Action = EActionNotification.Alterado });

            return await Task.FromResult("Produto alterado com sucesso");
        }

        public async Task<string> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id);

            await _mediator.Publish(new ProdutoActionNotification { Produto = produto, Action = EActionNotification.Excluido });

            return await Task.FromResult("Produto excluido com sucesso");
        }
    }
}
