﻿using MagicalLifeAPI.Filing;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Action_Menu
{
    /// <summary>
    /// Positioning data for the action menu.
    /// </summary>
    public class ActionMenuLayout
    {
        /// <summary>
        /// The dimensions of the action menu.
        /// </summary>
        public static Rectangle ActionMenuLocation
        {
            get
            {
                switch ((Resolution)SettingsManager.WindowSettings.Settings.Resolution)
                {
                    case Resolution._2560x1440:
                        return ActionMenuLayout2560x1440.ActionMenuLocation;

                    default:
                        return ActionMenuLayout1920x1080.ActionMenuLocation;
                }
            }
        }
    }
}
