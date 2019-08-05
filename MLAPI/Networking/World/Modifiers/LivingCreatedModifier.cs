﻿using MLAPI.Components;
using MLAPI.Entity;
using MLAPI.World.Data;
using ProtoBuf;

namespace MLAPI.Networking.World.Modifiers
{
    /// <summary>
    /// Used to spawn a creature in the world in a multiplayer game.
    /// </summary>
    [ProtoContract]
    public class LivingCreatedModifier : AbstractWorldModifier
    {
        [ProtoMember(1)]
        public Living Living { get; private set; }

        public LivingCreatedModifier(Living living)
        {
            this.Living = living;
        }

        public LivingCreatedModifier()
        {
            //Protobuf-net constructor.
        }

        public override void ModifyWorld()
        {
            ComponentSelectable livingData = this.Living.GetExactComponent<ComponentSelectable>();
            Chunk chunk = MLAPI.World.Data.World.GetChunkByTile(this.Living.DimensionId, livingData.MapLocation.X, livingData.MapLocation.Y);
            chunk.Creatures.Add(this.Living.Id, this.Living);
        }
    }
}