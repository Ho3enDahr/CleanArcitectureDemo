using CleanArcitexture.Domain.Common;
using CleanArcitexture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Features.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerEvent:BaseEvent
    {
        public Player  Player { get; set; }
        public UpdatePlayerEvent(Player player) {
            Player = player;
        }
    }
}
