using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class PaisModels
    {
        public string Pais { get; set; }
        public IEnumerable<PaisModels> GetList()
        {
            var lista = new List<PaisModels>
            {
                new PaisModels
                {
                    Pais="Honduras"
                }
            };
            return lista;
        }
    }
}