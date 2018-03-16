﻿using MagicalLifeGUIWindows.Map;
using MagicalLifeRenderEngine.Main.GUI.Click;

namespace MagicalLifeGUIWindows.GUI.MainMenu
{
    /// <summary>
    /// Handles some main menu stuff.
    /// </summary>
    public static class MainMenu
    {
        private static MainMenuContainer MainMenuID;

        internal static void Initialize()
        {
            MainMenuContainer mainMenu = new MainMenuContainer(true);
            MainMenuID = mainMenu;
            MouseHandler.AddContainer(mainMenu);
        }

        internal static void ToggleMainMenu()
        {
            MenuHandler.DisplayMenu(MainMenuID);
        }
    }
}