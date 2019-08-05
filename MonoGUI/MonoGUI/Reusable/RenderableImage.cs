﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Asset;

namespace MonoGUI.MonoGUI.Reusable
{
    /// <summary>
    /// A generic label class.
    /// </summary>
    public class RenderableImage : GuiElement
    {
        private int TextureIndex;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="image"></param>
        /// <param name="isContained">If true, this GUI element is within a container.</param>
        public RenderableImage(Rectangle bounds, string image, bool isContained)
            : base(bounds, int.MinValue, isContained, TextureLoader.FontMainMenuFont12X)
        {
            this.TextureIndex = AssetManager.NameToIndex[image];
        }

        public RenderableImage(Rectangle bounds, int textureId, bool isContained)
            : base(bounds, int.MinValue, isContained, TextureLoader.FontMainMenuFont12X)
        {
            this.TextureIndex = textureId;
        }

        public RenderableImage() : base()
        {
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            int x = containerBounds.X + this.DrawingBounds.X;
            int y = containerBounds.Y + this.DrawingBounds.Y;
            int width = this.DrawingBounds.Width;
            int height = this.DrawingBounds.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            if (width == 0 || height == 0)
            {
                throw new ArgumentException("Width or height cannot be 0");
            }

            spBatch.Draw(AssetManager.Textures[this.TextureIndex], bounds, Color.White);
        }
    }
}