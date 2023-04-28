using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Domain;
using Vectra.Avaliacao.Backend.Application.Interfaces;

namespace Vectra.Avaliacao.Backend.Context
{
    public class EFContext : DbContext, IEFContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }


    }
}
