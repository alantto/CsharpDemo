using Xunit;

namespace TestProject
{
    public class Tuples
    {
        [Fact]
        public void OldTuplesAreStillThere()
        {
            var result = OldTupleDemo();
            
            Assert.True(result.Item1);
            Assert.Equal(42, result.Item2);
        }

        private (bool, int) OldTupleDemo()
        {
            return (true, 42);
        }

        [Fact]
        public void NewOnesAreNicer()
        {
            var result = NewTupleDemo();
            
            // Old way of accessing still works
            Assert.True(result.Item1);
            Assert.Equal(42, result.Item2);
            
            // But this is better
            Assert.True(result.IsSuccess);
            Assert.Equal(42, result.SomeNumber);

            // You can also destruct here
            var (success, number) = NewTupleDemo();

            // Or ignore something with _
            var (_, number2) = NewTupleDemo();
        }

        private (bool IsSuccess, int SomeNumber) NewTupleDemo()
        {
            return (IsSuccess: true, SomeNumber: 42); //  or this still works: return (true, 42); 
        }
    }
}