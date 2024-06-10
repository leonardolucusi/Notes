using AutoMapper;
using Notes.Domain.DTOs;
using Notes.Domain.Entities;

namespace Notes.Application.Mapping
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>();
        }
    }
}
