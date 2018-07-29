using AppMemeSound3.Model;
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
	public partial class ListaSom : ContentPage
	{
		public ListaSom (string name = "all")
		{
			InitializeComponent ();

            Lista.ItemsSource = Service.AppService.GetData("all");


        }
        private void SelecaoSomAction(object sender, SelectedItemChangedEventArgs args)
        {
            Data dado = (Data) args.SelectedItem;

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(dado.archive);
            player.Play();

        }

    }
}