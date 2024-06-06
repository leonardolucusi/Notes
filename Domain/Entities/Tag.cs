using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Notes.Domain.Entities
{
    public class Tag
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<NoteTag>? NoteTags { get; set; }
        public Tag()
        {
            NoteTags = new List<NoteTag>();
        }
    }
}
