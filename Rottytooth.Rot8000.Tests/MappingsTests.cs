using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rottytooth.Rot8000;

namespace Rottytooth.Rot8000.Tests
{
    [TestClass]
    public class MappingsTests
    {
        /// <summary>
        /// Make sure it's an even-numbered list; otherwise the conversion is not reversable
        /// </summary>
        [TestMethod]
        public void MappingsIsEven()
        {
            Assert.IsTrue(Rotator.Mappings.Count % 2 == 0);
        }
    }
}
