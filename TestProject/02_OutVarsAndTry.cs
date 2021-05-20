using System;
using Xunit;

namespace TestProject
{
    public class OutVarsAndTry {

        [Fact]
        public void MultipleThingsCanBeReturnedWithOutVars()
        {
            /*
             * Here we get two values. One as normal return, and other from out variable. Note that out must be specified
             * also on calling end.
             */
            var result22 = TryStupidParse("22", out var number);
            
            Assert.True(result22);
            Assert.Equal(22, number);
            
            // There won't be meaningful value in out var, so we can use _ which, discards the result
            var resultFoo = TryStupidParse("foo", out _);
            Assert.False(resultFoo);
        }
        
        // TryXYZ is a C# pattern, where return value is true, if operation is successful and out var contains some
        // result, which usually only has meaningful value, if operation was successful
        private bool TryStupidParse(string input, out int result)
        {
            if (input == "42")
            {
                throw new Exception();
            }

            try
            {
                result = int.Parse(input);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            result = 0; // out variables must always be set
            return false;
        }
    }
}