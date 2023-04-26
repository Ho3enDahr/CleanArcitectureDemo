using CleanArcitexture.Application.Common.Mapping;
using CleanArcitexture.Domain.Entities;

namespace CleanArcitexture.Application.Features.Players.Queries.GetPlayersWithPagination
{
    public class GetPlayersWithPaginationDto:IMapFrom<Player>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int ShirtNo { get; init; }
        public int HeightInCm { get; init; }
        public string FacebookUrl { get; init; }
        public string TwitterUrl { get; init; }
        public string InstagramUrl { get; init; }
        public int DisplayOrder { get; init; }
    }
}