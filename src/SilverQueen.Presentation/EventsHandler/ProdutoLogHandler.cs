using MediatR;
using SilverQueen.Presentation.Notifications;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SilverQueen.Presentation.EventsHandler
{
    public class ProdutoLogHandler : INotificationHandler<ProdutoActionNotification>
    {
        public Task Handle(ProdutoActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
              {
                  Debug.WriteLine($"O produto {notification.Produto.Id} {notification.Produto.Nome} {notification.Produto.Preco} {notification.Produto.Quantidade} {notification.Action.ToString()}");
              });
        }
    }
}
