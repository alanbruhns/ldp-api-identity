using LDPIdentityAPI.Application.Common.Interfaces;

namespace LDPIdentityAPI.Application.Alans.Queries.GetAlan;

public record GetAlanQuery : IRequest<AlanVm>
{
    public GetAlanQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}

public class GetAlanQueryValidator : AbstractValidator<GetAlanQuery>
{
    public GetAlanQueryValidator()
    {
    }
}

public class GetAlanQueryHandler : IRequestHandler<GetAlanQuery, AlanVm>
{
    private readonly IApplicationDbContext _context;

    public GetAlanQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AlanVm> Handle(GetAlanQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() => new AlanVm() {  Id = request.Id });
    }
}
