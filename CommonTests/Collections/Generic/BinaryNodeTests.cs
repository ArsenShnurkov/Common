namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinaryNodeTests
    {
        #region IsLeaf
        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_True()
        {
            Assert.IsTrue(new BinaryNode<int>(50).IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_False_Left()
        {
            var node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(20);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_False_Right()
        {
            var node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_False_Full()
        {
            var node = new BinaryNode<int>(50);

            node.Left = new BinaryNode<int>(20);
            node.Right = new BinaryNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }
        #endregion

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void ResetHeight()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(20);

            Assert.AreEqual<int>(0, node.Height);

            node.Left = new BinaryNode<int>(10);

            Assert.AreEqual<int>(0, node.Height);

            node.ResetHeight();

            Assert.AreEqual<int>(1, node.Height);
        }
    }
}
