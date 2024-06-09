using Notes.Application.Queries.Models;
using Notes.Domain.DTOs;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Application.Queries.Handlers
{
    public class GetAllNotesHandler
    {
        private readonly INoteQueryRepository _noteQueryRepository;
        public GetAllNotesHandler(INoteQueryRepository noteQueryRepository)
        {
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<IEnumerable<NoteDTO>> Handle(GetAllNotesQuery query)
        {
            var notes = await _noteQueryRepository.GetAllNotesAsync();

            var noteDTOs = notes.Select(n => new NoteDTO
            {
                Id = n.Id,
                Title = n.Title,
                Tags = n.NoteTags.Select(nt => new TagDTO
                {
                    Id = nt.Tag.Id,
                    Name = nt.Tag.Name
                }).ToList()
            }).ToList();

            return noteDTOs;
        }
    }
}
