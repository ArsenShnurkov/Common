namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinaryNodeCommonTests
    {

        #region InOrderPredicessor and InOrderSuccessor
        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderPredecessor_Leaf()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);

            Assert.IsNull(BinaryNodeCommon.InOrderPredecessor(node));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderPredecessor_LeftLeaf()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(25);

            IInternalBinaryNode<int> predecessor = BinaryNodeCommon.InOrderPredecessor(node);
            Assert.IsNotNull(predecessor);
            Assert.AreEqual<int>(25, predecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void LeftWithRight()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(25);
            node.Left.Right = new BinaryNode<int>(30);

            IInternalBinaryNode<int> predecessor = BinaryNodeCommon.InOrderPredecessor(node);
            Assert.IsNotNull(predecessor);
            Assert.AreEqual<int>(30, predecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderPredecessor_LeftWithLeftAndRight()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(25);
            node.Left.Left = new BinaryNode<int>(20);
            node.Left.Right = new BinaryNode<int>(30);

            IInternalBinaryNode<int> predecessor = BinaryNodeCommon.InOrderPredecessor(node);
            Assert.IsNotNull(predecessor);
            Assert.AreEqual<int>(30, predecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderSuccessor_Leaf()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);

            Assert.IsNull(BinaryNodeCommon.InOrderSuccessor(node));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderSuccessor_RightLeaf()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(75);

            IInternalBinaryNode<int> successor = BinaryNodeCommon.InOrderSuccessor(node);
            Assert.IsNotNull(successor);
            Assert.AreEqual<int>(75, successor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderSuccessor_RightWithLeft()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(75);
            node.Right.Left = new BinaryNode<int>(60);

            IInternalBinaryNode<int> successor = BinaryNodeCommon.InOrderSuccessor(node);
            Assert.IsNotNull(successor);
            Assert.AreEqual<int>(60, successor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void InOrderSuccessor_RightWithLeftAndRight()
        {
            IInternalBinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(75);
            node.Right.Left = new BinaryNode<int>(60);
            node.Right.Right = new BinaryNode<int>(90);

            IInternalBinaryNode<int> successor = BinaryNodeCommon.InOrderSuccessor(node);
            Assert.IsNotNull(successor);
            Assert.AreEqual<int>(60, successor.Value);
        }
        #endregion

        #region Height

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_Leaf()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(20);
            Assert.AreEqual<int>(0, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_LeftLeaf()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(20);
            root.Left = new BinaryNode<int>(10);

            Assert.AreEqual<int>(1, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_RightLeaf()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            Assert.AreEqual<int>(1, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_FullFirstLevel()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            root.Left.ResetHeight();
            Assert.AreEqual<int>(1, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_4Nodes_LeftLeft()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Left.ResetHeight();
            Assert.AreEqual<int>(2, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_4Nodes_LeftRight()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Right.ResetHeight();
            Assert.AreEqual<int>(2, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_4Nodes_RightLeft()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Left.ResetHeight();
            Assert.AreEqual<int>(2, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Height_4Nodes_RightRight()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Right.ResetHeight();
            Assert.AreEqual<int>(2, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_Leaf()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.ResetHeight();
            Assert.AreEqual<int>(0, BinaryNodeCommon.GetHeight(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_LeftLeaf()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(20);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();

            Assert.AreEqual<int>(1, BinaryNodeCommon.GetNodeBalance(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_RightLeaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            Assert.AreEqual<int>(-1, BinaryNodeCommon.GetNodeBalance(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_FullFirstLevel()
        {
            BinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            root.Left.ResetHeight();
            Assert.AreEqual<int>(0, BinaryNodeCommon.GetNodeBalance(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_4Nodes_LeftLeft()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Left.ResetHeight();
            Assert.AreEqual<int>(1, BinaryNodeCommon.GetNodeBalance(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_4Nodes_LeftRight()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Right.ResetHeight();
            Assert.AreEqual<int>(1, BinaryNodeCommon.GetNodeBalance(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_4Nodes_RightLeft()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Left.ResetHeight();
            Assert.AreEqual<int>(-1, BinaryNodeCommon.GetNodeBalance(root));
        }

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
        public void Balance_4Nodes_RightRight()
        {
            IInternalBinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Right.ResetHeight();
            Assert.AreEqual<int>(-1, BinaryNodeCommon.GetNodeBalance(root));
        }

        #endregion

        #region Rotations

        [TestMethod]
        [TestCategory("BinaryNodeCommon")]
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

            node = BinaryNodeCommon.RotateLeft(node);

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
        [TestCategory("BinaryNodeCommon")]
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

            node = BinaryNodeCommon.RotateRight(node);

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
    }
}
