using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class OrderController : ApiController
    {


        // POST: api/Order
        public List<Order> Post(Order order)
        {
            Order _acao = new Order();

            return _acao.ListarAcoes();
        }

    }
}
