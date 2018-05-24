using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class PinturaModels
    {
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Codigo de Plan")]
        [StringLength(15, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 10)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Descripcion de Plan")]
        [StringLength(200, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 10)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Velocidad de Plan")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe de ser mayor a {1}")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Unidad de Medida")]
        [StringLength(50, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 2)]
        public string UnidadMedida { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Precio de Venta")]
        [Range(0.0, double.MaxValue, ErrorMessage = "El campo {0} debe de ser mayor a {1}")]
        public double PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Costo del Plan")]
        [Range(0.0, double.MaxValue, ErrorMessage = "El campo {0} debe de ser mayor a {1}")]
        public double Costo { get; set; }

        public string descripcionPintura { get; set; }
        public List<PinturaModels> GetList()
        {
            var lista = new List<PinturaModels>
            {
                new PinturaModels
                {
                    Codigo = "0001",
                    Descripcion = "Pintura agua",
                    Cantidad = 1,
                    UnidadMedida = "Galon",
                    PrecioVenta = 25,
                    Costo = 10,
                    descripcionPintura = "pintura agua 1 Galon"
                },
                new PinturaModels
                {
                    Codigo = "0002",
                    Descripcion = "Pintura agua",
                    Cantidad = 1,
                    UnidadMedida = "Cubeta",
                    PrecioVenta = 125,
                    Costo = 50,
                    descripcionPintura = "Pintura agua 1 Cubeta"
                },
                new PinturaModels
                {
                    Codigo = "0003",
                    Descripcion = "Pintura Aceite",
                    Cantidad = 1,
                    UnidadMedida = "Galon",
                    PrecioVenta = 30,
                    Costo = 10,
                    descripcionPintura = "Pintura Aceite 1 Galon"
                },
                new PinturaModels
                {
                    Codigo = "0004",
                    Descripcion = "Pintura Aceite",
                    Cantidad = 1,
                    UnidadMedida = "Cubeta",
                    PrecioVenta = 150,
                    Costo = 75,
                    descripcionPintura = "Pintura Aceite 1 Cubeta"
                }
            };
            return lista;
        }
    }
}