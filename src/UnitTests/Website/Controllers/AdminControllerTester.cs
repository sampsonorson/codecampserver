﻿using System.Web.Mvc;
using CodeCampServer.Model;
using CodeCampServer.Model.Domain;
using CodeCampServer.Model.Security;
using CodeCampServer.Website.Controllers;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace CodeCampServer.UnitTests.Website.Controllers
{
    [TestFixture]
    public class AdminControllerTester
    {
        private MockRepository _mocks;
        private IAuthorizationService _authorizationService;
        private IConferenceRepository _conferenceRepository;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _authorizationService = _mocks.DynamicMock<IAuthorizationService>();
            _conferenceRepository = _mocks.CreateMock<IConferenceRepository>();
        }

        [Test]
        public void IndexActionRendersDefaultView()
        {
            var controller = getController();
            var result = controller.Index() as ViewResult;

            if(result == null) 
                Assert.Fail("expected renderview");

            Assert.That(result.ViewName, Is.Null);
        }

        private AdminController getController()
        {
            var controller = new AdminController(_authorizationService, _conferenceRepository)
                       {                           
                           ViewEngine = new ViewEngineStub()
                       };

            controller.ControllerContext = new ControllerContextStub(controller);
            return controller;
        }

    }
}