using MediatR;
using SilverQueen.Presentation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverQueen.Presentation.Notifications
{
    public class ProdutoActionNotification : INotification
    {
        public Produto Produto { get; set; }
        public EActionNotification Action { get; set; }
    }
}
