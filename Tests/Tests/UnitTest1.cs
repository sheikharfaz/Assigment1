using System.Collections.Generic;
using System.Linq;
using Assignment_Level1.Data;
using Assignment_Level1.helper;
using Assignment_Level1.Models;
using FakeItEasy;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private readonly QueryDBContext _dbContext;

        public Tests(QueryDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        
        public void SelectTest()
        {
            //Arrange

            //var fakeDbService = A.
            //                        Fake<IQuery>();
            //A.
            //    CallTo(() => fakeDbService.Post(
            //        A<QueryParameter>.Ignored
            //        ))
            //    .Returns(
            //    new List<QueryDBContext>
            //    {
            //        new DBset<Student>(),
            //         new DBset<Student>(),
            //         new DBset<Student>(),
            //    }
            //    );
            //var actualRresult = 
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {

            Assert.Pass();
        }

    }
}
