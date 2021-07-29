using CatastroAvanza.Infraestructura.ContratosServicios;
using System;
using System.Configuration;
using System.IO;

namespace CatastroAvanza.Infraestructura.ImplementacionesServicios
{
    public class AlmacenamientoArchivos : IAlmacenamientoArchivos
    {
        private readonly bool _UsaDirectorioExterno;
        private readonly string _directorio;
        private string _directorioTrabajo;            

        public AlmacenamientoArchivos()
        {
            if (bool.TryParse(ConfigurationManager.AppSettings["UsarDirectorioArchivosExterno"],out  _UsaDirectorioExterno));
            if (_UsaDirectorioExterno)
                _directorio = ConfigurationManager.AppSettings["DirectorioArchivosExterno"];
            else
                _directorio = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");// System.Web.Hosting.HostingEnvironment.MapPath("~/UploadedFiles");
        }
        public void GuardarArchivoFisico(InformationDocumento archivo)
        {
            if (archivo == null)
                return;
                //log de el problema

            if(!archivo.ValidarSiUnDocumentoPuedeSerCreado())
                return;
            //log de el problema

            try
            {
                _directorioTrabajo = Path.Combine(_directorio, archivo.PathAdicional);
                if (!Directory.Exists(_directorioTrabajo))
                {
                    DirectoryInfo directoryInfo= Directory.CreateDirectory(_directorioTrabajo);                    
                }

                string filename = Path.Combine(_directorioTrabajo, archivo.NombreArchivo);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // Write the data to the file, byte by byte.
                    for (int i = 0; i < archivo.DocumentoBinario.Length; i++)
                    {
                        fileStream.WriteByte(archivo.DocumentoBinario[i]);
                    }

                    // Set the stream position to the beginning of the file.
                    fileStream.Seek(0, SeekOrigin.Begin);


                    // Read and verify the data.
                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        if (archivo.DocumentoBinario[i] != fileStream.ReadByte())
                        {          
                            //TODO: log el problema
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log the error
                return;
            }
                
        }

        public byte[] TraerArchivoFisico(string archivo, string pathAdicional)
        {
            if (string.IsNullOrEmpty(archivo))
            {
                //TODO: log the error
                return new byte[0];
            }

            try
            {

                _directorioTrabajo = Path.Combine(_directorio, pathAdicional,archivo);
                if (!File.Exists(_directorioTrabajo))
                {
                    //TODO: log the error
                    return new byte[0];
                }

                using (FileStream fsSource = new FileStream(_directorioTrabajo, FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;                    
                    return bytes;
                }
            }
            catch (Exception ioEx)
            {
                //TODO: log the error
                return new byte[0];
            }
        }
    }
}