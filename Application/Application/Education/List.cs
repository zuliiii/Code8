using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Education;

public class List
{
    public class Query : IRequest<List<Domain.Education>>
    {

    }

    public class Handler : IRequestHandler<Query, List<Domain.Education>>
    {
        private readonly ApplicationDbContext _db;
        public Handler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Domain.Education>> Handle(Query request, CancellationToken cancellationToken)
        {

            return await _db.Educations.ToListAsync();
        }
    }
}
