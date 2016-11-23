using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testeando;


namespace Testeandoo
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]   
        public void InstanciaEstacionamiento()
        {
            Estacionamiento est1 = new Estacionamiento();
            Assert.IsNotNull(est1);            
        }
        

        public void ListadoInstanciado()
        {
            Estacionamiento est1 = new Estacionamiento();
            Assert.IsNotNull(est1.listaVehiculos);
        }
    }
}
