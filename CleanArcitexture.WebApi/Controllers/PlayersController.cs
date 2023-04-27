using CleanArcitexture.Shared;
using MediatR;
using CleanArcitexture.Application.Features.Players.Commands.CreatePlayer;
using CleanArcitexture.Application.Features.Players.Queries.GetPlayersWithPagination;
using Microsoft.AspNetCore.Mvc;
using CleanArcitexture.Application.Features.Players.Queries.GetAllPlayers;
using CleanArcitexture.Application.Features.Players.Commands.UpdatePlayer;

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
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreatePlayerCommand command)
        {
            return await _mediatR.Send(command);
        }
        [HttpPut]
        public async  Task<ActionResult<Result<int>>> Update(int id, UpdatePlayerCommnd commnd)
        {
            return await _mediatR.Send(commnd);
        }
    }
}
