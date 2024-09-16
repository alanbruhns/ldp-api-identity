using LDPIdentityAPI.Application.Alans;
using LDPIdentityAPI.Application.Alans.Queries.GetAlan;

namespace LDPIdentityAPI.Web.Endpoints;

public class Alans : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetAlan, "{id}");
    }

    public Task<AlanVm> GetAlan(ISender sender, int id)
        => sender.Send(new GetAlanQuery(id));
    

}
