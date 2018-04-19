using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class VendaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static void CadastrarVenda(Venda venda)
        {
            ctx.Vendas.Add(venda);
            ctx.SaveChanges();
        }

    }
}