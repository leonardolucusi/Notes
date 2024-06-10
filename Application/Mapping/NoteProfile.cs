using AutoMapper;
using Notes.Domain.DTOs;
using Notes.Domain.Entities;

namespace Notes.Application.Mapping
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDTO>()

            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.NoteTags.Select(nt => new TagDTO
            {
                Id = nt.Tag.Id,
                Name = nt.Tag.Name
            }).ToList()));

            CreateMap<Tag, TagDTO>();
        }
    }
}
