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

        public void CombinarArchivoCargado(string fileId,string pathAdicional)
        {
            _directorioTrabajo = Path.Combine(_directorio, pathAdicional, $"{fileId}_tmp");

            string[] archivosCreados = Directory.GetFiles(_directorioTrabajo);                                   

            string filenameCompleted = Path.Combine(_directorio, pathAdicional, $"{fileId}");

            using (FileStream mergeArchivo = new FileStream(filenameCompleted, FileMode.CreateNew))
            {
                for (int i = 0; i <archivosCreados.Length; i++)
                {
                    string tmpDir = Path.Combine(_directorio, pathAdicional, $"{fileId}_tmp", $"{i}_{fileId}");
                    using (FileStream parteArchivo = File.OpenRead(tmpDir))
                    {
                        byte[] parteContent = new byte[parteArchivo.Length];

                        parteArchivo.Read(parteContent, 0, (int)parteArchivo.Length);

                        mergeArchivo.Write(parteContent, 0, (int)parteArchivo.Length);
                    }                        
                }
            }

            Directory.Delete(_directorioTrabajo, true);
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

        public CargarArchivoRespuesta GuardarParteArchivoFisico(InformacionParteArchivo archivo)
        {
            CargarArchivoRespuesta result = new CargarArchivoRespuesta();
            if (archivo == null)
            {
                result.Errors.Add("Archivo no valido");
                return result;
            }
                

            try
            {                
                _directorioTrabajo = Path.Combine(_directorio,$"{archivo.PathAdicional}\\{archivo.FileId}_tmp\\" );
                result.DirectoryName = _directorioTrabajo;
                result.chunkIndex = archivo.ChunkIndex;
                result.initialPreviewConfig = new InitialPreviewConfig
                {
                    caption = "Oscar morales"
                };

                if (!Directory.Exists(_directorioTrabajo))
                {
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(_directorioTrabajo);                    
                }
               
                string filename = Path.Combine(_directorioTrabajo, $"{archivo.ChunkIndex}_{archivo.FileId}");

                using (FileStream fileStream = new FileStream(filename, FileMode.CreateNew))
                {
                    // Write the data to the file, byte by byte.
                    for (int i = 0; i < archivo.FileBlob.Length; i++)
                    {
                        fileStream.WriteByte(archivo.FileBlob[i]);
                    }

                    // Set the stream position to the beginning of the file.
                    fileStream.Seek(0, SeekOrigin.Begin);


                    // Read and verify the data.
                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        if (archivo.FileBlob[i] != fileStream.ReadByte())
                        {
                            //TODO: log el problema
                            result.Errors.Add("Error al cargar el archivo");
                            return result;
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                //TODO: Log the error
                result.Errors.Add("Error al cargar el archivo");
                return result;
            }
        }

        public FileStream TraerArchivoFisico(string archivo, string pathAdicional)
        {
            if (string.IsNullOrEmpty(archivo))
            {
                //TODO: log the error
                return null;
            }

            try
            {

                _directorioTrabajo = Path.Combine(_directorio, pathAdicional,archivo);
                if (!File.Exists(_directorioTrabajo))
                {
                    //TODO: log the error
                    return null;
                }

                FileStream fsSource = new FileStream(_directorioTrabajo, FileMode.Open, FileAccess.Read);

                return fsSource;               
            }
            catch (Exception ioEx)
            {
                //TODO: log the error
                return null;
            }
        }
    }
}