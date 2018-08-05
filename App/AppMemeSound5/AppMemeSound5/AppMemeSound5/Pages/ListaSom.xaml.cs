using Android.App;
using Android.Content;
using Android.Widget;
using AppMemeSound5.Model;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMemeSound5.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaSom : ContentPage
    {

        private List<Data> dados { get; set; }
        private List<Data> dadosFiltrado { get; set; }
        public ListaSom()
        {
            InitializeComponent();

           
            dados = Service.AppService.GetData("all");
            Lista.ItemsSource = dados;

        }
        public ListaSom(string name)
        {
            InitializeComponent();

            dados = Service.AppService.GetData(name);
            Lista.ItemsSource = dados;

        }
        private void SelecaoSomAction(object sender, SelectedItemChangedEventArgs args)
        {
            Data dado = (Data)args.SelectedItem;
            
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(dado.archive);
            player.Play();
          
            
            var share = DependencyService.Get<IShare>();

            share.Show(dado.name, dado.name, dado.archive);


        }
        private void BuscaRapida(object sender, TextChangedEventArgs args)
        {
            dadosFiltrado =  dados.Where(a => a.name.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            Lista.ItemsSource = dadosFiltrado;
        }

      


    }
}