using AppMemeSound5.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppMemeSound5.Service
{
    public class AppService
    {
        private static string URL = "https://api.myjson.com/bins/wxwua";


        public static List<Category> GetCategorias()
        {

            Retorno ret = new Retorno();
            try
            {
                WebClient wc = new WebClient();
                string conteudo = wc.DownloadString(URL);

                ret = JsonConvert.DeserializeObject<Retorno>(conteudo);

            }
            catch (Exception e)
            {

            }

            return ret.category;
        }
        public static List<Data> GetData(string name)
        {
            List<Category> lc = GetCategorias();
            List<Data> ld = new List<Data>();

            foreach (Category categoria in lc)
            {
                if (categoria.name == name)
                {
                    ld = categoria.data;
                }


            }

            return ld;

        }





    }
}
