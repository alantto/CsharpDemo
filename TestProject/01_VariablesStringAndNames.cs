using Xunit;

namespace TestProject
{
    // Class and method names should use PascalCase
    public class VariablesStringsAndNames
    {
        // local fields should be prefixed with _ or if you hate them, then we can change settings
        private string _firstString = "foo";
        
        // Fields can be made readonly. Readonly fields can only be initialized in constructor or on creation
        private readonly string _readonlyString = "bar";

        [Fact]
        public void Variables()
        {
            // local variables are camelCased without prefix
            int something = 42;
            var somethingElse = 43;
            var somethingDifferent = "LetCompilerFigureTheseOut";

            // var foo = null; Does not compile, since there is not enough information
            string foo = null;
        }
        
        [Fact]
        public void AllConcatenationWaysProduceSameResult()
        {
            var secondString = "bar";
            var classic = _firstString + " and " + secondString;
            var format = string.Format("{0} and {1}", _firstString, secondString);
            
            // Add $ before " and you can use {varName} inside string
            var modern = $"{_firstString} and {secondString}";
            
            Assert.Equal(classic, format);
            Assert.Equal(classic, modern);
        }

        [Fact]
        public void VerbatimStringsAreNice()
        {
            var escapedString = "c:\\Program Files\\Microsoft Visual Studio 9.0";
            var verbatimString = @"c:\Program Files\Microsoft Visual Studio 9.0"; 
            
            Assert.Equal(escapedString, verbatimString);

            var version = "9.0";
            
            // @ and $ can be combined
            var reallyGreatString = @$"c:\Program Files\Microsoft Visual Studio {version}"; 
            Assert.Equal(escapedString, reallyGreatString);
        }
    }
}