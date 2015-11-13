﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Veil.Controllers;
using Veil.DataAccess.Interfaces;
using Veil.DataModels.Models;
using Veil.Helpers;
using Veil.Models;

namespace Veil.Tests.Controllers
{
    [TestFixture]
    class CartControllerTests
    {
        private Guid Id;
        private Guid UserId;

        [SetUp]
        public void Setup()
        {
            Id = new Guid("45B0752E-998B-466A-AAAD-3ED535BA3559");
            UserId = new Guid("09EABF21-D5AC-4A5D-ADF8-27180E6D889B");
        }

        [Test]
        public async void Index_ReturnsMatchingModel()
        {
            PhysicalGameProduct gameProduct = new PhysicalGameProduct()
            {
                Id = Id,
                BoxArtImageURL = "boxart",
                NewWebPrice = 12m,
                UsedWebPrice = 8m,
                Platform = new Platform
                {
                    PlatformName = "XBAX",
                }
            };

            Cart cart = new Cart
            {
                MemberId = UserId,
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        Product = gameProduct,
                        ProductId = gameProduct.Id,
                        IsNew = true,
                        MemberId = UserId,
                        Quantity = 1
                    },
                    new CartItem
                    {
                        Product = gameProduct,
                        ProductId = gameProduct.Id,
                        IsNew = false,
                        MemberId = UserId,
                        Quantity = 2
                    }
                }
            };

            Mock<IVeilDataAccess> dbStub = TestHelpers.GetVeilDataAccessFake();
            Mock<DbSet<Cart>> cartDbSetStub = TestHelpers.GetFakeAsyncDbSet(new List<Cart> { cart }.AsQueryable());
            cartDbSetStub.Setup(db => db.FindAsync(cart.MemberId)).ReturnsAsync(cart);
            dbStub.Setup(db => db.Carts).Returns(cartDbSetStub.Object);

            Mock<ControllerContext> context = new Mock<ControllerContext>();
            context.Setup(c => c.HttpContext.User.Identity).Returns<IIdentity>(null);
            context.Setup(c => c.HttpContext.User.Identity.IsAuthenticated).Returns(true);

            Mock<IGuidUserIdGetter> idGetterStub = new Mock<IGuidUserIdGetter>();
            idGetterStub.Setup(id => id.GetUserId(It.IsAny<IIdentity>())).Returns(UserId);

            CartController controller = new CartController(dbStub.Object, idGetterStub.Object)
            {
                ControllerContext = context.Object
            };

            var result = await controller.Index() as ViewResult;

            Assert.That(result != null);
            Assert.That(result.Model, Is.InstanceOf<Cart>());

            var model = (Cart)result.Model;

            Assert.That(model.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items.FirstOrDefault(i => i.IsNew).ProductId, Is.EqualTo(Id));
            Assert.That(model.Items.FirstOrDefault(i => !i.IsNew).ProductId, Is.EqualTo(Id));
            Assert.That(model.Items.FirstOrDefault(i => i.IsNew).Quantity, Is.EqualTo(1));
            Assert.That(model.Items.FirstOrDefault(i => !i.IsNew).Quantity, Is.EqualTo(2));
        }
    }
}
