namespace CommonTestsInternal.Collections.Generic
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
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            Assert.IsTrue(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_False_Left()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(20);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_False_Right()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void IsLeaf_False_Full()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);

            node.Left = new BinaryNode<int>(20);
            node.Right = new BinaryNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }
        #endregion

        #region Rotations

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void RotateLeft_FullTree()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(100);

            node.Left = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(150);

            node.Left.Left = new BinaryNode<int>(25);
            node.Left.Right = new BinaryNode<int>(75);
            node.Right.Left = new BinaryNode<int>(125);
            node.Right.Right = new BinaryNode<int>(175);

            node.ResetHeight();
            node.Left.ResetHeight();
            node.Right.ResetHeight();
            node.Left.Left.ResetHeight();
            node.Left.Right.ResetHeight();
            node.Right.Left.ResetHeight();
            node.Right.Right.ResetHeight();

            node = node.RotateLeft();

            Assert.AreEqual<int>(150, node.Value);
            Assert.AreEqual<int>(175, node.Right.Value);
            Assert.AreEqual<int>(100, node.Left.Value);
            Assert.AreEqual<int>(125, node.Left.Right.Value);
            Assert.AreEqual<int>(50, node.Left.Left.Value);
            Assert.AreEqual<int>(25, node.Left.Left.Left.Value);
            Assert.AreEqual<int>(75, node.Left.Left.Right.Value);

            Assert.AreEqual<int>(3, node.Height);
            Assert.AreEqual<int>(0, node.Right.Height);
            Assert.AreEqual<int>(2, node.Left.Height);
            Assert.AreEqual<int>(1, node.Left.Left.Height);
            Assert.AreEqual<int>(0, node.Left.Right.Height);
            Assert.AreEqual<int>(0, node.Left.Left.Left.Height);
            Assert.AreEqual<int>(0, node.Left.Left.Right.Height);

        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void RotateRight_FullTree()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(100);

            node.Left = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(150);

            node.Left.Left = new BinaryNode<int>(25);
            node.Left.Right = new BinaryNode<int>(75);
            node.Right.Left = new BinaryNode<int>(125);
            node.Right.Right = new BinaryNode<int>(175);

            node.ResetHeight();
            node.Left.ResetHeight();
            node.Right.ResetHeight();
            node.Left.Left.ResetHeight();
            node.Left.Right.ResetHeight();
            node.Right.Left.ResetHeight();
            node.Right.Right.ResetHeight();

            node = node.RotateRight();

            Assert.AreEqual<int>(50, node.Value);
            Assert.AreEqual<int>(25, node.Left.Value);
            Assert.AreEqual<int>(100, node.Right.Value);
            Assert.AreEqual<int>(75, node.Right.Left.Value);
            Assert.AreEqual<int>(150, node.Right.Right.Value);
            Assert.AreEqual<int>(125, node.Right.Right.Left.Value);
            Assert.AreEqual<int>(175, node.Right.Right.Right.Value);


            Assert.AreEqual<int>(3, node.Height);
            Assert.AreEqual<int>(0, node.Left.Height);
            Assert.AreEqual<int>(2, node.Right.Height);
            Assert.AreEqual<int>(1, node.Right.Right.Height);
            Assert.AreEqual<int>(0, node.Right.Left.Height);
            Assert.AreEqual<int>(0, node.Right.Right.Right.Height);
            Assert.AreEqual<int>(0, node.Right.Right.Left.Height);
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
