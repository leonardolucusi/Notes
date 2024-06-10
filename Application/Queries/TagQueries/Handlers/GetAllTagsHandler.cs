using AutoMapper;
using Notes.Application.Queries.TagQueries.Models;
using Notes.Domain.DTOs;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository;

namespace Notes.Application.Queries.TagQueries.Handlers
{
    public class GetAllTagsHandler
    {
        private readonly ITagGetAllQueryRepository _tagGetAllQueryRepository;
        private readonly IMapper _mapper;
        public GetAllTagsHandler(ITagGetAllQueryRepository tagGetAllQueryRepository, IMapper mapper)
        {
            _tagGetAllQueryRepository = tagGetAllQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDTO>> Handle(GetAllTagsQuery query)
        {
            var tag = await _tagGetAllQueryRepository.GetAllTagsAsync();
            var tagDTOs = _mapper.Map<IEnumerable<TagDTO>>(tag);
            return tagDTOs;
        }

    }
}
