using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDD2_JCSM_3104114.Models
{
    public class ClienteModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Num. Cliente")]
        [StringLength(15, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClienteNumCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Num. Identidad")]
        [StringLength(18, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClienteIdentidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Nombre")]
        [StringLength(50, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClienteNombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Apellido")]
        [StringLength(50, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClienteApellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime ClienteFechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Pais")]
        [StringLength(50, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClientePais { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Departamento")]
        [StringLength(50, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClienteDepartamento { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Ciudad")]
        [StringLength(50, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 1)]
        public string ClienteMunicipio { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(200, ErrorMessage = "El campo {0} al menos de {2} caracteres.", MinimumLength = 5)]
        public string ClienteDireccion { get; set; }

        [Display(Name = "Telefono")]
        public string ClienteTelefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Codigo de Pintura")]
        public string PinturaCodigo { get; set; }

        [Display(Name = "Tipo de Pintura")]
        public string PinturaDescripcion { get; set; }

        [Display(Name = "Cantidad Pintura")]
        public double PinturaCantidad { get; set; }

        [Display(Name = "Unidad de Medida")]
        public string PinturaUnidadMedida { get; set; }

        [Display(Name = "Precio de Venta")]
        public double PinturaPrecioVenta { get; set; }

        [Display(Name = "Costo")]
        public double PinturaCosto { get; set; }

        [Display(Name = "Fecha de compra")]
        public DateTime FechaCompra { get; set; }

        public int Estado { get; set; }
        public int Tamanio { get; set; }

        public string Fila()
        {
            var linea = Id.ToString() + ',' +
                      ClienteNumCliente + ',' +
                      ClienteIdentidad + ',' +
                      ClienteNombre + ',' +
                      ClienteApellido + ',' +
                      ClienteFechaNacimiento.ToString("yyyy-MM-dd") + ',' +
                      ClientePais + ',' +
                      ClienteDepartamento + ',' +
                      ClienteMunicipio + ',' +
                      ClienteDireccion + ',' +
                      ClienteTelefono + ',' +
                      PinturaCodigo + ',' +
                      PinturaDescripcion + ',' +
                      PinturaCantidad + ',' +
                      PinturaUnidadMedida + ',' +
                      PinturaPrecioVenta + ',' +
                      PinturaCosto + ',' +
                      FechaCompra.ToString("yyyy-MM-dd") + ',' +
                      Estado.ToString();

            return linea;
        }
    }
}