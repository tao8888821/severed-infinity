﻿using System;
using System.Linq;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using SIEngine.GUI;
using System.Drawing;
using System.Drawing.Imaging;
using SIEngine.BaseGeometry;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SI.GUI;
using SI.Properties;
using SI.Other;
using SIEngine.Logging;

namespace SI
{
    public class GameWindow : Window
    {
        public MainMenu Menu { get; set; }
        public IngameMenu GameMenu { get; set; }
        public WindowState State { get; set; }

        public GameWindow()
        {
            int width = Settings.Default.ResolutionX;
            int height = Settings.Default.ResolutionY;
            Initialize(width, height, GameplayConstants.WindowName);

            LogManager.WriteInfo("Main window created successfully.");
        }

        protected override void Draw()
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 27)
            {
                if (GameMenu != null)
                {
                    if (State == WindowState.Game)
                        GameMenu.Show();
                    else if (State == WindowState.InGameMenu)
                    {
                        GameMenu.Hide();
                        State = WindowState.Game;
                    }
                }
            }
        }
    }
}