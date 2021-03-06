﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Xna.Framework;
using PongMono;

namespace PongMonoAndroid
{
    [Activity(Label = "PongMonoAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Game1.Activity = this;
            var game = new Game1();
            SetContentView(game.Window);
            game.Run();
        }
    }
}

