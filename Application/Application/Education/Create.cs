using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Education;

public class Create
{
    public class Command : IRequest
    {
        public Domain.Education Education { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly ApplicationDbContext _db;
        public Handler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            _db.Educations.Add(request.Education);

            await _db.SaveChangesAsync();
        }
    }
}
