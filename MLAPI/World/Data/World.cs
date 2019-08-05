﻿using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.Networking;
using MLAPI.Properties;
using MLAPI.Visual.Rendering;
using MLAPI.World.Base;
using MLAPI.World.Generation;
using ProtoBuf;

namespace MLAPI.World.Data
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    [ProtoContract]
    public class World
    {
        /// <summary>
        /// The dimensions of a single world.
        /// Dimension 0 is the main world, where the players start.
        /// After that, anything goes.
        /// </summary>
        [ProtoMember(1)]
        public static Dictionary<Guid, Dimension> Dimensions { get; set; } = new Dictionary<Guid, Dimension>();

        public static EngineMode Mode { get; set; }

        public static object Data { get; set; }

        /// <summary>
        /// Raised when a dimension is added for the first time.
        /// The Guid is the dimension ID aka where it can be found within <see cref="Dimensions"/>.
        /// </summary>
        public static event EventHandler<Guid> DimensionAdded;

        /// <summary>
        /// Raised when the camera needs to recalibrate for a different dimension.
        /// </summary>
        public static event EventHandler<Guid> ChangeCameraDimension;

        protected World()
        {
        }

        /// <summary>
        /// Adds a dimension to the dimension list properly.
        /// </summary>
        /// <param name="dimension">The dimension to add.</param>
        /// <returns>The dimension ID.</returns>
        public static int AddDimension(Dimension dimension)
        {
            World.Dimensions.Add(dimension.Id, dimension);
            World.DimensionAddedHandler(dimension.Id);
            return World.Dimensions.Count - 1;
        }

        /// <summary>
        /// Used to raise the <see cref="ChangeCameraDimension"/> event.
        /// </summary>
        /// <param name="dimension"></param>
        public static void RaiseChangeCameraDimension(Guid dimensionId)
        {
            ChangeCameraDimension?.Invoke(null, dimensionId);
        }

        /// <summary>
        /// Returns the chunk at the specified chunk location.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public static Chunk GetChunk(Guid dimensionId, int chunkX, int chunkY)
        {
            return World.Dimensions[dimensionId].GetChunk(chunkX, chunkY);
        }

        /// <summary>
        /// Returns the chunk at the specified tile location.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Chunk GetChunkByTile(Guid dimensionId, int x, int y)
        {
            return World.Dimensions[dimensionId].GetChunkForLocation(x, y);
        }

        /// <summary>
        /// Returns a tile in the specified dimension, at the specified location.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Tile GetTile(Guid dimensionId, int x, int y)
        {
            return World.Dimensions[dimensionId][x, y];
        }

        public static Tile GetTile(Point3D location)
        {
            return World.Dimensions[location.DimensionId][location.X, location.Y];
        }

        /// <summary>
        /// Generates a new world with the specified height, width, depth, and world generator.
        /// </summary>
        /// <param name="chunkWidth"></param>
        /// <param name="chunkHeight"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        public static void Initialize(int chunkWidth, int chunkHeight, DimensionGenerator generator, string dimensionName)
        {
            Random r = new Random();
            Guid dimensionId = Guid.NewGuid();
            Dimension firstDim = new Dimension(Lang._1stDimensionName, generator.Generate(chunkWidth, chunkHeight, dimensionName, r, dimensionId), dimensionId);
            RenderInfo.DimensionId = firstDim.Id;
        }

        /// <summary>
        /// Raises the dimension added event.
        /// </summary>
        /// <param name="e"></param>
        public static void DimensionAddedHandler(Guid e)
        {
            DimensionAdded?.Invoke(null, e);
        }
    }
}