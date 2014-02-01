namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BSTNodeTests
    {

        #region BinarySearchTreeNode.Height

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_Root()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);

            Assert.AreEqual<int>(0, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_RootWithLeftChild()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_RootWithRightChild()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Right = new BinarySearchTreeNode<int>(150);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_RootWithBothChildren()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            Assert.AreEqual<int>(1, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_2_LeftLeft()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            root.Left.Left = new BinarySearchTreeNode<int>(40);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_2_LeftRight()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            root.Left.Right = new BinarySearchTreeNode<int>(60);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_2_RightLeft()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            root.Right.Left = new BinarySearchTreeNode<int>(110);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_2_RightRight()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            root.Right.Right = new BinarySearchTreeNode<int>(160);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_2_FullSecondLevel()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            root.Left.Left = new BinarySearchTreeNode<int>(40);
            root.Left.Right = new BinarySearchTreeNode<int>(60);
            root.Right.Left = new BinarySearchTreeNode<int>(110);
            root.Right.Right = new BinarySearchTreeNode<int>(160);

            Assert.AreEqual<int>(2, root.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void Height_3_LeftLeftLeft()
        {
            BinarySearchTreeNode<int> root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(50);
            root.Right = new BinarySearchTreeNode<int>(150);

            root.Left.Left = new BinarySearchTreeNode<int>(40);
            root.Left.Right = new BinarySearchTreeNode<int>(60);
            root.Right.Left = new BinarySearchTreeNode<int>(110);
            root.Right.Right = new BinarySearchTreeNode<int>(160);

            root.Left.Left.Left = new BinarySearchTreeNode<int>(30);

            Assert.AreEqual<int>(3, root.Height);
        }

        #endregion

        #region BinarySearchTreeNode.InOrderPredecessor

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderPredecessor_Leaf()
        {
            BinarySearchTreeNode<int> leaf = new BinarySearchTreeNode<int>(50);
            Assert.IsNull(leaf.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderPredecessor_RootLeft()
        {
            BinarySearchTreeNode<int> rootLeft = new BinarySearchTreeNode<int>(50)
            {
                Left = new BinarySearchTreeNode<int>(25)
            };

            Assert.AreEqual<int>(25, rootLeft.InOrderPredecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderPredecessor_RootRight()
        {
            BinarySearchTreeNode<int> rootRight = new BinarySearchTreeNode<int>(50)
            {
                Right = new BinarySearchTreeNode<int>(75)
            };

            Assert.IsNull(rootRight.InOrderPredecessor);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderPredecessor_RootLeftRight()
        {
            BinarySearchTreeNode<int> rootLeftRight = new BinarySearchTreeNode<int>(50)
            {
                Left = new BinarySearchTreeNode<int>(25)
                {
                    Right = new BinarySearchTreeNode<int>(30)
                }
            };

            Assert.AreEqual<int>(30, rootLeftRight.InOrderPredecessor.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderPredecessor_RootLeftLeft()
        {
            BinarySearchTreeNode<int> rootLeftLeft = new BinarySearchTreeNode<int>(50)
            {
                Left = new BinarySearchTreeNode<int>(25)
                {
                    Left = new BinarySearchTreeNode<int>(10)
                }
            };

            Assert.AreEqual<int>(25, rootLeftLeft.InOrderPredecessor.Value);
        }

        #endregion

        #region BinarySearchTreeNode.InOrderSuccessor

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderSuccessor_Leaf()
        {
            BinarySearchTreeNode<int> leaf = new BinarySearchTreeNode<int>(50);
            Assert.IsNull(leaf.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderSuccessor_RootLeft()
        {
            BinarySearchTreeNode<int> rootLeft = new BinarySearchTreeNode<int>(50)
            {
                Left = new BinarySearchTreeNode<int>(25)
            };

            Assert.IsNull(rootLeft.InOrderSuccessor);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderSuccessor_RootRight()
        {
            BinarySearchTreeNode<int> rootRight = new BinarySearchTreeNode<int>(50)
            {
                Right = new BinarySearchTreeNode<int>(75)
            };

            Assert.AreEqual<int>(75, rootRight.InOrderSuccessor.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderSuccessor_RootRightLeft()
        {
            BinarySearchTreeNode<int> rootRightLeft = new BinarySearchTreeNode<int>(50)
            {
                Right = new BinarySearchTreeNode<int>(75)
                {
                    Left = new BinarySearchTreeNode<int>(70)
                }
            };

            Assert.AreEqual<int>(70, rootRightLeft.InOrderSuccessor.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void InOrderSuccessor_RootRightRight()
        {
            BinarySearchTreeNode<int> rootRightRight = new BinarySearchTreeNode<int>(50)
            {
                Right = new BinarySearchTreeNode<int>(75)
                {
                    Right = new BinarySearchTreeNode<int>(100)
                }
            };

            Assert.AreEqual<int>(75, rootRightRight.InOrderSuccessor.Value);
        }

        #endregion

        #region BinarySearchTreeNode.ToString

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void ToString_Leaf()
        {
            Assert.AreEqual<string>("50; Left=null; Right=null", new BinarySearchTreeNode<int>(50).ToString());
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void ToString_RootLeft()
        {
            BinarySearchTreeNode<int> node = new BinarySearchTreeNode<int>(50)
            {
                Left = new BinarySearchTreeNode<int>(25),
            };

            Assert.AreEqual<string>("50; Left=25; Right=null", node.ToString());
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void ToString_RootRight()
        {
            BinarySearchTreeNode<int> node = new BinarySearchTreeNode<int>(50)
            {
                Right = new BinarySearchTreeNode<int>(75),
            };

            Assert.AreEqual<string>("50; Left=null; Right=75", node.ToString());
        }

        [TestMethod]
        [TestCategory("BinarySearchTreeNode")]
        public void ToString_RootBoth()
        {
            BinarySearchTreeNode<int> node = new BinarySearchTreeNode<int>(50)
            {
                Left = new BinarySearchTreeNode<int>(25),
                Right = new BinarySearchTreeNode<int>(75),
            };

            Assert.AreEqual<string>("50; Left=25; Right=75", node.ToString());
        }

        #endregion
    }
}
