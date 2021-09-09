using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EL;
using BLL;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using System.Net;

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace User.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class USERController : ControllerBase
    {
        private readonly IJWTHandler JWTAuth;
        //para poder acceder a las carpetas "raíz" debo crear esta variable de entorno, la cual debe inicializarse con el ctor.
        private readonly IWebHostEnvironment _webHostEnvironment;
        public USERController(IJWTHandler jWTHandler, IWebHostEnvironment hostEnvironment)
        {
            this.JWTAuth = jWTHandler;
            this._webHostEnvironment = hostEnvironment;
            
        }
        // GET: api/USER
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            var BLLU= new BLLUsuario();
            var usuarios = BLLU.ReadAll();
            return Ok(JsonSerializer.Serialize(usuarios));
        }

        // GET: api/USER/5
        [Authorize(Roles ="SysAdmin")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            var BLLU = new BLLUsuario();
            var usuario = BLLU.ReadOne(id);
            return JsonSerializer.Serialize(usuario);
        }
        // POST: api/USER/Authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] Usuario usuario)
        {
            var token = JWTAuth.Authenticate(usuario);

            if (token == null)
                return Unauthorized();
            var BLLU = new BLLUsuario();
            var usuarioLogueado = BLLU.Login(usuario);
            usuarioLogueado.Password = "";
            //TODO: Creo que me conviene agregar como claims la url de la foto, el nombre del usuario y el Id. De esa manera, cuando va a su perfil hsace un get con ese ID
            //Creo que no sirve... porque el claim del jwt no me permite saber los valores a menos que lo decodifique
            return Ok($"{{\"Token\":\"{token}\",\"Data\":{JsonSerializer.Serialize(usuarioLogueado)}}}");
            //return Ok(token + JsonSerializer.Serialize(usuario));
        }
        // POST: api/USER
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromForm] Usuario usuario)
        {
            //creo la base, que dirigirá al directorio donde queremos guardar las imagenes.
            string basePath = @"StaticFiles\images\usuarios";
            //instancio el path donde se encuetra WebRootPath, que es donde están las carpetas que se comparten al cliente, mediante peticiones.
            var serverPath = _webHostEnvironment.ContentRootPath;

            if (Request.Form.Files.Count > 0) /*Si hay archivos entra en el if*/
            {
                //como subiremos una foto... nos interesa la pos 0
                var file = Request.Form.Files[0];
                //TODO: ver cómo carajos meterle el id... quizas deba hacer el insert para obtener el ID, y luego un update... para poner la oURL.
                //var fileName = $"{objProd.ID}_" + Path.GetFileName(file.FileName);
                var fileName = Path.GetFileName(file.FileName);
                var oPath = Path.Combine(serverPath, basePath, fileName);
                //sin esto, no me iba a la raiz de localhost...
                //var oURL = Path.Combine(@"../", basePath, fileName);
                var oURL = Path.Combine("images\\usuarios", fileName);

                //Abre un filestream filemode.create.
                ServerFileManager.guardar(oPath, file);
                //TODO:seguir video https://youtu.be/YgbGIj6PpRY?t=592
                //aqui asigno oURL al objeto que se guardará en la BBDD-
                //objProd.Image = oURL;
                //pbl.Insertar(objProd);
                return Ok(oURL);

            }
            else
            {
                var oPath = Path.Combine(serverPath, basePath, "default.png");
                //var oURL = Path.Combine(@"../", basePath, "default.png");
                var oURL = Path.Combine("images", "default.png");


                return Ok(oURL);

            }
        }


        // PUT: api/USER/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
