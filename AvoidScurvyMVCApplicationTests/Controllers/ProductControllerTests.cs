using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvoidScurvyMVCApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvoidScurvyMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvoidScurvyMVCApplication.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void AddProductPostTestIfInvalidModelReturnsPostViewWithSameObject()
        {
            //Arrange
            ProductController testController = new ProductController(null, null,null);
            Product invalidProduct = new Product()
            {
                ProductID = 10,
                Calories = 100,
                Name = "2L",
                StarRating = 5,
                UPC = "testUPC",
                VitCDailyAmount = -100
            };
            //Act
            ViewResult view = (ViewResult)testController.AddProductPost(invalidProduct);
            //Assert
            Assert.AreEqual("AddProduct", view.ViewName);
            Assert.AreSame(view.Model, invalidProduct);
        }
    }
}