using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL;
using EL;


namespace User
{
    public interface IJWTHandler
        {
            string Authenticate(Usuario usuario);

        }
    public class JWTHandler : IJWTHandler
    {

        private readonly string tokenKey;
        BLLUsuario BLLU;
        public JWTHandler(string tokenKey)
        {
            this.tokenKey = tokenKey;
            this.BLLU = new BLLUsuario();
        }

        public string Authenticate(Usuario usuario)
        {
            var LoggedUser= BLLU.Login(usuario);
            //si da 0 es porque la función devolvío un usuario nulo
            if (LoggedUser.ID == 0) return null;
            //creo una lista de Claims
            var claims = new List<Claim>();
            //agrego el nombre del usuario
            claims.Add(new Claim(ClaimTypes.Name, LoggedUser.Nombre));
            //y una lista con todos los roles del mismo
            foreach(var rol in LoggedUser.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol.Nombre));

            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
