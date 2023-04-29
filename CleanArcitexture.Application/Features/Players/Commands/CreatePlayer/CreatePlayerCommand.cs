using AutoMapper;
using CleanArcitexture.Application.Common.Mapping;
using CleanArcitexture.Application.Interfaces.Repositories;
using CleanArcitexture.Domain.Entities;
using CleanArcitexture.Shared;
using MediatR;


namespace CleanArcitexture.Application.Features.Players.Commands.CreatePlayer
{
    public record CreatePlayerCommand:IRequest<Result<int>>,IMapFrom<Player>
    {
        public string Name { get; set; }
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
    }
    internal class CreatePlayerCommandHandler:IRequestHandler<CreatePlayerCommand,Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreatePlayerCommand command , CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                Name = command.Name,
                ShirtNo = command.ShirtNo,
                PhotoUrl = command.PhotoUrl,
                BirthDate = command.BirthDate,
                ClubId = 3,
                CountryId = 2,
                CreateDate = DateTime.Now,
                DisplayOrder = 1,
                FacebookUrl = "sss",
                InstagramUrl = "aa",
                PlayerPositionId = 1,
                HeightInCm = 0,
                TwitterUrl = "A"
            };

            await _unitOfWork.Repository<Player>().AddAsync(player);
            player.AddDomainEvent(new PlayerCreatedEvent(player));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(player.Id, "Player Created.");
        }
    }
}
