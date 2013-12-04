namespace CommonTestsInternal.Collections.Generic
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
            IInternalBinaryNode<int> node = new RedBlackNode<int>(50);
            Assert.IsTrue(node.IsLeaf);
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

        #region Rotations

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void RotateLeft_FullTree()
        {
            IInternalBinaryNode<int> node = new RedBlackNode<int>(100);

            node.Left = new RedBlackNode<int>(50);
            node.Right = new RedBlackNode<int>(150);

            node.Left.Left = new RedBlackNode<int>(25);
            node.Left.Right = new RedBlackNode<int>(75);
            node.Right.Left = new RedBlackNode<int>(125);
            node.Right.Right = new RedBlackNode<int>(175);

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
        [TestCategory("RedBlackNode")]
        public void RotateRight_FullTree()
        {
            IInternalBinaryNode<int> node = new RedBlackNode<int>(100);

            node.Left = new RedBlackNode<int>(50);
            node.Right = new RedBlackNode<int>(150);

            node.Left.Left = new RedBlackNode<int>(25);
            node.Left.Right = new RedBlackNode<int>(75);
            node.Right.Left = new RedBlackNode<int>(125);
            node.Right.Right = new RedBlackNode<int>(175);

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
        public void RotateRight_CheckColours()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(100);
            node.Left = new RedBlackNode<int>(50);
            node = node.RotateRight();

            Assert.AreEqual<Colour>(Colour.Black, node.Colour);
            Assert.AreEqual<Colour>(Colour.Red, node.Right.Colour);
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
    }
}
