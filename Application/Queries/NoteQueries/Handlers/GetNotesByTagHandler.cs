using AutoMapper;
using Notes.Application.Queries.NoteQueries.Models;
using Notes.Domain.DTOs;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteRepository.QueryRepository;

namespace Notes.Application.Queries.NoteQueries.Handlers
{
    public class GetNotesByTagHandler
    {
        private readonly INoteGetNotesByTagQueryRepository _noteGetNotesByTagQueryRepository;
        private readonly IMapper _mapper;

        public GetNotesByTagHandler(INoteGetNotesByTagQueryRepository noteGetNotesByTagQueryRepository, IMapper mapper)
        {
            _noteGetNotesByTagQueryRepository = noteGetNotesByTagQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDTO>> Handle(GetNotesByTagQuery query) 
        {
            var notes = await _noteGetNotesByTagQueryRepository.GetNotesByTag(query.TagId);
            var noteDTOs = _mapper.Map<IEnumerable<Note>, IEnumerable<NoteDTO>>(notes);
            return noteDTOs;
        }
    }
}
