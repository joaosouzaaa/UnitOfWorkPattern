using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWorkPattern.API.Entities;

namespace UnitOfWorkPattern.API.Data.EntitiesMapping;

public sealed class ClientMapping : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired(true)
            .HasColumnName("name")
            .HasColumnType("varchar(100)");

        builder.Property(c => c.Age)
            .IsRequired(true)
            .HasColumnName("age")
            .HasColumnType("int");

        builder.Property(c => c.Balance)
            .IsRequired(true)
            .HasColumnName("balance")
            .HasColumnType("decimal(18, 2)");
    }
}
