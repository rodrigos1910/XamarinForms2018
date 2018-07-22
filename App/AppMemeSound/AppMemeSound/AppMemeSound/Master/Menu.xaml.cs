using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMemeSound.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private void GoPaginaPerfil01(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new Pages.Perfil01());
            //Detail = new Pages.Perfil01();
            Detail = new Pages.SilvaSystem();
        }
        private void GoPaginaSilvaSystem(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new Pages.SilvaSystem());

            Detail = new Pages.SilvaSystem();
        }

    }
}