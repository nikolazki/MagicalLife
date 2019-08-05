﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLAPI.Asset;
using MLAPI.Visual.Rendering;
using static MLAPI.Visual.Rendering.SimpleTextRenderer;

namespace MonoGUI.MonoGUI.Reusable
{
    public class ActionButton : MonoButton
    {
        protected int SelectedTextureId { get; set; }

        public bool IsSelected { get; set; }

        protected int CorrectTextureId
        {
            get
            {
                return this.IsSelected ? this.SelectedTextureId : this.TextureId;
            }
        }

        protected ActionButton(string imageName, Microsoft.Xna.Framework.Rectangle displayArea, bool isContained, string font, string text = "") : base(imageName, displayArea, isContained, font, text)
        {
        }

        protected ActionButton(string imageName, Microsoft.Xna.Framework.Rectangle displayArea, bool isContained, string text = "") : base(imageName, displayArea, isContained, text)
        {
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            Rectangle location;
            int x = this.DrawingBounds.X + containerBounds.X;
            int y = this.DrawingBounds.Y + containerBounds.Y;
            location = new Rectangle(x, y, this.DrawingBounds.Width, this.DrawingBounds.Height);
            spBatch.Draw(AssetManager.Textures[this.CorrectTextureId], location, Color.White);
            SimpleTextRenderer.DrawString(this.Font, this.Text, location, Alignment.Center, Color.White, spBatch, RenderLayer.Gui);
        }
    }
}