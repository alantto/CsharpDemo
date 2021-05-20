using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class Linq
    {
        private IEnumerable<int> _demoCollection = new int[] {1, 3, 4, 7, 16, 32, 42, 66, 78};

        [Fact]
        public void MapAkaSelect()
        {
            var result = _demoCollection.Take(3).Select(x => x * 3);

            Assert.Collection(result,
                item => Assert.Equal(3, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(12, item));
        }

        [Fact]
        public void FilterAkaWhere()
        {
            var result = _demoCollection.Where(x => x == 42);

            Assert.Equal(1, result.Count());
            Assert.Equal(42, result.First());
        }

        [Fact]
        public void FirstAndSingle()
        {
            var collection = new int[] {1, 2, 2};
            
            // Single checks that there is exactly one element that matches
            var findSingleOneResult = collection.Single(x => x == 1);
            Assert.Equal(1, findSingleOneResult);
            
            // If there is more, then exception is thrown
            Action findSingleTwo = () => { _ = 
                collection.Single(x => x == 2);
            };
            Assert.Throws<InvalidOperationException>(findSingleTwo);
            
            // Single also throws if no element is found
            Action findSingleThree = () => { _ = 
                collection.Single(x => x == 3);
            };
            Assert.Throws<InvalidOperationException>(findSingleThree);
            
            // SingleOrDefault returns default, if no element is found
            var threeOrDefaultResult = collection.SingleOrDefault(x => x == 3);
            Assert.Equal(0, threeOrDefaultResult); // Would be null for objects
            
            
            // If you don't care how many there are, then use .First
            var firstTwoResult = collection.First(x => x == 2);
            Assert.Equal(2, firstTwoResult);
            
             // First also throws if no element is found
            Action firstThree = () => { _ = 
                collection.First(x => x == 3);
            };
            Assert.Throws<InvalidOperationException>(firstThree);
            
            // And again, .FirstOrDefault returns default if no element is found
            var firstOrDefaultThree = collection.FirstOrDefault(x => x == 3);
            Assert.Equal(0, firstOrDefaultThree);
        }
    }
}