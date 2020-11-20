namespace Kabatra.Common.Singleton.UnitTests
{
    using System;
    using Xunit;

    public class SingletonTests : IDisposable
    {
        public void Dispose()
        {
            SingletonBase<TestSingleton>.Reset();
        }

        [Fact]
        public void CanCreateSingleton()
        {
            var singleton = SingletonBase<TestSingleton>.GetOrCreateInstance();
            
            Assert.NotNull(singleton);
        }
    }
}
