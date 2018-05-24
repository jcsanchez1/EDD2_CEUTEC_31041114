using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDD2_JCSM_3104114.Models;
using EDD2_JCSM_3104114.Properties;
using System.Threading.Tasks;
using System.Net;

namespace EDD2_JCSM_3104114.Controllers
{
    public class ClienteController: Controller
    {
        private readonly NegociosModels _negocios = new NegociosModels();
        public ActionResult Index()
        {
            _negocios.CrearArchivo();
            var lista = _negocios.Clientes().Where(c => c.Estado == 1);
            var cantidad = _negocios.ContarClientes();
            ViewBag.cantidad = cantidad;
            return View(lista);
        }
        // GET: Customer/Details/5
        public ActionResult Detalle(int? id)
        {
            var clientes = _negocios.Clientes();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }
        public ActionResult Details(int? id)
        {
            var clientes = _negocios.Clientes();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // GET: Customer/Create
        public ActionResult Crear()
        {
            FillViewBag(null, null, null, null);
            return View();
        }

        private void FillViewBag(string pais, string departamento, string ciudad, string pintura)
        {
            var Pais = new PaisModels();
            var Departamento = new DepartamentoModels();
            var Ciudad = new CiudadModels();
            var Pintura = new PinturaModels();

            ViewBag.Pais = new SelectList(Pais.GetList(),"Pais", "Pais", pais);
            ViewBag.Departamentos = new SelectList(Departamento.GetList(), "Departamento", "Departamento", departamento);
            ViewBag.Ciudades = new SelectList(Ciudad.GetList(), "Ciudad", "Ciudad", ciudad);
            ViewBag.Pinturas = new SelectList(Pintura.GetList(), "Codigo", "descripcionPintura", pintura);
        }


        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ClienteNumCliente, ClienteIdentidad, ClienteNombre, ClienteApellido, ClienteFechaNacimiento, ClientePais, ClienteDepartamento, ClienteMunicipio, ClienteDireccion, ClienteTelefono, PinturaCodigo")] ClienteModels cliente)
        {
            try
            {
                // TODO: Add insert logic here
                FillViewBag(cliente.ClientePais, cliente.ClienteDepartamento, cliente.ClienteMunicipio, cliente.PinturaCodigo);

                if (!ModelState.IsValid)
                {
                    return View(cliente);
                }

                var Pintura = new PinturaModels();
                var s = Pintura.GetList().SingleOrDefault(sv => sv.Codigo == cliente.PinturaCodigo);

                var clientes = _negocios.Clientes();

                var clienteDb = clientes.SingleOrDefault(c => c.ClienteNumCliente == cliente.ClienteNumCliente && c.PinturaCodigo == cliente.PinturaCodigo);

                if (clienteDb != null)
                {
                    @ViewBag.MessageError = "ya esta registrada esa compra";
                    return View(cliente);
                }

                var id = clientes.Count + 1;

                cliente.Id = id;
                cliente.FechaCompra = DateTime.Now;
                cliente.PinturaDescripcion = s.Descripcion;
                cliente.PinturaCantidad = s.Cantidad;
                cliente.PinturaUnidadMedida = s.UnidadMedida;
                cliente.PinturaPrecioVenta = s.PrecioVenta;
                cliente.PinturaCosto = s.Costo;
                cliente.Estado = 1;

                var flag = _negocios.GuardarCliente(cliente);

                if (flag)
                {
                    return RedirectToAction("Index");
                }

                @ViewBag.MessageError = "Datos no guardados.";
                return View(cliente);
            }
            catch (Exception ex)
            {
                var message = ex.Message + "\n";
                var loop = ex.InnerException;
                do
                {
                    message = loop != null ? message + loop.Message + "\n" : message;
                    loop = loop?.InnerException;

                } while (loop != null);

                Session.Add("ErrorMessage", message);
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            var clientes = _negocios.Clientes();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var flag = _negocios.EliminarCliente(id);

                if (flag)
                {
                    return RedirectToAction("Index");
                }

                var clientes = _negocios.Clientes();
                var cliente = clientes.SingleOrDefault(c => c.Id == id);

                @ViewBag.MessageError = "Datos no guardados.";
                return View(cliente);
            }
            catch (Exception ex)
            {
                var message = ex.Message + "\n";
                var loop = ex.InnerException;
                do
                {
                    message = loop != null ? message + loop.Message + "\n" : message;
                    loop = loop?.InnerException;

                } while (loop != null);

                Session.Add("ErrorMessage", message);
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult ReBuild()
        {
            try
            {
                _negocios.reconstruirArchivos();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var message = ex.Message + "\n";
                var loop = ex.InnerException;
                do
                {
                    message = loop != null ? message + loop.Message + "\n" : message;
                    loop = loop?.InnerException;

                } while (loop != null);

                Session.Add("ErrorMessage", message);
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult IndexFile()
        {
            var lista = _negocios.indice();
            var cantidad = _negocios.contarIndice();
            ViewBag.cantidad = cantidad;
            return View(lista);
        }

        public ActionResult AvailableFile()
        {
            var lista = _negocios.disponibles();
            var cantidad = _negocios.contarDisponibilidad();
            ViewBag.cantidad = cantidad;
            return View(lista);
        }
        public ActionResult deletedFile()
        {
            var lista = _negocios.eliminado();
            var cantidad = _negocios.contarEliminados();
            ViewBag.cantidad = cantidad;
            return View(lista);
        }
    }
}