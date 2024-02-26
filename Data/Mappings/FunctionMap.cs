
using System.Security.Cryptography.X509Certificates;
using iService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iService.Data.Mappings
{
    public class FunctionMap : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable("Function");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            builder
                .HasIndex(x => x.Name, "UQ_Function_Name")
                .IsUnique();            
        }
    }
}