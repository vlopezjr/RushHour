using Microsoft.VisualStudio.TestTools.UnitTesting;
using RushHour.DAL.Initializers;
using RushHour.DAL.Repos;
using RushHour.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.DAL.Tests.RepoTests
{
    [TestClass]
    public class CustomerRepoGetTests : IDisposable
    {
        private readonly CustomerRepo _repo;

        public CustomerRepoGetTests()
        {
            _repo = new CustomerRepo();
            SampleDataInitializer.ClearData(_repo.Context);
            SampleDataInitializer.InitializeData(_repo.Context);
        }
        public void Dispose()
        {
            SampleDataInitializer.ClearData(_repo.Context);
            _repo.Dispose();
        }
        
        [TestMethod]
        public void ShouldGetFirstCustomer()
        {            
            Assert.AreEqual(0, _repo.GetFirst().Id);
            Assert.AreEqual("Best Brakes", _repo.GetFirst().Name);
        }

        [TestMethod]
        public void ShouldGetCustomerCount()
        {
           
            Assert.AreEqual(3, _repo.Count);
           
        }

    }
}
