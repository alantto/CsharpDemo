using System;
using Xunit;

namespace TestProject
{
    public class ClassesAndInterfaces
    {
        /*
         * Interfaces are named ISomething
         * C# interfaces also support default implementations, static methods and all sorts of fancy stuff
         * Keep interfaces simple and small, and only use fancy things if really required
         */
        public interface IMinimalInterface
        {
            bool SomeMethod();
        }

        public abstract class AbstractBaseClass
        {
            protected abstract string ThisMustBeImplementedByInheritingClass();

            // Unlike Java, C# requires you to mark methods you are allowed to override
            public virtual string ThisCanBeOverridenByInheritingClass()
            {
                return ThisMustBeImplementedByInheritingClass() + ThisMustBeImplementedByInheritingClass();
            }

            public string ThisCantBeOverriden()
            {
                return ThisMustBeImplementedByInheritingClass();
            }
        }

        public class DemoClass : AbstractBaseClass, IMinimalInterface
        {
            protected override string ThisMustBeImplementedByInheritingClass() => "A";

            public override string ThisCanBeOverridenByInheritingClass()
            {
                return base.ThisCanBeOverridenByInheritingClass() + ThisMustBeImplementedByInheritingClass();
            }

            public bool SomeMethod() => true;
        }
        
        public class InheritedClass : DemoClass{}
        
        public class UnrelatedClass {}

        [Fact]
        public void DemoClassTests()
        {
            DemoClass sut = new DemoClass(); // looks like Java :(
            var sut1 = new DemoClass(); // Better
            DemoClass sut2 = new(); // New way  in C#, nice if you have multiple generics in use

            Assert.True(sut.SomeMethod());
            Assert.Equal("AAA", sut.ThisCanBeOverridenByInheritingClass());
        }

        [Fact]
        public void ClassesAreValidAsTheirParentClass()
        {
            DemoClass demo = new DemoClass();
            Assert.IsType<DemoClass>(demo);
            Assert.IsType<IMinimalInterface>(demo);
            Assert.IsType<AbstractBaseClass>(demo);
        }

        /*
         * Types are easy to abused, but here are some simple ways to cast things
         */
        [Fact]
        public void CastByUsingTypedVariables()
        {
            // Clean way to "cast"
            AbstractBaseClass baseClass = new DemoClass();
            Assert.IsType<AbstractBaseClass>(baseClass);
            Assert.IsNotType<IMinimalInterface>(baseClass);
            Assert.IsNotType<DemoClass>(baseClass);

            IMinimalInterface minimalInterface = new DemoClass();
            Assert.IsType<AbstractBaseClass>(minimalInterface);
            Assert.IsNotType<IMinimalInterface>(minimalInterface);
            Assert.IsNotType<DemoClass>(minimalInterface);
        }

        [Fact]
        public void MoreCasting()
        {
            var inherited = new InheritedClass();
            
            Assert.True(inherited is DemoClass);

            // this is used if you are not sure if can be casted. Not needed as often anymore
            var tmp = inherited as DemoClass;
            Assert.NotNull(tmp);

            // This is how it is usually done
            if (inherited is DemoClass demo)
            {
                Assert.NotNull(demo);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}