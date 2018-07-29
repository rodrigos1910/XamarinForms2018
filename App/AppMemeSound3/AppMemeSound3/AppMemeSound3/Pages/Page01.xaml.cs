﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMemeSound3.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page01 : ContentPage
	{
        public Page01()
        {
            InitializeComponent();


            SOM.Clicked += TocasMusica;
        }


        private void TocasMusica(object sender, EventArgs args)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("trolololo.mp3");
            //CrossMediaManager.Current.Play("trolololo.mp3");
            player.Play();
        }
    }
 }
