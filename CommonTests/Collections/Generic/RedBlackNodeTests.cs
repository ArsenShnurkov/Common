namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RedBlackNodeTests
    {
        #region IsLeaf
        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void IsLeaf_True()
        {
            Assert.IsTrue(new RedBlackNode<int>(50).IsLeaf);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void IsLeaf_False_Left()
        {
            var node = new RedBlackNode<int>(50);
            node.Left = new RedBlackNode<int>(20);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void IsLeaf_False_Right()
        {
            var node = new RedBlackNode<int>(50);
            node.Right = new RedBlackNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void IsLeaf_False_Full()
        {
            var node = new RedBlackNode<int>(50);

            node.Left = new RedBlackNode<int>(20);
            node.Right = new RedBlackNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }
        #endregion

        #region Reset Height

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void ResetHeight()
        {
            IInternalBinaryNode<int> node = new RedBlackNode<int>(20);

            Assert.AreEqual<int>(0, node.Height);

            node.Left = new RedBlackNode<int>(10);

            Assert.AreEqual<int>(0, node.Height);

            node.ResetHeight();

            Assert.AreEqual<int>(1, node.Height);
        }

        #endregion


        #region Rotations

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void RotateLeft_CheckColours()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(100);
            node.Right = new RedBlackNode<int>(150);
            node = node.RotateLeft();

            Assert.AreEqual<Colour>(Colour.Black, node.Colour);
            Assert.AreEqual<Colour>(Colour.Red, node.Left.Colour);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void RotateRight_FullTree()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(100);
            node.Left = new RedBlackNode<int>(50);
            node = node.RotateRight();

            Assert.AreEqual<Colour>(Colour.Black, node.Colour);
            Assert.AreEqual<Colour>(Colour.Red, node.Right.Colour);
        }

        #endregion
    }
}
