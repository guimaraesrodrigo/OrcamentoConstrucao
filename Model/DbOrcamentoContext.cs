using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIOrcamento.Model
{
    public partial class DbOrcamentoContext : DbContext
    {
        public DbOrcamentoContext()
        {
        }

        public DbOrcamentoContext(DbContextOptions<DbOrcamentoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClientes> TbClientes { get; set; }
        public virtual DbSet<TbConfiguracao> TbConfiguracao { get; set; }
        public virtual DbSet<TbFuncionarios> TbFuncionarios { get; set; }
        public virtual DbSet<TbOrcamento> TbOrcamento { get; set; }
        public virtual DbSet<TbOrcamentoItem> TbOrcamentoItem { get; set; }
        public virtual DbSet<TbProdutos> TbProdutos { get; set; }
        public virtual DbSet<TbSetor> TbSetor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbClientes>(entity =>
            {
                entity.HasKey(e => e.ICodClientes);

                entity.Property(e => e.ICodClientes)
                    .HasColumnName("iCodClientes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SNomeCliente)
                    .HasColumnName("sNomeCliente")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.STelefone)
                    .HasColumnName("sTelefone")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Semail)
                    .HasColumnName("semail")
                    .HasColumnType("varchar(70)");
            });

            modelBuilder.Entity<TbConfiguracao>(entity =>
            {
                entity.HasKey(e => e.ICodConfiguracao);

                entity.Property(e => e.ICodConfiguracao)
                    .HasColumnName("iCodConfiguracao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IPortaSmtp)
                    .HasColumnName("iPortaSMTP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SEnderecoEmail)
                    .HasColumnName("sEnderecoEmail")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.SFlgUsaSsl)
                    .HasColumnName("sFlgUsaSSL")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.SFlgUsaTls)
                    .HasColumnName("sFlgUsaTLS")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.SSenhaEmail)
                    .HasColumnName("sSenhaEmail")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.SServidorSmtp)
                    .HasColumnName("sServidorSMTP")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<TbFuncionarios>(entity =>
            {
                entity.HasKey(e => e.ICodFuncionario);

                entity.HasIndex(e => e.ICodSetor)
                    .HasName("FK_Funcionario_Setor_idx");

                entity.Property(e => e.ICodFuncionario)
                    .HasColumnName("iCodFuncionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ICodSetor)
                    .HasColumnName("iCodSetor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SNomeFuncionario)
                    .HasColumnName("sNomeFuncionario")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.ICodSetorNavigation)
                    .WithMany(p => p.TbFuncionarios)
                    .HasForeignKey(d => d.ICodSetor)
                    .HasConstraintName("FK_Funcionario_Setor");
            });

            modelBuilder.Entity<TbOrcamento>(entity =>
            {
                entity.HasKey(e => e.ICodOrcamento);

                entity.HasIndex(e => e.ICodCliente)
                    .HasName("fk_TbOrcamento_TbClientes_iCodCliente_idx");

                entity.HasIndex(e => e.ICodOrcamentista)
                    .HasName("fk_TbOrcamento_1_idx");

                entity.Property(e => e.ICodOrcamento)
                    .HasColumnName("iCodOrcamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DDataCadastro)
                    .HasColumnName("dDataCadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDataValidade)
                    .HasColumnName("dDataValidade")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICodCliente)
                    .HasColumnName("iCodCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ICodOrcamentista)
                    .HasColumnName("iCodOrcamentista")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ICodClienteNavigation)
                    .WithMany(p => p.TbOrcamento)
                    .HasForeignKey(d => d.ICodCliente)
                    .HasConstraintName("fk_TbOrcamento_TbClientes_iCodCliente");

                entity.HasOne(d => d.ICodOrcamentistaNavigation)
                    .WithMany(p => p.TbOrcamento)
                    .HasForeignKey(d => d.ICodOrcamentista)
                    .HasConstraintName("fk_TbOrcamento_TBFuncionario_Orcamentista");
            });

            modelBuilder.Entity<TbOrcamentoItem>(entity =>
            {
                entity.HasKey(e => new { e.ICodOrcamento, e.ICodProduto });

                entity.Property(e => e.ICodOrcamento)
                    .HasColumnName("iCodOrcamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ICodProduto)
                    .HasColumnName("iCodProduto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NPreco)
                    .HasColumnName("nPreco")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.NPrecoTotal)
                    .HasColumnName("nPrecoTotal")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.NQuantidade)
                    .HasColumnName("nQuantidade")
                    .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<TbProdutos>(entity =>
            {
                entity.HasKey(e => e.ICodProduto);

                entity.Property(e => e.ICodProduto)
                    .HasColumnName("iCodProduto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NPrecoProduto)
                    .HasColumnName("nPrecoProduto")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.SDscCor)
                    .HasColumnName("sDscCor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SDscProduto)
                    .HasColumnName("sDscProduto")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SDscTamanho)
                    .HasColumnName("sDscTamanho")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<TbSetor>(entity =>
            {
                entity.HasKey(e => e.ICodSetor);

                entity.Property(e => e.ICodSetor)
                    .HasColumnName("iCodSetor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SDscSetor)
                    .HasColumnName("sDscSetor")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SFlgAlmoxarifado)
                    .HasColumnName("sFlgAlmoxarifado")
                    .HasColumnType("varchar(1)");
            });
        }
    }
}
