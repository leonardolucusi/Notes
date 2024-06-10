using AutoMapper;
using Notes.Application.Queries.Models;
using Notes.Domain.DTOs;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Application.Queries.Handlers
{
    public class GetAllNotesHandler
    {
        private readonly INoteQueryRepository _noteQueryRepository;
        private readonly IMapper _mapper;
        public GetAllNotesHandler(INoteQueryRepository noteQueryRepository, IMapper mapper)
        {
            _noteQueryRepository = noteQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDTO>> Handle(GetAllNotesQuery query)
        {
            var notes = await _noteQueryRepository.GetAllNotesAsync();
            var noteDTOs = _mapper.Map<IEnumerable<Note>, IEnumerable<NoteDTO>>(notes);

            return (noteDTOs);
        }
    }
}
