using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEndercoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string counteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(counteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
