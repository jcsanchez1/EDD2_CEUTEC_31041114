using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EDD2_JCSM_3104114.Properties;
using EDD2_JCSM_3104114;

namespace EDD2_JCSM_3104114.Models
{
    public class NegociosModels
    {
        private readonly ArchivoTextoModels _at = new ArchivoTextoModels();
        /// <summary>
        /// 
        /// </summary>
        public void CrearArchivo()
        {
            var at = new ArchivoTextoModels();
            var proyecto1Archivo = Settings.Default.Proyecto1;
            var indiceArchivo = Settings.Default.Indice;
            var disponibleArchivo = Settings.Default.Disponible;
            var eliminadoArchivo = Settings.Default.Eliminado;

            var cabeceraProyecto1 = "Id,ClienteNumCliente,ClienteIdentidad,ClienteNombre,ClienteApellido,ClienteFechaNacimiento,ClientePais,ClienteDepartamento,ClienteMunicipio,ClienteDireccion,ClienteTelefono,PinturaCodigo,PinturaDescripcion,PinturaCantidad,PinturaUnidadMedida,PinturaPrecioVenta,PinturaCosto,FechaCompra,Estado,Tamanio";
            var cabeceraIndice = "Id,ClienteNumCliente,PinturaCodigo";
            var cabeceraDisponible = "Id,ClienteNumCliente,PinturaCodigo,Estado";
            var cabeceraEliminado = "Id,ClienteNumCliente,ClienteIdentidad,ClienteNombre,ClienteApellido,ClienteFechaNacimiento,ClientePais,ClienteDepartamento,ClienteMunicipio,ClienteDireccion,ClienteTelefono,PinturaCodigo,PinturaDescripcion,PinturaCantidad,PinturaUnidadMedida,PinturaPrecioVenta,PinturaCosto,FechaCompra,Estado,Tamanio";

            var proyecto = at.CrearArchivo(cabeceraProyecto1, proyecto1Archivo);
            var indice = at.CrearArchivo(cabeceraIndice, indiceArchivo);
            var disponible = at.CrearArchivo(cabeceraDisponible, disponibleArchivo);
            var eliminado = at.CrearArchivo(cabeceraEliminado, eliminadoArchivo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ClienteModels> Clientes()
        {
            var x = 0;
            var lista = new List<ClienteModels>();
            var proyecto1directorio = Settings.Default.Proyecto1;
            var datos = _at.GetDatos(proyecto1directorio);
            foreach(var fila in datos)
            {
                if(x==0)
                {
                    x = 1;
                    continue;
                }
                var dividirDatos = fila.Split(',');
                var clienteFila = new ClienteModels();
                clienteFila.Id = Convert.ToInt32(dividirDatos[0]);
                clienteFila.ClienteNumCliente = dividirDatos[1];
                clienteFila.ClienteIdentidad = dividirDatos[2];
                clienteFila.ClienteNombre = dividirDatos[3];
                clienteFila.ClienteApellido = dividirDatos[4];
                clienteFila.ClienteFechaNacimiento = Convert.ToDateTime(dividirDatos[5]);
                clienteFila.ClientePais = dividirDatos[6];
                clienteFila.ClienteDepartamento = dividirDatos[7];
                clienteFila.ClienteMunicipio = dividirDatos[8];
                clienteFila.ClienteDireccion = dividirDatos[9];
                clienteFila.ClienteTelefono = dividirDatos[10];
                clienteFila.PinturaCodigo = dividirDatos[11];
                clienteFila.PinturaDescripcion = dividirDatos[12];
                clienteFila.PinturaCantidad = Convert.ToDouble(dividirDatos[13]);
                clienteFila.PinturaUnidadMedida = dividirDatos[14];
                clienteFila.PinturaPrecioVenta = Convert.ToDouble(dividirDatos[15]);
                clienteFila.PinturaCosto = Convert.ToDouble(dividirDatos[16]);
                clienteFila.FechaCompra = Convert.ToDateTime(dividirDatos[17]);
                clienteFila.Estado = Convert.ToInt32(dividirDatos[18]);
                lista.Add(clienteFila); 
            }
            return lista;
        }

        public Int32 ContarClientes()
        {
            var x = 0;
            var lista = new List<ClienteModels>();
            var proyecto1directorio = Settings.Default.Proyecto1;
            var datos = _at.GetDatos(proyecto1directorio);
            foreach (var fila in datos)
            {
                x++;
            }
            return x-1;
            }
            public List<DisponiblesModels> disponibles()
        {
            var x = 0;
            var lista = new List<DisponiblesModels>();
            var disponibleDirectorio = Settings.Default.Disponible;
            var datos = _at.GetDatos(disponibleDirectorio);
            foreach(var fila in datos)
            {
                if(x==0)
                {
                    x = 1;
                    continue;
                }
                var dividirDatos = fila.Split(',');
                var disponibleFila = new DisponiblesModels();
                disponibleFila.Id = Convert.ToInt32(dividirDatos[0]);
                disponibleFila.ClienteNumCliente = dividirDatos[1];
                disponibleFila.TipoPintura = dividirDatos[2];
                disponibleFila.Estado = Convert.ToInt32(dividirDatos[3]);
                lista.Add(disponibleFila);
            }

            return lista;
        }
        public Int32 contarDisponibilidad()
        {
            var x = 0;
            var lista = new List<DisponiblesModels>();
            var disponibleDirectorio = Settings.Default.Disponible;
            var datos = _at.GetDatos(disponibleDirectorio);
            foreach (var fila in datos)
            {
                x++;
            }
            return x - 1;
        }
        public List<IndiceModels> indice()
        {
            var x = 0;
            var lista = new List<IndiceModels>();
            var indiceDirectorio = Settings.Default.Indice;
            var datos = _at.GetDatos(indiceDirectorio);
            foreach(var fila in datos)
            {
                if(x ==0)
                {
                    x = 1;
                    continue;
                }
                var dividirDatos = fila.Split(',');
                var indiceFila = new IndiceModels();
                indiceFila.Id = Convert.ToInt32(dividirDatos[0]);
                indiceFila.ClienteNumCliente = dividirDatos[1];
                indiceFila.PinturaCodigo = dividirDatos[2];
                lista.Add(indiceFila);
            }
            return lista;
        }
        public Int32 contarIndice()
        {
            var x = 0;
            var lista = new List<IndiceModels>();
            var indiceDirectorio = Settings.Default.Indice;
            var datos = _at.GetDatos(indiceDirectorio);
            foreach (var fila in datos)
            {
                x++;
            }
            return x - 1;
        }
        public List<EliminadoModels> eliminado()
        {
            var x = 0;
            var lista = new List<EliminadoModels>();
            var eliminadodirectorio = Settings.Default.Eliminado;
            var datos = _at.GetDatos(eliminadodirectorio);
            foreach (var fila in datos)
            {
                if (x == 0)
                {
                    x = 1;
                    continue;
                }
                var dividirDatos = fila.Split(',');
                var eliminadoFila = new EliminadoModels();
                eliminadoFila.Id = Convert.ToInt32(dividirDatos[0]);
                eliminadoFila.ClienteNumCliente = dividirDatos[1];
                eliminadoFila.ClienteIdentidad = dividirDatos[2];
                eliminadoFila.ClienteNombre = dividirDatos[3];
                eliminadoFila.ClienteApellido = dividirDatos[4];
                eliminadoFila.ClienteFechaNacimiento = Convert.ToDateTime(dividirDatos[5]);
                eliminadoFila.ClientePais = dividirDatos[6];
                eliminadoFila.ClienteDepartamento = dividirDatos[7];
                eliminadoFila.ClienteMunicipio = dividirDatos[8];
                eliminadoFila.ClienteDireccion = dividirDatos[9];
                eliminadoFila.ClienteTelefono = dividirDatos[10];
                eliminadoFila.PinturaCodigo = dividirDatos[11];
                eliminadoFila.PinturaDescripcion = dividirDatos[12];
                eliminadoFila.PinturaCantidad = Convert.ToDouble(dividirDatos[13]);
                eliminadoFila.PinturaUnidadMedida = dividirDatos[14];
                eliminadoFila.PinturaPrecioVenta = Convert.ToDouble(dividirDatos[15]);
                eliminadoFila.PinturaCosto = Convert.ToDouble(dividirDatos[16]);
                eliminadoFila.FechaCompra = Convert.ToDateTime(dividirDatos[17]);
                eliminadoFila.Estado = Convert.ToInt32(dividirDatos[18]);
                lista.Add(eliminadoFila);
            }
            return lista;
        }
        public Int32 contarEliminados()
        {
            var x = 0;
            var lista = new List<EliminadoModels>();
            var eliminadodirectorio = Settings.Default.Eliminado;
            var datos = _at.GetDatos(eliminadodirectorio);
            foreach (var fila in datos)
            {
                x++;
            }
            return x - 1;
        }
        public bool GuardarCliente(ClienteModels cliente)
        {
            var contar = 1;
            var linea = cliente.Fila();
            var proyecto1Directorio = Settings.Default.Proyecto1;
            var indicesDirectorio = Settings.Default.Indice;
            var disponiblesDirectorio = Settings.Default.Disponible;
            var disponible = disponibles();
            var cabeceraDisponible = "Id,ClienteNumCliente,PinturaCodigo,Estado";
            var banderilla = _at.EliminarArchivo(disponiblesDirectorio);
            banderilla = _at.CrearArchivo(cabeceraDisponible, disponiblesDirectorio);
            banderilla = _at.EscribirLinea(linea, true, proyecto1Directorio);
            var indice = new IndiceModels
            {
                Id = cliente.Id,
                ClienteNumCliente = cliente.ClienteNumCliente,
                PinturaCodigo = cliente.PinturaCodigo
            };
            linea = indice.linea();
            _at.EscribirLinea(linea, true, indicesDirectorio);
            foreach (var fila in disponible)
            {
                if(contar == 1)
                {
                    continue;
                }
                linea = fila.linea();
                _at.EscribirLinea(linea, true, disponiblesDirectorio);
            }
            return banderilla;
        }
        public bool EliminarCliente(int id)
        {
            var cliente = Clientes();
            var proyecto1Directorio = Settings.Default.Proyecto1;
            var indicesDirectorio = Settings.Default.Indice;
            var disponiblesDirectorio = Settings.Default.Disponible;
            var eliminadoDirectorio = Settings.Default.Eliminado;
            var banderilla = _at.EliminarArchivo(proyecto1Directorio);
            banderilla = _at.EliminarArchivo(indicesDirectorio);
            banderilla = _at.EliminarArchivo(disponiblesDirectorio);
            banderilla = _at.EliminarArchivo(eliminadoDirectorio);
            CrearArchivo();
            foreach(var fila in cliente)
            {
                if(fila.Id == id)
                {
                    fila.Estado = 0;
                }
                var linea = fila.Fila();
                _at.EscribirLinea(linea,true, proyecto1Directorio);
                if(fila.Estado !=0)
                {
                    var indice = new IndiceModels
                    {
                        Id = fila.Id,
                        ClienteNumCliente = fila.ClienteNumCliente,
                        PinturaCodigo = fila.PinturaCodigo
                    };
                    linea = indice.linea();
                    _at.EscribirLinea(linea, true, indicesDirectorio);
                }
                else
                {
                    var disponible = new DisponiblesModels()
                    {
                        Id = fila.Id,
                        ClienteNumCliente = fila.ClienteNumCliente,
                        TipoPintura = fila.ClienteNumCliente
                    };
                    linea = disponible.linea();
                    _at.EscribirLinea(linea, true, disponiblesDirectorio);

                    var eliminar = new EliminadoModels()
                    {
                        Id = fila.Id,
                        ClienteNumCliente = fila.ClienteNumCliente,
                        ClienteIdentidad = fila.ClienteIdentidad,
                        ClienteNombre = fila.ClienteNombre,
                        ClienteApellido = fila.ClienteApellido,
                        ClienteFechaNacimiento = fila.ClienteFechaNacimiento,
                        ClientePais = fila.ClientePais,
                        ClienteDepartamento = fila.ClienteDepartamento,
                        ClienteMunicipio = fila.ClienteMunicipio,
                        ClienteDireccion = fila.ClienteDireccion,
                        ClienteTelefono = fila.ClienteTelefono,
                        PinturaCodigo = fila.PinturaCodigo,
                        PinturaCantidad = fila.PinturaCantidad,
                        PinturaCosto = fila.PinturaCosto,
                        PinturaDescripcion = fila.PinturaDescripcion,
                        PinturaPrecioVenta = fila.PinturaPrecioVenta,
                        PinturaUnidadMedida = fila.PinturaUnidadMedida,
                        Estado = fila.Estado,
                        Tamanio = fila.Tamanio
                    };
                    linea = eliminar.Fila();
                    _at.EscribirLinea(linea, true, eliminadoDirectorio);
                }
            }
            return banderilla;
        }
        public bool reconstruirArchivos()
        {
            var contar = 1;
            var clientes = Clientes();
            var proyecto1Directorio = Settings.Default.Proyecto1;
            var indicesDirectorio = Settings.Default.Indice;
            var disponiblesDirectorio = Settings.Default.Disponible;
            var eliminadoDirectorio = Settings.Default.Eliminado;
            var banderilla = _at.EliminarArchivo(proyecto1Directorio);
            banderilla = _at.EliminarArchivo(indicesDirectorio);
            banderilla = _at.EliminarArchivo(disponiblesDirectorio);
            banderilla = _at.EliminarArchivo(eliminadoDirectorio);
            CrearArchivo();
            foreach (var fila in clientes)
            {
                if (fila.Estado == 0) continue;
                fila.Id = contar;
                var linea = fila.Fila();
                _at.EscribirLinea(linea, true, proyecto1Directorio);
                var indice = new IndiceModels
                {
                    Id = contar,
                    ClienteNumCliente = fila.ClienteNumCliente,
                    PinturaCodigo = fila.PinturaCodigo
                };
                linea = indice.linea();
                _at.EscribirLinea(linea, true, indicesDirectorio);
                contar++;
            }
            return banderilla;
        }
    }
}