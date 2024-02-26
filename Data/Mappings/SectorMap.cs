
using iService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iService.Data.Mappings
{
    public class SectorMap : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sector");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
        }
    }
}