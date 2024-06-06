using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;

namespace Notes.Infra
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd(); //Gera o ID automaticamente, nao sendo necessario passar ID no CREATE da camada de Presentation
            
            modelBuilder.Entity<Tag>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<NoteTag>()
            .HasKey(nt => new { nt.NoteId, nt.TagId });

            modelBuilder.Entity<NoteTag>()
                .HasOne(nt => nt.Note)
                .WithMany(n => n.NoteTags)
                .HasForeignKey(nt => nt.NoteId);

            modelBuilder.Entity<NoteTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NoteTags)
                .HasForeignKey(nt => nt.TagId);
        }
    }
}
