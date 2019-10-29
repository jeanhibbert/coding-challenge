using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConstructionLine.CodingChallenge.Tests.SampleData;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEnginePerformanceTests : SearchEngineTestsBase
    {
        private List<Shirt> _shirts;
        private SearchEngine _searchEngine;

        [SetUp]
        public void Setup()
        {
            
            var dataBuilder = new SampleDataBuilder(50000);

            _shirts = dataBuilder.CreateShirts();

            _searchEngine = new SearchEngine(_shirts);
        }


        [Test]
        public void PerformanceTest_WhenSearchingForSingleColor()
        {
            var sw = new Stopwatch();
            sw.Start();

            var options = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = _searchEngine.Search(options);

            sw.Stop();
            Console.WriteLine($"Test fixture finished in {sw.ElapsedMilliseconds} milliseconds");

            AssertResults(results.Shirts, options);
            AssertSizeCounts(results.Shirts, options, results.SizeCounts);
            AssertColorCounts(results.Shirts, options, results.ColorCounts);
        }

        [Test]
        public void PerformanceTest_WhenSearchOptionsNotProvided_ThrowsArgumentException()
        {
            SearchOptions options = null;

            Assert.Throws<ArgumentException>(() =>
            {
                _searchEngine.Search(options);
            });
        }

        [Test]
        public void PerformanceTest_WhenColorsNotProvided_ThrowsArgumentException()
        {
            var options = new SearchOptions
            {
                Colors = null
            };
            
            Assert.Throws<ArgumentException>(() =>
            {
                _searchEngine.Search(options);
            });
        }

        [Test]
        public void PerformanceTest_WhenSizesNotProvided_ThrowsArgumentException()
        {
            var options = new SearchOptions
            {
                Sizes = null
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _searchEngine.Search(options);
            });
        }
    }
}
