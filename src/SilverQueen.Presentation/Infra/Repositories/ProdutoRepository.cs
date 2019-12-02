using SilverQueen.Presentation.Domain.Entities;
using SilverQueen.Presentation.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverQueen.Presentation.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public List<Produto> Produtos { get; set; }

        public ProdutoRepository()
        {
            Produtos = new List<Produto>();
        }

        public async Task CreateAsync(Produto produto)
        {
             await Task.Run(() => Produtos.Add(produto));
        }

        public async Task UpdateAsync(Produto produto)
        {
            var index = Produtos.FindIndex(x => x.Id.Equals(produto.Id));

            if (index >= 0)
                await Task.Run(() => Produtos[index] = produto);
        }

        public async Task DeleteAsync(Guid id)
        {
            var index = Produtos.FindIndex(x => x.Id.Equals(id));

            if (index >= 0)
                await Task.Run(() => Produtos.RemoveAt(index));
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await Task.FromResult(Produtos);
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var produto = Produtos.FirstOrDefault(x => x.Id.Equals(id));
            return await Task.FromResult(produto);
        }

        public void Dispose()
        {
            Produtos.Clear();
        }
    }
}
