﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCompra.Infra.Data;

namespace SistemaCompra.API.Migrations
{
    [DbContext(typeof(SistemaCompraContext))]
    partial class SistemaCompraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4a5d646-3a99-473e-af1a-7be0526c7f02"),
                            Categoria = 1,
                            Descricao = "Descricao01",
                            Nome = "Produto01",
                            Situacao = 1
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<Guid?>("SolicitacaoCompraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SolicitacaoCompraId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SolicitacaoCompra");
                });

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "Preco", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Preco")
                                .HasColumnType("decimal");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");

                            b1.HasData(
                                new
                                {
                                    ProdutoId = new Guid("c4a5d646-3a99-473e-af1a-7be0526c7f02"),
                                    Value = 100m
                                });
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.HasOne("SistemaCompra.Domain.ProdutoAggregate.Produto", "Produto")
                        .WithMany("Itens")
                        .HasForeignKey("ProductId");

                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", null)
                        .WithMany("Itens")
                        .HasForeignKey("SolicitacaoCompraId");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "TotalGeral", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("TotalGeral")
                                .HasColumnType("decimal");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.CondicaoPagamento", "CondicaoPagamento", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnName("CondicaoPagamento")
                                .HasColumnType("int");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.NomeFornecedor", "NomeFornecedor", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("NomeFornecedor")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.UsuarioSolicitante", "UsuarioSolicitante", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("UsuarioSolicitante")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
