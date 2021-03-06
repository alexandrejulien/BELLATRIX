﻿////using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Bellatrix.Web.Tests
{
    [SetUpFixture]
    public class TestsInitialize
    {
        // Uncomment if you want to use MSTest
        ////[AssemblyCleanup]
        [OneTimeTearDown]
        public void AssemblyCleanUp()
        {
            var app = ServicesCollection.Current.Resolve<App>();
            app.Dispose();
        }
    }

    // Uncomment if you want to use MSTest
    ////[TestClass]
    ////public class TestsInitialize
    ////{
    ////    [AssemblyInitialize]
    ////    public static void AssemblyInitialize(TestContext testContext)
    ////    {
    ////        App.StartWinAppDriver();
    ////    }

    ////    [AssemblyCleanup]
    ////    public static void AssemblyCleanUp()
    ////    {
    ////        var app = ServicesCollection.Current.Resolve<App>();
    ////        app.Dispose();
    ////    }
    ////}
}
