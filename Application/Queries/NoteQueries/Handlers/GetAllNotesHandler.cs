using AutoMapper;
using Notes.Application.Queries.NoteQueries.Models;
using Notes.Domain.DTOs;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteRepository.QueryRepository;

namespace Notes.Application.Queries.NoteQueries.Handlers
{
    public class GetAllNotesHandler
    {
        private readonly INoteGetAllQueryRepository _noteGetAllQueryRepository;
        private readonly IMapper _mapper;
        public GetAllNotesHandler(INoteGetAllQueryRepository noteGetAllQueryRepository, IMapper mapper)
        {
            _noteGetAllQueryRepository = noteGetAllQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDTO>> Handle(GetAllNotesQuery query)
        {
            var notes = await _noteGetAllQueryRepository.GetAllNotesAsync();
            var noteDTOs = _mapper.Map<IEnumerable<Note>, IEnumerable<NoteDTO>>(notes);

            return noteDTOs;
        }
    }
}
