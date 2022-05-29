using LW.IO.Business.Interfaces;
using LW.IO.Business.Models;
using LW.IO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW.IO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppMvcContext context) : base(context)
        {
        }
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _context.Produtos.AsNoTracking()
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _context.Produtos.AsNoTracking()
                .Include(p => p.Fornecedor)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
