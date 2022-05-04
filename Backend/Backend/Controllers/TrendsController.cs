using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class TrendsController : ApiController
    {
        // GET: api/Acoes
        public IEnumerable<Trends> Get()
        {
            Trends acao = new Trends();
            return acao.ListarAcoes();
        }

        // GET: api/Acoes/5
        public Trends Get(int id)
        {
            Trends acao = new Trends();
            return acao.ListarAcoes().Where(X => X.id == id).FirstOrDefault();
        }

        // POST: api/Acoes
        public List<Trends> Post(Trends acao)
        {
            Trends _acao = new Trends();

            _acao.Inserir(acao);

            return _acao.ListarAcoes();
        }

        // PUT: api/Acoes/5
        public Trends Put(int id, [FromBody] Trends acao)
        {
            Trends _acao = new Trends();
           return _acao.Atualizar(id, acao);
        }

        // DELETE: api/Acoes/5
        public void Delete(int id)
        {
            Trends _acao = new Trends();
            _acao.Deletar(id);
        }
    }
}
