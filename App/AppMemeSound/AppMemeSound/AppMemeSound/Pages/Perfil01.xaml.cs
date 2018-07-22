using AppMemeSound.Help;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMemeSound.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil01 : ContentPage
    {
        public Perfil01()
        {
            InitializeComponent();

            SOM.Clicked += TocasMusica;
        }


        private void TocasMusica(object sender, EventArgs args)
        {

            CrossMediaManager.Current.Play("https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4", MediaFileType.Video);

        }
    }
}