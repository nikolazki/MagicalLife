﻿using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Classes that implements this are responsible for generating the terrain for the specified chunks.
    /// </summary>
    public abstract class TerrainGenerator
    {
        /// <summary>
        /// Should generate the received blank chunks, and return chunks with fully generated terrain.
        /// </summary>
        /// <param name="blankChunks"></param>
        /// <param name="biomeName">The name of the biome that is being worked with.</param>
        /// <returns></returns>
        public abstract Chunk[] GenerateTerrain(Chunk[] blankChunks, string dimensionName, string biomeName);
    }
}
