using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rouzzf.Common.Video.Compression;
using System;
using System.Drawing;

namespace Rouzzf.Common.Tests.Compression
{
    [TestClass]
    public class JpgCompressionTests
    {
        [TestMethod, TestCategory("Compression")]
        public void CompressionTest()
        {
            var quality = Int64.MaxValue;
            var jpg = new JpgCompression(quality);
            var bitmap = new Bitmap(200, 200);

            var result = jpg.Compress(bitmap);

            Assert.IsNotNull(result);
            CollectionAssert.AllItemsAreNotNull(result);
        }
    }
}
