using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Kapitoshka3.Models.Node.Domain.ValueObject;
using Npgsql.Internal;

namespace Kapitoshka3.Models.Node.Persistence
{
    using Kapitoshka3.Models.Node.Domain.Entity;
    // Класс по преобразованию Парамертов в ValueObject 
    public class NodeConfig : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.ToTable("Kapitoshka");

            var nameConverter = new ValueConverter<Name, string>(
                v => v.Value,
                v => new Name(v));

            var quentityConverter = new ValueConverter<Quentity, Int32>(
                v => v.Value,
                v => new Quentity(v));

            var parentIdConverter = new ValueConverter<ParentId, Int32>(
                v => v.Value,
                v => new ParentId(v));

            builder
            .Property(p => p.Name)
                .HasConversion(nameConverter)
                .HasColumnName("Name")
                .HasColumnType("text")
                .IsRequired();

            builder
            .Property(p => p.Quentity)
                .HasConversion(quentityConverter)
                .HasColumnName("Quentity")
                .HasColumnType("int")
                .IsRequired();

            builder
            .Property(p => p.ParentId)
                .HasConversion(parentIdConverter)
                .HasColumnName("ParentId")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
