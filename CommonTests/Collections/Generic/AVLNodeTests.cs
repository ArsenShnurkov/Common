namespace CommonTestsInternal.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AVLNodeTests
    {
        #region AVLNode.IsLeaf

        [TestMethod]
        [TestCategory("AVLNode")]
        public void IsLeaf_True()
        {
            var node = new AVLNode<int>(50);
            Assert.IsTrue(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void IsLeaf_False_Left()
        {
            var node = new AVLNode<int>(50);
            node.Left = new AVLNode<int>(20);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void IsLeaf_False_Right()
        {
            var node = new AVLNode<int>(50);
            node.Right = new AVLNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void IsLeaf_False_Full()
        {
            var node = new AVLNode<int>(50);

            node.Left = new AVLNode<int>(20);
            node.Right = new AVLNode<int>(70);

            Assert.IsFalse(node.IsLeaf);
        }

        #endregion

        #region AVLNode.InOrderPredecessor

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderPredecessor_Leaf()
        {
            AVLNode<int> leaf = new AVLNode<int>(50);
            Assert.IsNull(leaf.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderPredecessor_RootLeft()
        {
            AVLNode<int> rootLeft = new AVLNode<int>(50)
            {
                Left = new AVLNode<int>(25)
            };

            Assert.AreEqual<int>(25, rootLeft.InOrderPredecessor.Value);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderPredecessor_RootRight()
        {
            AVLNode<int> rootRight = new AVLNode<int>(50)
            {
                Right = new AVLNode<int>(75)
            };

            Assert.IsNull(rootRight.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderPredecessor_RootLeftRight()
        {
            AVLNode<int> rootLeftRight = new AVLNode<int>(50)
            {
                Left = new AVLNode<int>(25)
                {
                    Right = new AVLNode<int>(30)
                }
            };

            Assert.AreEqual<int>(30, rootLeftRight.InOrderPredecessor.Value);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderPredecessor_RootLeftLeft()
        {
            AVLNode<int> rootLeftLeft = new AVLNode<int>(50)
            {
                Left = new AVLNode<int>(25)
                {
                    Left = new AVLNode<int>(10)
                }
            };

            Assert.AreEqual<int>(25, rootLeftLeft.InOrderPredecessor.Value);
        }

        #endregion

        #region AVLNode.InOrderSuccessor

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderSuccessor_Leaf()
        {
            AVLNode<int> leaf = new AVLNode<int>(50);
            Assert.IsNull(leaf.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderSuccessor_RootLeft()
        {
            AVLNode<int> rootLeft = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25)
                };

            Assert.IsNull(rootLeft.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderSuccessor_RootRight()
        {
            AVLNode<int> rootRight = new AVLNode<int>(50)
            {
                Right = new AVLNode<int>(75)
            };

            Assert.AreEqual<int>(75, rootRight.InOrderSuccessor.Value);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderSuccessor_RootRightLeft()
        {
            AVLNode<int> rootRightLeft = new AVLNode<int>(50)
            {
                Right = new AVLNode<int>(75)
                {
                    Left = new AVLNode<int>(70)
                }
            };

            Assert.AreEqual<int>(70, rootRightLeft.InOrderSuccessor.Value);
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void InOrderSuccessor_RootRightRight()
        {
            AVLNode<int> rootRightRight = new AVLNode<int>(50)
            {
                Right = new AVLNode<int>(75)
                {
                    Right = new AVLNode<int>(100)
                }
            };

            Assert.AreEqual<int>(75, rootRightRight.InOrderSuccessor.Value);
        }

        #endregion

        #region AVLNode Rotations

        [TestMethod]
        [TestCategory("AVLNode")]
        public void RotateLeft_FullTree()
        {
            var node = new AVLNode<int>(100);

            node.Left = new AVLNode<int>(50);
            node.Right = new AVLNode<int>(150);

            node.Left.Left = new AVLNode<int>(25);
            node.Left.Right = new AVLNode<int>(75);
            node.Right.Left = new AVLNode<int>(125);
            node.Right.Right = new AVLNode<int>(175);

            node = node.RotateLeft();

            Assert.AreEqual<int>(150, node.Value);
            Assert.AreEqual<int>(175, node.Right.Value);
            Assert.AreEqual<int>(100, node.Left.Value);
            Assert.AreEqual<int>(125, node.Left.Right.Value);
            Assert.AreEqual<int>(50, node.Left.Left.Value);
            Assert.AreEqual<int>(25, node.Left.Left.Left.Value);
            Assert.AreEqual<int>(75, node.Left.Left.Right.Value);

        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void RotateRight_FullTree()
        {
            var node = new AVLNode<int>(100);

            node.Left = new AVLNode<int>(50);
            node.Right = new AVLNode<int>(150);

            node.Left.Left = new AVLNode<int>(25);
            node.Left.Right = new AVLNode<int>(75);
            node.Right.Left = new AVLNode<int>(125);
            node.Right.Right = new AVLNode<int>(175);

            node = node.RotateRight();

            Assert.AreEqual<int>(50, node.Value);
            Assert.AreEqual<int>(25, node.Left.Value);
            Assert.AreEqual<int>(100, node.Right.Value);
            Assert.AreEqual<int>(75, node.Right.Left.Value);
            Assert.AreEqual<int>(150, node.Right.Right.Value);
            Assert.AreEqual<int>(125, node.Right.Right.Left.Value);
            Assert.AreEqual<int>(175, node.Right.Right.Right.Value);
        }

        #endregion

        #region AVLNode.ResetHeight

        [TestMethod]
        [TestCategory("AVLNode")]
        public void ResetHeight()
        {
            var node = new AVLNode<int>(20);

            Assert.AreEqual<int>(0, node.Height);

            node.Left = new AVLNode<int>(10);

            Assert.AreEqual<int>(0, node.Height);

            node.ResetHeight();

            Assert.AreEqual<int>(1, node.Height);
        }

        #endregion

        #region AVLNode.ToString
        
        [TestMethod]
        [TestCategory("AVLNode")]
        public void ToString_Leaf()
        {
            Assert.AreEqual<string>("50; Left=null; Right=null", new AVLNode<int>(50).ToString());
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void ToString_RootLeft()
        {
            AVLNode<int> node = new AVLNode<int>(50)
            {
                Left = new AVLNode<int>(25),
            };

            Assert.AreEqual<string>("50; Left=25; Right=null", node.ToString());
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void ToString_RootRight()
        {
            AVLNode<int> node = new AVLNode<int>(50)
            {
                Right = new AVLNode<int>(75),
            };

            Assert.AreEqual<string>("50; Left=null; Right=75", node.ToString());
        }

        [TestMethod]
        [TestCategory("AVLNode")]
        public void ToString_RootBoth()
        {
            AVLNode<int> node = new AVLNode<int>(50)
            {
                Left = new AVLNode<int>(25),
                Right = new AVLNode<int>(75),
            };

            Assert.AreEqual<string>("50; Left=25; Right=75", node.ToString());
        }

        #endregion
    }
}
