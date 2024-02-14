using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWorkPattern.API.Entities;

namespace UnitOfWorkPattern.API.Data.EntitiesMapping;

public sealed class LogMapping : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs");

        builder.HasKey(l => l.Id);  

        builder.Property(l => l.Message)
            .IsRequired(true)
            .HasColumnName("message")
            .HasColumnType("varchar(200)");

        builder.Property(l => l.CreationDate)
            .IsRequired(true)
            .HasColumnName("creation_date")
            .HasColumnType("datetime2");
    }
}
