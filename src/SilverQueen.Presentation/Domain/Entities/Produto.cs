using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace SilverQueen.Presentation.Domain.Entities
{
    public class Produto : Notifiable
    {
      

        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public decimal Preco { get;  set; }
        public int Quantidade { get;  set; }

    }
}
