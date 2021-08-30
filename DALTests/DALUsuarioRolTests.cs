using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class DALUsuarioRolTests
    {
        [TestMethod()]
        public void ReadAllByUsuarioTest()
        {
            var DALUsuarioRol = new DALUsuarioRol();
            int expected = 2;
            int actual=DALUsuarioRol.ReadAllByUsuario(2).Count;
            Assert.AreEqual(expected, actual);
        }
    }
}