using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class DisponiblesModels
    {
            public int Id { get; set; }
            public string ClienteNumCliente { get; set; }
            public string TipoPintura { get; set; }
            public int Estado { get; set; }

            public string linea()
            {
                var row = Id.ToString() + "," +
                          ClienteNumCliente + "," +
                          TipoPintura + "," +
                          Estado.ToString();

                return row;
            }
    }
}