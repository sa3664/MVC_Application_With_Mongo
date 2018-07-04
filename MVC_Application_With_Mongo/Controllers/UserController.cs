using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MVC_Application_With_Mongo.Models;

namespace MVC_Application_With_Mongo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel um)
        {

            //Connect to MongoDB
            var connectionString = "mongodb://localhost";
            MongoClient client = new MongoClient(connectionString);
            MongoServer objServer = client.GetServer();

            //MongoServer objServer = MongoServer.Create("Server=localhost:27017");
            //Provide a database name(Mongo server will automatically check a
            //database with this name while inserting.
            //if exist then ok otherwise it will  automatically create a database)
            MongoDatabase objDatabse = objServer.GetDatabase("MVCTestDB");
            //Provide a table Name(Mongo will create a table with this name.
            //if its already exist then mongo will insert in this table otherwise
            //it will create a table with this name and then Mongo will insert)
            MongoCollection<BsonDocument> UserDetails = objDatabse.GetCollection<BsonDocument>("Users");
            //Insert into Users table.
            UserDetails.Insert<UserModel>(um);
            return View();
        }
        //[HttpGet]
        //public ActionResult GetUsers()
        //{
        //    var connectionString = "mongodb://localhost";
        //    MongoClient client = new MongoClient(connectionString);
        //    MongoServer objServer = client.GetServer();
        //    MongoDatabase objDatabse = objServer.GetDatabase("MVCTestDB");
        //    var UserDetails = objDatabse.GetCollection("Users").FindAll().ToList();
        //    return View(UserDetails);
        }
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var connectionString = "mongodb://localhost";
        //    MongoClient client = new MongoClient(connectionString);
        //    MongoServer objServer = client.GetServer();
        //    MongoDatabase objDatabse = objServer.GetDatabase("MVCTestDB");
        //    IMongoQuery query = Query.EQ("ID", id);
        //    objDatabse.GetCollection("Users").Remove(query);
        //    return View();
        //}
        //[HttpPut]
        //public ActionResult Edit(int id)
        //{
        //    var connectionString = "mongodb://localhost";
        //    MongoClient client = new MongoClient(connectionString);
        //    MongoServer objServer = client.GetServer();
        //    MongoDatabase objDatabse = objServer.GetDatabase("MVCTestDB");
        //    IMongoQuery query = Query.EQ("ID", id);
        //    UserModel user = objDatabse.GetCollection("Users").Find(query).SingleOrDefault();
        //    return View(user);
        //}
    }
}