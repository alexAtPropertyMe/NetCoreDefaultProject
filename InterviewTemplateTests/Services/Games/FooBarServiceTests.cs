using NUnit.Framework;
using InterviewTemplate.Services.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace InterviewTemplate.Services.Games.Tests
{
    [TestFixture()]
    public class FooBarServiceTests
    {
        private IFooBarExecutionFactory _fooBarExecutionFactory;
        private IFooBarGameService _fooBarGameService;

        [OneTimeSetUp]
        public void ClassInit()
        {
            _fooBarExecutionFactory = new FooBarExecutionFactory();
            _fooBarGameService = new FooBarService(_fooBarExecutionFactory);
        }

        [TestCase(1, "foo000", true)]
        [TestCase(3, "foo", true)]
        [TestCase(3, "Foo", true)]
        [TestCase(3, "Bar", false)]
        [TestCase(5, "Bar", true)]
        [TestCase(3, "FooBar", true)]
        [TestCase(5, "FooBar", true)]
        [TestCase(2, "FooBar", false)]
        public void ExecuteGameTest(int position, string answer, bool expectedResult)
        {
            // Arrange


            // Act
            var result = _fooBarGameService.ExecuteGame(new Domain.Games.FooBar { 
                Position = position,
                Answer = answer
            });

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}