using AppMemeSound5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMemeSound5.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaSom : ContentPage
    {

        public ListaSom()
        {
            InitializeComponent();

            Lista.ItemsSource = Service.AppService.GetData("all");


        }
        public ListaSom(string name)
        {
            InitializeComponent();

            Lista.ItemsSource = Service.AppService.GetData(name);


        }
        private void SelecaoSomAction(object sender, SelectedItemChangedEventArgs args)
        {
            Data dado = (Data)args.SelectedItem;

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(dado.archive);
            player.Play();

        }

    }
}