using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class DepartamentoModels
    {
        public string Departamento { get; set; }

        public IEnumerable<DepartamentoModels> GetList()
        {
            var lista = new List<DepartamentoModels>
            {
                new DepartamentoModels
                {
                    Departamento = "Francisco Morazan"
                },
                new DepartamentoModels
                {
                    Departamento = "Cortez"
                },
                new DepartamentoModels
                {
                    Departamento = "Atlantida"
                },
                new DepartamentoModels
                {
                    Departamento = "Choluteca"
                },
            };

            return lista;
        }
    }
}