using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class IndiceModels
    {
        public int Id { get; set; }
        public string ClienteNumCliente { get; set; }
        public string PinturaCodigo { get; set; }

        public string linea()
        {
            var fila = Id.ToString() + "," +
                      ClienteNumCliente + "," +
                      PinturaCodigo;

            return fila;
        }
    }
}