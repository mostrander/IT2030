using System;
using System.Linq;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using System.Data.Entity;

namespace MovieStore.Tests.Controllers
{
   [TestClass]
   public class MovieStoreControllerTest
   {
      [TestMethod]
      public void MovieStore_Index_TestView()
      {
         //arrange

         MoviesController controller = new MoviesController();

         //act

         ViewResult result = controller.Index() as ViewResult;

         //assert
         Assert.IsNotNull(result);

      }


      [TestMethod]
      public void MovieStore_ListOfMovies_Test()
      {
         //arrange

         MoviesController controller = new MoviesController();

         //act

         List<Movie> result = controller.ListOfMovies();

         //assert
         Assert.IsNotNull(result);
         Assert.AreEqual(expected: "Iron Man 1", actual: result[0].Title);
         Assert.AreEqual(expected: "Iron Man 2", actual: result[1].Title);
         Assert.AreEqual(expected: "Iron Man 3", actual: result[2].Title);
      }


      [TestMethod]
      public void MovieStore_Index_Redirect_Success()
      {
         //arrange

         MoviesController controller = new MoviesController();

         //act

         RedirectToRouteResult result = controller.IndexRedirect(id:1) as RedirectToRouteResult;

         //assert
         Assert.IsNotNull(result);
         Assert.AreEqual("Create", result.RouteValues["action"]);
         Assert.AreEqual("HomeController", result.RouteValues["controller"]);
      }

      [TestMethod]
      public void MovieStore_Index_Redirect_Failure()
      {
         //arrange

         MoviesController controller = new MoviesController();

         //act

         HttpStatusCodeResult result = controller.IndexRedirect(id:0) as HttpStatusCodeResult;

         //assert
         Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
      }


      [TestMethod]
      public void MovieStore_ListFromDb()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Superman 1"},
                  new Movie{MovieId = 2, Title = "Superman 2"},
               }.AsQueryable();
            ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         ViewResult result = controller.ListFromDb() as ViewResult;
         List<Movie> resultMovies = result.Model as List<Movie>;

         //assert
         Assert.IsNotNull(result);
      }


      [TestMethod]
      public void MovieStore_Details_Success()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Superman 1"},
                  new Movie{MovieId = 2, Title = "Superman 2"},
               }.AsQueryable();
         ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         ViewResult result = controller.Details(id:1) as ViewResult;
         

         //assert
         Assert.IsNotNull(result);
      }

      [TestMethod]
      public void MovieStore_Details_IdIsNull()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Superman 1"},
                  new Movie{MovieId = 2, Title = "Superman 2"},
               }.AsQueryable();
         ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         HttpStatusCodeResult result = controller.Details(id: null) as HttpStatusCodeResult;


         //assert
         Assert.IsNotNull(result);
         Assert.AreEqual(expected: HttpStatusCode.BadRequest, actual: (HttpStatusCode)result.StatusCode);
      }

      [TestMethod]
      public void MovieStore_Details_MovieIsNull()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Superman 1"},
                  new Movie{MovieId = 2, Title = "Superman 2"},
               }.AsQueryable();
         ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

         Movie movie = null;

         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(movie);

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         HttpStatusCodeResult result = controller.Details(id: 0) as HttpStatusCodeResult;


         //assert
         Assert.IsNotNull(result);
         Assert.AreEqual(expected: HttpStatusCode.NotFound, actual: (HttpStatusCode)result.StatusCode);
      }


      [TestMethod]
      public void MovieStore_Create_TestView()
      {
         //arrange

         MoviesController controller = new MoviesController();

         //act

         ViewResult result = controller.Create() as ViewResult;

         //assert
         Assert.IsNotNull(result);

      }


      [TestMethod]
      public void MovieStore_Edit_Get_IdIsNull()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Animal Crossing XL"},
                  new Movie{MovieId = 2, Title = "Super Mario Bros"},
               }.AsQueryable();
         ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         HttpStatusCodeResult result = controller.Edit(id: null) as HttpStatusCodeResult;


         //assert
         Assert.IsNotNull(result);
         Assert.AreEqual(expected: HttpStatusCode.BadRequest, actual: (HttpStatusCode)result.StatusCode);

      }

      [TestMethod]
      public void MovieStore_Edit_Get_MovieIsNull()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Animal Crossing XL"},
                  new Movie{MovieId = 2, Title = "Super Mario Bros"},
               }.AsQueryable();
         ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

         //this is required for this method to function properly, will not simply take id number
         Movie movie = null;
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(movie);

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         HttpStatusCodeResult result = controller.Edit(id: 0) as HttpStatusCodeResult;


         //assert
         Assert.IsNotNull(result);
         Assert.AreEqual(expected: HttpStatusCode.NotFound, actual: (HttpStatusCode)result.StatusCode);

      }

      [TestMethod]
      public void MovieStore_Edit_Get_Success()
      {
         // Goal: Query from our own list instead of database
         //step 1:
         var list = new List<Movie>
               {
                  new Movie{MovieId = 1, Title = "Animal Crossing XL"},
                  new Movie{MovieId = 2, Title = "Super Mario Bros"},
               }.AsQueryable();
         ;

         // step 2
         Mock<MovieStoreDBContext> mockContext = new Mock<MovieStoreDBContext>();
         Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

         //step 3
         mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
         mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
         mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

         //this is required for this method to function properly, will not simply take id number
         mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

         //step 4
         mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);


         //arrange
         MoviesController controller = new MoviesController(mockContext.Object);

         //act
         ViewResult result = controller.Edit(id: 1) as ViewResult;


         //assert
         Assert.IsNotNull(result);

         //test that it is recieving correct value?
      }






   }
}
