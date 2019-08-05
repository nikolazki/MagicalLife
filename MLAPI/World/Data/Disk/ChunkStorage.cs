﻿using System;
using System.IO;
using MLAPI.DataTypes;
using MLAPI.Networking.Serialization;
using MLAPI.World.Data.Disk.DataStorage;

namespace MLAPI.World.Data.Disk
{
    /// <summary>
    /// Knows how to load and save chunks from every dimension in the world.
    /// </summary>
    public class ChunkStorage
    {
        public ChunkStorage(string saveName)
        {
        }

        /// <summary>
        /// Saves a chunk to disk.
        /// </summary>
        /// <param name="chunk">The chunk to save.</param>
        /// <param name="dimensionId">The ID of the dimension the chunk belongs to.</param>
        internal void SaveChunk(Chunk chunk, Guid dimensionId, AbstractWorldSink sink)
        {
            bool dimensionExists = WorldStorage.DimensionPaths.TryGetValue(dimensionId, out string path);

            if (!dimensionExists)
            {
                throw new DirectoryNotFoundException("Dimension save folder does not exist!");
            }

            sink.Receive(chunk, path + Path.DirectorySeparatorChar + chunk.ChunkLocation.ToString() + ".chunk", dimensionId);
        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within the dimension.</param>
        /// <param name="chunkY">The y position of the chunk within the dimension.</param>
        /// <param name="dimensionId">The ID of the dimension that the chunk belongs to.</param>
        /// <returns></returns>
        internal Chunk LoadChunk(int chunkX, int chunkY, Guid dimensionId)
        {
            return this.LoadChunk(new Point2D(chunkX, chunkY), dimensionId);
        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within the dimension.</param>
        /// <param name="chunkY">The y position of the chunk within the dimension.</param>
        /// <param name="dimensionId">The ID of the dimension that the chunk belongs to.</param>
        /// <returns></returns>
        internal Chunk LoadChunk(Point2D chunkLocation, Guid dimensionId)
        {
            bool dimensionExists = WorldStorage.DimensionPaths.TryGetValue(dimensionId, out string path);

            if (!dimensionExists)
            {
                throw new DirectoryNotFoundException("Dimension save folder does not exist!");
            }

            using (StreamReader sr = new StreamReader(path + Path.DirectorySeparatorChar + chunkLocation.ToString() + ".chunk"))
            {
                return (Chunk)ProtoUtil.TypeModel.DeserializeWithLengthPrefix(sr.BaseStream, null, typeof(Chunk), ProtoBuf.PrefixStyle.Base128, 0);
            }
        }
    }
}