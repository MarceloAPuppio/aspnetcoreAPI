using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL
{
    public static class ServerFileManager
    {
        public static void guardar(string path, IFormFile archivo)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                //TODO:analizar la opcion ASyncCopyto ... para eso tengo que hacer el método async, pero sin el await para que no me trabe todo... o no se, para eso tengo que hacer un task
                archivo.CopyTo(fileStream);
            }

        }

    }
}
