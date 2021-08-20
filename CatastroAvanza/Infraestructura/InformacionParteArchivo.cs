using System.IO;
using System.Web;

namespace CatastroAvanza.Infraestructura
{
    public class InformacionParteArchivo
    {
        public InformacionParteArchivo(string fileRelativePath, string fileId, HttpPostedFileBase file, double fileSize,
            string fileName, int chunkIndex, double chunkSize, double chunkSizeStart, int chunkCount, int retryCount, string pathAdicional)
        {
            FileRelativePath = fileRelativePath;
            FileId = fileId;            
            FileName = fileName;
            FileSize = fileSize;
            ChunkIndex = chunkIndex;
            ChunkSize = chunkSize;
            ChunkSizeStart = chunkSizeStart;
            ChunkCount = chunkCount;
            RetryCount = retryCount;
            PathAdicional = pathAdicional;

            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            FileBlob = target.ToArray();
        }

        public string FileRelativePath { get;  }

        public string FileId { get;  }

        public byte[] FileBlob { get;  }

        public string FileName { get;  }

        public double FileSize { get;  }

        public int ChunkIndex { get;  }

        public double ChunkSize { get;  }

        public double ChunkSizeStart { get;  }

        public int ChunkCount { get;  }

        public int RetryCount { get;  }

        public string PathAdicional { get;  }

    }
}