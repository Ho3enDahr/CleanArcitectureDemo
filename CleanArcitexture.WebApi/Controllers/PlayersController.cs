using CleanArcitexture.Shared;
using MediatR;
using CleanArcitexture.Application.Features.Players.Commands.CreatePlayer;
using CleanArcitexture.Application.Features.Players.Queries.GetPlayersWithPagination;
using Microsoft.AspNetCore.Mvc;
using CleanArcitexture.Application.Features.Players.Queries.GetAllPlayers;

namespace CleanArcitexture.WebApi.Controllers
{
 
    public class PlayersController : ApiControllerBase
    {
        private readonly IMediator _mediatR;
        public PlayersController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllPlayersDto>>>> Get()
        {
            return await _mediatR.Send(new GetAllPlayersQuery());
        }
    }
}
