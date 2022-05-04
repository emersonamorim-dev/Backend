using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Backend.Models
{
    public class Trends
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string price { get; set; }
        public string symbol { get; set; }
        public string currentPrice { get; set; }
        public List<Trends> ListarAcoes()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaAcoes = JsonConvert.DeserializeObject<List<Trends>>(json);

            return listaAcoes;
        }

        public bool EditarArquivo(List<Trends> listaAcoes)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAcoes, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        internal void Atualizar(string acao)
        {
            throw new NotImplementedException();
        }

        public Trends Inserir(Trends acao)
        {
            var listaAcoes = this.ListarAcoes();

            var maxId = listaAcoes.Max(acoes => acoes.id);
            acao.id = maxId + 1;
            listaAcoes.Add(item: acao);
            EditarArquivo(listaAcoes);
            return acao;
        }
        public Trends Atualizar(int id, Trends Acao)
        {
            var listaAcoes = this.ListarAcoes();

            var itemIndex = listaAcoes.FindIndex(p => p.id == Acao.id);
            if (itemIndex >= 0)
            {
                Acao.id = id;
                listaAcoes[itemIndex] = Acao;
            }
            else
            {
                return null;
            }
            EditarArquivo(listaAcoes);
            return Acao;
        }

        public bool Deletar(int id)
        {
            var listaAcoes = this.ListarAcoes();
            var itemIndex = listaAcoes.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaAcoes.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            EditarArquivo(listaAcoes);
            return true;
        }
       }
    }
