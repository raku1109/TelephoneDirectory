using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class PersonDbOperationTests
    {
        [Test]
        public void MyFirstTest()
        {
            var a = 1;
            var b = 2;
            var c = a + b;
            Assert.AreEqual(3, c);
        }
    }
}
