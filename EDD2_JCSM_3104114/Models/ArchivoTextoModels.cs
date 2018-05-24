using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;


namespace EDD2_JCSM_3104114.Models
{
    public class ArchivoTextoModels
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linea"></param>
        /// <param name="directorio"></param>
        /// <returns></returns>
        public bool CrearArchivo(string linea, string directorio)
        {
            try
            {
                var Vdirectorio = Path.GetDirectoryName(directorio);
                if(!Directory.Exists(Vdirectorio))
                {
                    Directory.CreateDirectory(Vdirectorio);
                };
                if (File.Exists(directorio)) return true;
                using (var archivo = new FileStream(directorio, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (var Sarchivo = new StreamWriter(archivo))
                {
                    Sarchivo.WriteLine(linea);
                    Sarchivo.Flush();
                    Sarchivo.Close(); 
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directorio"></param>
        /// <returns></returns>
        public bool EliminarArchivo(string directorio)
        {
            try
            {
                if (!File.Exists(directorio)) return false;
                File.Delete(directorio);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="linea"></param>
        /// <param name="abrir"></param>
        /// <param name="directorio"></param>
        /// <returns></returns>
        public bool EscribirLinea(string linea, bool abrir, string directorio)
        {
            try
            {
                if(!abrir)
                {
                    using (var archivo = new FileStream(directorio, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    using (var Sarchivo = new StreamWriter(archivo))
                    {
                        Sarchivo.WriteLine(linea);
                        Sarchivo.Flush();
                        Sarchivo.Close();
                    }
                }
                else
                {
                    using (var Sarchivo = new StreamWriter(directorio, abrir))
                    {
                        Sarchivo.WriteLine(linea);
                        Sarchivo.Flush();
                        Sarchivo.Close();
                    }
                }
                return true;
            }
            
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directorio"></param>
        /// <returns></returns>
        public List<string> GetDatos(string directorio)
        {
            try
            {
                var dato = new List<string>();
                using (var archivo = new StreamReader(directorio))
                {
                    var linea = archivo.ReadLine();
                    while(linea != null)
                    {
                        dato.Add(linea);
                        linea = archivo.ReadLine();
                    }
                }
                return dato;
            }
            catch(Exception)
            {
                return new List<string>();
            }
        }
    }
}