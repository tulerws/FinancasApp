using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    /// <summary>
    /// Mapeamento da entidade Movimentação
    /// </summary>
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            //nome da tabela
            builder.ToTable("MOVIMENTACAO");

            //chave primária
            builder.HasKey(m => m.Id);

            //campos da entidade
            builder.Property(m => m.Id)
                .HasColumnName("ID");

            //campos da entidade
            builder.Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            //campos da entidade
            builder.Property(m => m.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(250)
                .IsRequired();

            //campos da entidade
            builder.Property(m => m.Data)
                .HasColumnName("DATA")
                .HasColumnType("date")
                .IsRequired();

            //campos da entidade
            builder.Property(m => m.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            //campos da entidade
            builder.Property(m => m.UsuarioId)
                .HasColumnName("USUARIOID")
                .IsRequired();

            //campos da entidade
            builder.Property(m => m.CategoriaId)
                .HasColumnName("CATEGORIAID")
                .IsRequired();

            //Relacionamento com Categoria
            builder.HasOne(m => m.Categoria) //Movimentação TEM 1 Categoria
                .WithMany(c => c.Movimentacoes) //Categoria TEM Muitas Movimentações
                .HasForeignKey(m => m.CategoriaId) //chave estrangeira
                .OnDelete(DeleteBehavior.NoAction); //regra de exclusão

            //Relacionamento com Usuario
            builder.HasOne(m => m.Usuario) //Movimentação TEM 1 Usuário
                .WithMany(u => u.Movimentacoes) //Usuário TEM Muitas Movimentações
                .HasForeignKey(m => m.UsuarioId) //chave estrangeira
                .OnDelete(DeleteBehavior.NoAction); //regra de exclusão
        }
    }
}
