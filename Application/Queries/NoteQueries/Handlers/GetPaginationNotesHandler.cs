using Notes.Application.Queries.NoteQueries.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteRepository.QueryRepository;

namespace Notes.Application.Queries.NoteQueries.Handlers
{
    public class GetPaginationNotesHandler
    {
        private readonly INoteGetTotalCountQueryRepository _noteGetTotalCountQueryRepository;
        private readonly INoteGetPaginatedQueryRepository _noteGetPaginatedQueryRepository;
        public GetPaginationNotesHandler(INoteGetTotalCountQueryRepository noteGetTotalCountQueryRepository, INoteGetPaginatedQueryRepository noteGetPaginatedQueryRepository)
        {
            _noteGetTotalCountQueryRepository = noteGetTotalCountQueryRepository;
            _noteGetPaginatedQueryRepository = noteGetPaginatedQueryRepository;
        }

        public async Task<PaginationResult<Note>> Handle(GetPaginationNotesQuery query)
        {

            int pageNumber = query.PageNumber;
            int pageSize = query.PageSize;

            int totalNotes = await _noteGetTotalCountQueryRepository.GetTotalCount();

            var notes = await _noteGetPaginatedQueryRepository.GetPaginatedNotes(pageNumber, pageSize);

            return new PaginationResult<Note>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalNotes,
                Items = notes
            };
        }
    }
}
