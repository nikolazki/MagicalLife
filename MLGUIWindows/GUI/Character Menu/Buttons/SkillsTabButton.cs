﻿using MLAPI.Asset;
using MLGUIWindows.Properties;
using MonoGUI.MonoGUI.Reusable;
using MonoGUI.MonoGUI.Reusable.Event;

namespace MLGUIWindows.GUI.Character_Menu.Buttons
{
    /// <summary>
    /// Moves the character menu to the inventory section.
    /// </summary>
    public class SkillsTabButton : MonoButton
    {
        public SkillsTabButton()
            : base(TextureLoader.GuiMenuButton, CharacterMenuLayout.GetSkillsButtonBounds(),
                  true, TextureLoader.FontMainMenuFont12X, Resources.SkillsTab)
        {
            this.ClickEvent += this.SkillsTabButton_ClickEvent;
        }

        private void SkillsTabButton_ClickEvent(object sender, ClickEventArgs e)
        {
            CharacterMenu.Menu.HideAllControls();
            //Show the inventory menu.
            CharacterMenu.Menu.X.Visible = true;
            CharacterMenu.Menu.Skills.Visible = true;
            CharacterMenu.Menu.CharacterName.Visible = true;
            CharacterMenu.Menu.SkillsButton.Visible = true;
            CharacterMenu.Menu.InventoryButton.Visible = true;
        }
    }
}