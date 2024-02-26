
using System.Security.Cryptography.X509Certificates;
using iService.Models;
using iService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iService.Data.Mappings
{
    public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("Collaborator");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            builder.Property(x => x.Telephone)
                .IsRequired()
                .HasColumnName("Telephone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            builder.Property(x => x.FunctionId)
                .IsRequired()
                .HasColumnName("FunctionId")
                .HasColumnType("int");
            builder.Property(x => x.Salary)
                .IsRequired()
                .HasColumnName("Salary")
                .HasColumnType("float");
            builder.Property(x => x.SectorId)
                .IsRequired()
                .HasColumnName("SectorId")
                .HasColumnType("int");
            builder
                .HasIndex(x => x.Telephone, "UQ_Collaborator_Telephone")
                .IsUnique();
            builder
                .HasOne(x => x.FunctionId)
                .WithMany(x => x.Collaborators)
                .HasConstraintName("FK_Collaborator_FunctionId")
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.SectorId)
                .WithMany(x => x.Collaborators)
                .HasConstraintName("FK_Collaborator_SectorId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}