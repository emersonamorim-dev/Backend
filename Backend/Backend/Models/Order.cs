using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Backend.Models
{
    public class Order
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public string amount{ get; set; }
        public List<Order> ListarAcoes()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaAcoes = JsonConvert.DeserializeObject<List<Order>>(json);

            return listaAcoes;
        }

        public bool EditarArquivo(List<Order> listaAcoes)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAcoes, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

       }
    }
