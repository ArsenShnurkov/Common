using System;
using Common.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.Collections.Generic
{
    [TestClass]
    public class BinaryNodeTests
    {
        #region IsLeaf
        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_IsLeaf()
        {
            Assert.IsTrue(new BinaryNode<int>(50).IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_IsNotLeaf_Left()
        {
            var node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(20);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_IsNotLeaf_Right()
        {
            var node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_IsNotLeaf_Full()
        {
            var node = new BinaryNode<int>(50);

            node.Left = new BinaryNode<int>(20);
            node.Right = new BinaryNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }
        #endregion

        #region InOrderPredicessor and InOrderSuccessor
        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderPredecessor_Leaf()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);

            Assert.IsNull(node.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderPredecessor_LeftLeaf()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(25);

            BinaryNode<int> predecessor = node.InOrderPredecessor;
            Assert.IsNotNull(predecessor);
            Assert.AreEqual<int>(25, predecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderPredecessor_LeftWithRight()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(25);
            node.Left.Right = new BinaryNode<int>(30);

            BinaryNode<int> predecessor = node.InOrderPredecessor;
            Assert.IsNotNull(predecessor);
            Assert.AreEqual<int>(30, predecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderPredecessor_LeftWithLeftAndRight()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);
            node.Left = new BinaryNode<int>(25);
            node.Left.Left = new BinaryNode<int>(20);
            node.Left.Right = new BinaryNode<int>(30);

            BinaryNode<int> predecessor = node.InOrderPredecessor;
            Assert.IsNotNull(predecessor);
            Assert.AreEqual<int>(30, predecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderSuccessor_Leaf()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);

            Assert.IsNull(node.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderSuccessor_RightLeaf()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(75);

            BinaryNode<int> successor = node.InOrderSuccessor;
            Assert.IsNotNull(successor);
            Assert.AreEqual<int>(75, successor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderSuccessor_RightWithLeft()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(75);
            node.Right.Left = new BinaryNode<int>(60);

            BinaryNode<int> successor = node.InOrderSuccessor;
            Assert.IsNotNull(successor);
            Assert.AreEqual<int>(60, successor.Value);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_InOrderSuccessor_RightWithLeftAndRight()
        {
            BinaryNode<int> node = new BinaryNode<int>(50);
            node.Right = new BinaryNode<int>(75);
            node.Right.Left = new BinaryNode<int>(60);
            node.Right.Right = new BinaryNode<int>(90);

            BinaryNode<int> successor = node.InOrderSuccessor;
            Assert.IsNotNull(successor);
            Assert.AreEqual<int>(60, successor.Value);
        }
        #endregion

        #region Height
        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_Leaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(20);
            root.ResetHeight();
            Assert.AreEqual<int>(0, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_LeftLeaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(20);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_RightLeaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_FullFirstLevel()
        {
            BinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            root.Left.ResetHeight();
            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_4Nodes_LeftLeft()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Left.ResetHeight();
            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_4Nodes_LeftRight()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Right.ResetHeight();
            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_4Nodes_RightLeft()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Left.ResetHeight();
            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Height_4Nodes_RightRight()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Right.ResetHeight();
            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_Leaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.ResetHeight();
            Assert.AreEqual<int>(0, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_LeftLeaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(20);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();

            Assert.AreEqual<int>(1, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_RightLeaf()
        {
            BinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            Assert.AreEqual<int>(-1, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_FullFirstLevel()
        {
            BinaryNode<int> root = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Right.ResetHeight();
            root.Left.ResetHeight();
            Assert.AreEqual<int>(0, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_4Nodes_LeftLeft()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Left.ResetHeight();
            Assert.AreEqual<int>(1, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_4Nodes_LeftRight()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Left.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Left.Right.ResetHeight();
            Assert.AreEqual<int>(1, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_4Nodes_RightLeft()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Left = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Left.ResetHeight();
            Assert.AreEqual<int>(-1, root.Balance);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void BinaryNode_Balance_4Nodes_RightRight()
        {
            BinaryNode<int> root = new BinaryNode<int>(10);
            root.Right = new BinaryNode<int>(10);
            root.Left = new BinaryNode<int>(10);
            root.Right.Right = new BinaryNode<int>(10);
            root.ResetHeight();
            root.Left.ResetHeight();
            root.Right.ResetHeight();
            root.Right.Right.ResetHeight();
            Assert.AreEqual<int>(-1, root.Balance);
        }

        #endregion

        #region BinaryNode.Rotations

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void Rotate_LeftLeftLeft_ToTheRight()
        {
            BinaryNode<int> node = new BinaryNode<int>(100);
            node.Left = new BinaryNode<int>(50);
            node.Left.Left = new BinaryNode<int>(25);

            node.ResetHeight();
            node.Left.ResetHeight();
            node.Left.Left.ResetHeight();

            node.RotateRight();

            Assert.AreEqual<int>(50, node.Value);
            Assert.AreEqual<int>(25, node.Left.Value);
            Assert.AreEqual<int>(100, node.Right.Value);

            Assert.AreEqual<int>(1, node.Height);
            Assert.AreEqual<int?>(0, node.Left.Height);
            Assert.AreEqual<int?>(0, node.Right.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void Rotate_RightRightRight_ToTheLeft()
        {
            BinaryNode<int> node = new BinaryNode<int>(10);
            node.Right = new BinaryNode<int>(50);
            node.Right.Right = new BinaryNode<int>(100);
            node.ResetHeight();
            node.Right.ResetHeight();
            node.Right.Right.ResetHeight();

            node.RotateLeft();

            Assert.AreEqual<int>(50, node.Value);
            Assert.AreEqual<int>(10, node.Left.Value);
            Assert.AreEqual<int>(100, node.Right.Value);

            Assert.AreEqual<int?>(1, node.Height);
            Assert.AreEqual<int?>(0, node.Left.Height);
            Assert.AreEqual<int?>(0, node.Right.Height);
        }

        [TestMethod]
        [TestCategory("BinaryNode")]
        public void RotateLeftFullExample()
        {
            BinaryNode<int> node = new BinaryNode<int>(100);

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

            node.RotateLeft();

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
        public void RotateRightFullExample()
        {
            BinaryNode<int> node = new BinaryNode<int>(100);

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

            node.RotateRight();

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
