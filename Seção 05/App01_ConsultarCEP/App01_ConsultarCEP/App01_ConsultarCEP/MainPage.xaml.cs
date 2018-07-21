using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System.Text.RegularExpressions;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            

            BTN_BUSCARCEP.Clicked += BuscarCEP; 

		}


        private void BuscarCEP(object sender, EventArgs args)
        {

            //TODO -- Lógica do programa.

            //TODO - Validações

            string cep = "";

            if (EDT_CEP.Text != null)
            {
                cep = EDT_CEP.Text.Trim();
            }


            

            foreach (var chr in new string[] { "(", ")", "-", " " })
            {
                cep = cep.Replace(chr, "");
            }

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEndercoViaCEP(cep);

                    if (end != null)
                    {
                        LBL_CEP.Text = string.Format("Endereço: {2} - {3} {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);

                    }
                    else
                    {
                        DisplayAlert("ERRO CRÍTICO", "O endereço não foi encontrado para o CEP informado: "+ cep, "OK");
                    }

                    EDT_CEP.Text = "";

                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
               
            }
            

        }

        private bool isValidCEP(string cep)
        {
            if (cep == "")
            {
                //erro
                DisplayAlert("ERRO", "Informe um Cep!", "OK");

                return false;
            }

            if (cep.Length != 8)
            {
                //erro
                DisplayAlert("ERRO", "CEP inválido! O Cep deve conter 8 caracteres.", "OK");

                return false;
            }
            int NovoCep = 0;
            if(!int.TryParse(cep, out NovoCep))
            {

                //Erro
                DisplayAlert("ERRO", "CEP inválido! O Cep deve ser composto apenas por números.", "OK");

                return false;
            }



            return true;
        }


	}
}
