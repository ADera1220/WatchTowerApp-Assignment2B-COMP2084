using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTowerWebApp.Controllers;
using WatchTowerWebApp.Data;
using WatchTowerWebApp.Models;

namespace WatchTowerWebAppTests
{
    [TestClass]
    public class ShowsControllerTests
    {
        // We need to create an In-Memory Database Context > Microsoft.EntityFrameworkCore.InMemory
        private ApplicationDbContext _context;

        // Generate an empty list of Shows
        List<Show> shows = new List<Show>();

        // Declare the Controller that will be used in the tests
        ShowsController controller;

        // TestInitialize functions as a constructor for the test controller
        [TestInitialize]
        public void TestInitialize()
        {
            // This creates an in-memory database
            var options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid()
                    .ToString())
                    .Options;

            // The _context variable is now properly instantiated as having Database context
            _context = new ApplicationDbContext(options);

            // CREATE MOCK DATA

            // Show has dependencies on Services and Co-Watchers
            var service = new Service
            {
                Id = 111,
                Name = "Netflix",
                Type = "Streaming",
                Platform = "Chromecast"
            };

            var coWatcher = new CoWatcher
            {
                Id = 222,
                FirstName = "Adam",
                LastName = "Dera"
            };

            // Mock dependencies are saved to context
            _context.Add(service);
            _context.Add(coWatcher);
            _context.SaveChanges();

            // Create 3 mock Show records to use for testing
            shows.Add(new Show
            {
                Id = 100,
                Title = "Stranger Things",
                ServiceId = 111,
                CoWatcherId = 222
            });

            shows.Add(new Show
            {
                Id = 101,
                Title = "The Witcher",
                ServiceId = 111,
                CoWatcherId = 222
            });

            shows.Add(new Show
            {
                Id = 102,
                Title = "Bojack Horseman",
                ServiceId = 111,
                CoWatcherId = 222
            });

            // Use foreach() to push the mock records into the the _context file
            foreach (var s in shows)
            {
                _context.Shows.Add(s);
            }

            // Show records are saved to _context
            _context.SaveChanges();

            // Controller is instantiated with mock context file
            controller = new ShowsController(_context);
        }

        // This project will test the GET: Delete method of the ShowsController

        // Test 1: Does the "Delete" View load?
        [TestMethod]
        public void DeleteViewLoads()
        {
            // Run the Delete Method with a specified show
            var result = controller.Delete(100);
            // Save the result as a ViewResult
            var viewResult = (ViewResult)result.Result;

            // Assert that the View is tagged as "Delete"
            Assert.AreEqual("Delete", viewResult.ViewName);
        }

        // Test 2: Tests if the correct "Show" record is loaded onto the page
        [TestMethod]
        public void CorrectRecordInDelete()
        {
            // We choose a specific show - the one with ID: 100
            var expectedShow = shows[0];
            // Pass the ID of the chosen show into the Method
            var result = controller.Delete(100);
            // Grab the ViewResult of the outcome, which is the Show data retrieved
            var loadedShow = (ViewResult)result.Result;

            //Assert that the show we specified is what is stored in the result
            Assert.AreEqual(expectedShow, loadedShow.ViewData.Model);
        }

        // Test 3: If ID=null, tests if app returns NotFound()
        [TestMethod]
        public void NullIDReturnsNotFound()
        {

            // Pass a null value into the Delete Method
            var result = controller.Delete(null);
            // Convert the result into a NotFoundResult and store it
            var notFoundResult = (NotFoundResult)result.Result;

            //Assert that the page will return a 404 error
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        // Test 4: If an INVALID ID is presented, test if app returns not found
        [TestMethod]
        public void InvalidIDReturnsNotFound()
        {
            // Pass an Invalid ID into the .Delete() Method and store the result
            var result = controller.Delete(999);
            // Convert the result into a NotFoundResult and store it
            var notFoundResult = (NotFoundResult)result.Result;

            //Assert that the page will return a 404 error
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}
