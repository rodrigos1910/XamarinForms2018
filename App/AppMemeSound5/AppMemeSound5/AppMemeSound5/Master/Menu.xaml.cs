using AppMemeSound5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMemeSound5.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();

            Lista.ItemsSource = Service.AppService.GetCategorias();
        }

        private void GoPaginaPerfil01(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new Pages.Perfil01());
            Detail = new NavigationPage(new Pages.Page01());
            IsPresented = false; //desaparecer o menu
            //Detail = new Pages.SilvaSystem();

        }
        private void GoPaginaSilvaSystem(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new Pages.SilvaSystem());
            Detail = new NavigationPage(new Pages.ListaSom("all"));
            IsPresented = false; //desaparecer o menu
            //Detail = new Pages.SilvaSystem();

        }



        private void SelecaoCategoriaAction(object sender, SelectedItemChangedEventArgs args)
        {
            Category cat = (Category)args.SelectedItem;

           Detail = new NavigationPage(new Pages.ListaSom(cat.name));
           IsPresented = false;
        }

    }
}