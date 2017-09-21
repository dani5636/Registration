using NUnit.Framework;
using System;
namespace TestUnitProject
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            Assert.AreEqual(2, 2);
        }
    }
}
