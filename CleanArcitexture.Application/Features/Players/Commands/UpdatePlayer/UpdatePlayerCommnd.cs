using AutoMapper;
using CleanArcitexture.Application.Common.Mapping;
using CleanArcitexture.Application.Interfaces.Repositories;
using CleanArcitexture.Domain.Entities;
using CleanArcitexture.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArcitexture.Application.Features.Players.Commands.UpdatePlayer
{
    public record UpdatePlayerCommnd : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    internal class UpdatePlayerCommndHandler : IRequestHandler<UpdatePlayerCommnd, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdatePlayerCommndHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdatePlayerCommnd updatePlayerCommnd, CancellationToken cancellationToken)
        {
            var player = await _unitOfWork.Repository<Player>().GetByIdAsync(updatePlayerCommnd.Id);
            if (player != null)
            {
                player.BirthDate = updatePlayerCommnd.BirthDate;
                player.Name = updatePlayerCommnd.Name;
                player.PhotoUrl = updatePlayerCommnd.PhotoUrl;
                player.ShirtNo = updatePlayerCommnd.ShirtNo;

                await _unitOfWork.Repository<Player>().UpdateAsync(player);
                player.AddDomainEvent(new UpdatePlayerEvent(player));
                await _unitOfWork.Save(cancellationToken);
                return await Result<int>.SuccessAsync(updatePlayerCommnd.Id, "Player Updated");
            }
            else
            {
                return await Result<int>.FailureAsync("Player not found");
            }

        }
    }
}
