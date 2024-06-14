using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Entities;

namespace Notes.Infra.Data.Mappings
{
    public class NoteMap : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(u => u.Id)
                 .ValueGeneratedOnAdd();

            builder.Property(u => u.Title)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
