using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using EL;

namespace BLL
{
    public class BLLUsuario
    {
        public Usuario Login(Usuario obj)
        {
            DALUsuario DALU = new DALUsuario();
            DALUsuarioRol DALUR = new DALUsuarioRol();
            int ID = DALU.Login(obj.Password, obj.Nombre);
            if(ID>0) {
                var usuario = DALU.ReadOne(ID);
                usuario.Roles = DALUR.ReadAllByUsuario(usuario.ID);
                return usuario;
            }
            return new Usuario();
        }

        public List<Usuario> ReadAll()
        {
            DALUsuario DALU = new DALUsuario();
            DALUsuarioRol DALUR = new DALUsuarioRol();
            var Usuarios = DALU.ReadAll();
            foreach(var usuario in Usuarios)
            {
                usuario.Roles = DALUR.ReadAllByUsuario(usuario.ID);
            }
            return Usuarios;
        }
        public Usuario ReadOne(int ID)
        {
            DALUsuario DALU = new DALUsuario();
            DALUsuarioRol DALUR = new DALUsuarioRol();
            var Usuario = DALU.ReadOne(ID);
            Usuario.Roles = DALUR.ReadAllByUsuario(Usuario.ID);
            return Usuario;
        }
    }
}
