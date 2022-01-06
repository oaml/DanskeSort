using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAPI.Services.SortingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAPI.Services.SortingService.Tests
{
    [TestClass()]
    public class BubbleSortServiceTests
    {
        private BubbleSortService _bubbleSortService = new BubbleSortService();

        [TestMethod()]
        public void EmptyInput()
        {
            var input = new List<int>();

            var result = _bubbleSortService.Sort(input);

            Assert.IsTrue(!result.Any());
        }

        [TestMethod()]
        public void SortTest()
        {
            var input = new List<int> { 5, 2, 8, 10, 1 };

            var result = _bubbleSortService.Sort(input);

            var expectedResult = new List<int>() { 1, 2, 5, 8, 10 };

            Assert.IsTrue(Enumerable.SequenceEqual(result, expectedResult));
        }
    }
}