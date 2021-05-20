using Xunit;

namespace TestProject
{
    public class GettersAndExpressionBodies
    {
        public class GettersAndSetters
        {
            public GettersAndSetters()
            {
                FromConstructor = 43;
            }

            public int OnlyGet { get; } = 42;
            public int FromConstructor { get; }

            public int AnythingGoes { get; set; }

            public int AnythingGoesWithDefaultValue { get; set; } = 1;

            public int PrivateSet { get; private set; }

            public void SetPrivateSet(int input)
            {
                PrivateSet = input;
            }

            private int _withBackingField;

            public int WithBackingField
            {
                get { return _withBackingField; }
                set { _withBackingField = value; }
            }

            public int WithInit { get; init; }

            public int IHateUsersOfMyClass
            {
                get { return 66; }
                set { }
            }
        }

        [Fact]
        public void GetSet()
        {
            var sut = new GettersAndSetters {WithInit = 6, AnythingGoes = 7, WithBackingField = 8};

            Assert.Equal(sut.WithInit, 6);
            Assert.Equal(sut.WithBackingField, 8);
            Assert.Equal(sut.AnythingGoesWithDefaultValue, 1);

            sut.AnythingGoesWithDefaultValue = 16;
            Assert.Equal(16, sut.AnythingGoesWithDefaultValue);

            Assert.Equal(66, sut.IHateUsersOfMyClass);
            sut.IHateUsersOfMyClass = 42;
            Assert.Equal(66, sut.IHateUsersOfMyClass);
        }

        // Expression bodies are nicer way to write small methods
        public class ExpressionBodies
        {
            public int SimpleGetter => 42;

            public int DoubleSimpleGetter => 2 * SimpleGetter;

            public int MakeItDouble(int input) => 2 * input;

            public int MakeItDoubleStatementBody(int input)
            {
                return 2 * input;
            }

            private int _gettersAndSettersWorkToo;
            public int GettersAndSettersWorkToo
            {
                get => _gettersAndSettersWorkToo;
                set => _gettersAndSettersWorkToo = value;
            }
        }

        [Fact]
        public void ExpressionBodiesDemos()
        {
            var sut = new ExpressionBodies();
            
            Assert.Equal(42, sut.SimpleGetter);
            Assert.Equal(84, sut.DoubleSimpleGetter);
            Assert.Equal(2, sut.MakeItDouble(1));

            sut.GettersAndSettersWorkToo = 16;
            
            Assert.Equal(16, sut.GettersAndSettersWorkToo);
        }
    }
}