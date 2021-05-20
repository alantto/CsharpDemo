using System;
using Xunit;

namespace TestProject
{
    public class NullAndFriends {
        
        [Fact]
        public void NullsEveryWhere()
        {
            // By default reference values can be null
            string nullString = default;
            Assert.Null(nullString);
            
            // Values can't be null by default
            int number = default;
            Assert.NotNull(number);
            Assert.Equal(0, number);
            
            // Structs can't be null
            DateTime notNullDt = default;
            Assert.NotNull(notNullDt);

            // notNullDt = null; // does not compile

            // Anything can be made nullable
            DateTime? nullDt = default;
            Assert.Null(nullDt);
            Assert.False(nullDt.HasValue);

            int? nullNumber = default;
            Assert.Null(nullNumber);
        }

        [Fact]
        public void IsThisNull()
        {
            string nullStr = null;
            
            Assert.True(nullStr is null);
            Assert.True(nullStr == null); // == is operator and can be overwritten, so this might not work as expected. Usually it does
            
            string notNullStr = string.Empty;
            
            Assert.True(notNullStr is not null);
            Assert.True(notNullStr != null);
        }

        [Fact]
        public void MoreNullChecks()
        {
            string nullStr = null;
            string realStr = "lakjdflkjadl";

            var first = nullStr ?? realStr; // Takes second if first one is null
            Assert.Equal(realStr, first);
            
            var second = nullStr ?? null ?? DemoMethod() ?? realStr; // Takes first one that is not null
            Assert.Equal(realStr, second);

            var third = nullStr;
            third ??= realStr;
            Assert.Equal(realStr, third);
        }

        private string DemoMethod()
        {
            return null;
        }
    }
}