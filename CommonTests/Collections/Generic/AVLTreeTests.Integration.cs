namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class AVLTreeTests
    {
        #region Setup

        public AVLTree<int> InstanceEmpty { get { return Empty as AVLTree<int>; } }
        public AVLTree<int> InstanceRootOnly { get { return RootOnly as AVLTree<int>; } }
        public AVLTree<int> InstanceRootLeft { get { return RootLeft as AVLTree<int>; } }
        public AVLTree<int> InstanceRootRight { get { return RootRight as AVLTree<int>; } }
        public AVLTree<int> InstanceThreeNodesFull { get { return ThreeNodesFull as AVLTree<int>; } }
        public AVLTree<int> InstanceFourNodesLeftLeft { get { return FourNodesLeftLeft as AVLTree<int>; } }
        public AVLTree<int> InstanceFourNodesLeftRight { get { return FourNodesLeftRight as AVLTree<int>; } }
        public AVLTree<int> InstanceFourNodesRightLeft { get { return FourNodesRightLeft as AVLTree<int>; } }
        public AVLTree<int> InstanceFourNodesRightRight { get { return FourNodesRightRight as AVLTree<int>; } }
        public AVLTree<int> InstanceFiveNodesLeftFull { get { return FiveNodesLeftFull as AVLTree<int>; } }
        public AVLTree<int> InstanceBigger { get { return Bigger as AVLTree<int>; } }

        public override void InitEmptyTreeForTests()
        {
            Empty = new AVLTree<int>();
        }

        public override void InitRootOnlyForTests()
        {
            RootOnly = new AVLTree<int>()
            {
                Count = 1,
                Root = new AVLNode<int>(50)
            };
        }

        public override void InitRootLeftForTests()
        {
            RootLeft = new AVLTree<int>()
            {
                Count = 2,
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25)
                },
            };
        }

        public override void InitRootRightForTests()
        {
            RootRight = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Right = new AVLNode<int>(75)
                },
                Count = 2
            };
        }

        public override void InitThreeNodesFullForTests()
        {
            ThreeNodesFull = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25),
                    Right = new AVLNode<int>(75)
                },
                Count = 3
            };
        }

        public override void InitFourNodesLeftLeft()
        {
            FourNodesLeftLeft = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25)
                    {
                        Left = new AVLNode<int>(12)
                    },
                    Right = new AVLNode<int>(75)
                },
                Count = 4
            };
        }

        public override void InitFourNodesLeftRight()
        {
            FourNodesLeftRight = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25)
                    {
                        Right = new AVLNode<int>(32)
                    },
                    Right = new AVLNode<int>(75)
                },
                Count = 4
            };
        }

        public override void InitFourNodesRightLeft()
        {
            FourNodesRightLeft = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25),
                    Right = new AVLNode<int>(75)
                    {
                        Left = new AVLNode<int>(63)
                    }
                },
                Count = 4
            };
        }

        public override void InitFourNodesRightRight()
        {
            FourNodesRightRight = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25),
                    Right = new AVLNode<int>(75)
                    {
                        Right = new AVLNode<int>(100)
                    }
                },
                Count = 4
            };
        }


        public override void InitFiveNodesLeftFullForTests()
        {
            FiveNodesLeftFull = new AVLTree<int>()
            {
                Root = new AVLNode<int>(50)
                {
                    Left = new AVLNode<int>(25)
                    {
                        Left = new AVLNode<int>(12),
                        Right = new AVLNode<int>(32)
                    },
                    Right = new AVLNode<int>(75)
                },
                Count = 5
            };
        }

        public override void InitBiggerForTests()
        {
            Bigger = new AVLTree<int>()
            {
                Count = 9,
                Root = new AVLNode<int>(100)
                {
                    Left = new AVLNode<int>(50)
                    {
                        Left = new AVLNode<int>(25)
                        {
                            Right = new AVLNode<int>(30)
                        },
                        Right = new AVLNode<int>(75)
                    },
                    Right = new AVLNode<int>(150)
                    {
                        Left = new AVLNode<int>(125),
                        Right = new AVLNode<int>(175)
                        {
                            Left = new AVLNode<int>(160)
                        }
                    }
                }
            };
        }

        #endregion

        #region AVLTree.Insert

        [TestMethod]
        [TestCategory("AVLTree")]
        public void Insert_Randoms()
        {
            AVLTree<int> avlTree = new AVLTree<int>();

            avlTree.Insert(1497812207);
            avlTree.Insert(694294668);
            avlTree.Insert(413707771);
            avlTree.Insert(887315894);
            avlTree.Insert(1043416025);

            Assert.AreEqual<int>(-1, avlTree.Balance);
            Assert.AreEqual<int>(694294668, avlTree.Root.Value);
            Assert.AreEqual<int>(413707771, avlTree.Root.Left.Value);
            Assert.AreEqual<int>(1043416025, avlTree.Root.Right.Value);
            Assert.AreEqual<int>(887315894, avlTree.Root.Right.Left.Value);
            Assert.AreEqual<int>(1497812207, avlTree.Root.Right.Right.Value);
        }

        #endregion

        #region AVLTree.Delete



        #endregion

        #region AVLTree.AssertTree

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_InvalidChildren()
        {
            var root = new AVLNode<int>(100);
            root.Left = new AVLNode<int>(150);

            AVLTree<int> bst = new AVLTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_InvalidBalance_Left()
        {
            var root = new AVLNode<int>(100);
            root.Left = new AVLNode<int>(50);
            root.Right = new AVLNode<int>(150);
            root.Left.Left = new AVLNode<int>(30);
            root.Left.Left.Left = new AVLNode<int>(20);

            AVLTree<int> bst = new AVLTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("AVLTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_InvalidBalance_Right()
        {
            var root = new AVLNode<int>(100);
            root.Left = new AVLNode<int>(50);
            root.Right = new AVLNode<int>(150);
            root.Right.Right = new AVLNode<int>(160);
            root.Right.Right.Right = new AVLNode<int>(170);

            AVLTree<int> bst = new AVLTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        #endregion
    }
}
