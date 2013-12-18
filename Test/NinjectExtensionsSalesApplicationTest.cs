﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;
using System.Diagnostics;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;
using SalesApplication.Data.Model;

namespace Test
{
    /// <summary>
    /// [TestFixture] for Ninject.Extensions.SalesApplication bindings.
    /// </summary>
    [TestFixture]
    public class NinjectExtensionsSalesApplicationTest
    {
        IKernel _kernel;
        ISalesAppData _iSalesAppData;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            Debugger.Launch();
             _kernel = new StandardKernel();         
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {

        }

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void DataBindingAndCompositionTest()
        {
            _iSalesAppData = _kernel.TryGet<ISalesAppData>();    
          
            Assert.IsInstanceOf<CapwairData>(_iSalesAppData);
            // verify that the impl of the ORM is what we expect
            Assert.AreEqual(typeof(DapperAdapter), _iSalesAppData.ORM);

            IList<Customer> customers = _iSalesAppData.GetAllCustomers();
        }
    }
}