using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class DALUsuarioTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            var DALUsuario = new DALUsuario();
            int expected = 1;
            int actual = DALUsuario.Create(new EL.Usuario() { Nombre = "Marcelitoooo", Password = "ioooooooooooooooooooooooooo" });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest()
        {
            var DALUsuario = new DALUsuario();
            int expected = 6;
            int actual = DALUsuario.Login("Password", "Test");
            Assert.AreEqual(expected, actual);
        }
    }
}