﻿using Notes.Application.Queries.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Application.Queries.Handlers
{
    public class GetPaginationNotesHandler
    {
        private readonly INoteQueryRepository _noteQueryRepository;
        public GetPaginationNotesHandler(INoteQueryRepository noteQueryRepository)
        {
            _noteQueryRepository = noteQueryRepository;
        }

        public async Task<PaginationResult<Note>> Handle(GetPaginationNotesQuery query)
        {
            try
            {
                int pageNumber = query.PageNumber;
                int pageSize = query.PageSize;

                int skip = (pageNumber - 1) * pageSize;

                int totalNotes = await _noteQueryRepository.GetTotalCount();

                var notes = await _noteQueryRepository.GetPaginatedNotes(pageNumber, pageSize);

                return new PaginationResult<Note>
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalNotes,
                    Items = notes
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error retrieving paginated notes: {ex.Message}");
            }
        }
    }
}
