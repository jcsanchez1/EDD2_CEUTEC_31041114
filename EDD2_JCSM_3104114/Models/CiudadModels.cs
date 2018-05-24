using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class CiudadModels
    {
        public string ciudad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CiudadModels> GetList()
        {
            var lista = new List<CiudadModels>
            {
                new CiudadModels
                {
                    ciudad = "Tegicigalpa"
                },
                new CiudadModels
                {
                    ciudad ="San Pedro Sula"
                },
                new CiudadModels
                {
                    ciudad="La Ceiba"
                },
                new CiudadModels
                {
                    ciudad="Choluteca"
                }
            };
            return lista;
        }
    }
}