using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }
        public DbSet<SolicitacaoAgg.SolicitacaoCompra> SolicitacaoCompras { get; set; }
        public DbSet<SolicitacaoAgg.Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product = new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira");         

            modelBuilder.Entity<ProdutoAgg.Produto>(b =>
            {
                b.HasData(
                   product
                );

                b.OwnsOne(e => e.Preco).HasData(new
                {
                    ProdutoId = product.Id,
                    Value = Convert.ToDecimal(100)
                });
            });

            //modelBuilder.Entity<ProdutoAgg.Produto>(b =>
            //{
            //    b.HasData(
            //       product
            //    );

            //    b.OwnsOne(e => e.Preco).HasData(new
            //    {
            //        ProdutoId = product.Id,
            //        Value = Convert.ToDecimal(100)
            //    });
            //});

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
            modelBuilder.ApplyConfiguration(new ItemCnfiguration());

            modelBuilder.Ignore<Event>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=SistemaCompraDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
