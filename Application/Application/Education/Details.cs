using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Education;

public class Details
{
    public class Query : IRequest<Domain.Education>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Domain.Education>
    {
        private readonly ApplicationDbContext _db;
        public Handler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Domain.Education> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _db.Educations.FindAsync(request.Id);
        }
    }
}
