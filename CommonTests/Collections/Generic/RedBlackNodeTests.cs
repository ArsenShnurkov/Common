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
            RedBlackNode<int> node = new RedBlackNode<int>(50);
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
            RedBlackNode<int> node = new RedBlackNode<int>(100);

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

            node = node.RotateLeft() as RedBlackNode<int>;

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
            RedBlackNode<int> node = new RedBlackNode<int>(100);

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

            node = node.RotateRight() as RedBlackNode<int>;

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
            node = node.RotateLeft() as RedBlackNode<int>;

            Assert.IsFalse(node.IsRed);
            Assert.IsTrue(node.Left.IsRed);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void RotateRight_CheckColours()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(100);
            node.Left = new RedBlackNode<int>(50);
            node = node.RotateRight() as RedBlackNode<int>;

            Assert.IsFalse(node.IsRed);
            Assert.IsTrue(node.Right.IsRed);
        }

        #endregion

        #region Reset Height

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void ResetHeight()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(20);

            Assert.AreEqual<int>(0, node.Height);

            node.Left = new RedBlackNode<int>(10);

            Assert.AreEqual<int>(0, node.Height);

            node.ResetHeight();

            Assert.AreEqual<int>(1, node.Height);
        }

        #endregion

        #region RedBlackNode.InOrderPredecessor

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderPredecessor_Leaf()
        {
            RedBlackNode<int> leaf = new RedBlackNode<int>(50);
            Assert.IsNull(leaf.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderPredecessor_RootLeft()
        {
            RedBlackNode<int> rootLeft = new RedBlackNode<int>(50)
            {
                Left = new RedBlackNode<int>(25)
            };

            Assert.AreEqual<int>(25, rootLeft.InOrderPredecessor.Value);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderPredecessor_RootRight()
        {
            RedBlackNode<int> rootRight = new RedBlackNode<int>(50)
            {
                Right = new RedBlackNode<int>(75)
            };

            Assert.IsNull(rootRight.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderPredecessor_RootLeftRight()
        {
            RedBlackNode<int> rootLeftRight = new RedBlackNode<int>(50)
            {
                Left = new RedBlackNode<int>(25)
                {
                    Right = new RedBlackNode<int>(30)
                }
            };

            Assert.AreEqual<int>(30, rootLeftRight.InOrderPredecessor.Value);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderPredecessor_RootLeftLeft()
        {
            RedBlackNode<int> rootLeftLeft = new RedBlackNode<int>(50)
            {
                Left = new RedBlackNode<int>(25)
                {
                    Left = new RedBlackNode<int>(10)
                }
            };

            Assert.AreEqual<int>(25, rootLeftLeft.InOrderPredecessor.Value);
        }

        #endregion

        #region RedBlackNode.InOrderSuccessor

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderSuccessor_Leaf()
        {
            RedBlackNode<int> leaf = new RedBlackNode<int>(50);
            Assert.IsNull(leaf.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderSuccessor_RootLeft()
        {
            RedBlackNode<int> rootLeft = new RedBlackNode<int>(50)
            {
                Left = new RedBlackNode<int>(25)
            };

            Assert.IsNull(rootLeft.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderSuccessor_RootRight()
        {
            RedBlackNode<int> rootRight = new RedBlackNode<int>(50)
            {
                Right = new RedBlackNode<int>(75)
            };

            Assert.AreEqual<int>(75, rootRight.InOrderSuccessor.Value);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderSuccessor_RootRightLeft()
        {
            RedBlackNode<int> rootRightLeft = new RedBlackNode<int>(50)
            {
                Right = new RedBlackNode<int>(75)
                {
                    Left = new RedBlackNode<int>(70)
                }
            };

            Assert.AreEqual<int>(70, rootRightLeft.InOrderSuccessor.Value);
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void InOrderSuccessor_RootRightRight()
        {
            RedBlackNode<int> rootRightRight = new RedBlackNode<int>(50)
            {
                Right = new RedBlackNode<int>(75)
                {
                    Right = new RedBlackNode<int>(100)
                }
            };

            Assert.AreEqual<int>(75, rootRightRight.InOrderSuccessor.Value);
        }

        #endregion

        #region RedBlackNode.ToString

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void ToString_Leaf()
        {
            Assert.AreEqual<string>("50,Red; Left=null; Right=null", new RedBlackNode<int>(50).ToString());
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void ToString_RootLeft()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(50)
            {
                Left = new RedBlackNode<int>(25),
            };

            Assert.AreEqual<string>("50,Red; Left=25; Right=null", node.ToString());
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void ToString_RootRight()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(50)
            {
                Right = new RedBlackNode<int>(75),
            };

            Assert.AreEqual<string>("50,Red; Left=null; Right=75", node.ToString());
        }

        [TestMethod]
        [TestCategory("RedBlackNode")]
        public void ToString_RootBoth()
        {
            RedBlackNode<int> node = new RedBlackNode<int>(50)
            {
                Left = new RedBlackNode<int>(25),
                Right = new RedBlackNode<int>(75),
            };

            Assert.AreEqual<string>("50,Red; Left=25; Right=75", node.ToString());
        }

        #endregion
    }
}
