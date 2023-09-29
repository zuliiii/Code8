using AutoMapper;
using Infrastructure;
using MediatR;

namespace Application.Education;

public class Edit
{
    public class Command : IRequest
    {
        public Domain.Education Education { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var education = await _db.Educations.FindAsync(request.Education.Id);

            _mapper.Map(request.Education, education);

            await _db.SaveChangesAsync();
        }
    }
}
