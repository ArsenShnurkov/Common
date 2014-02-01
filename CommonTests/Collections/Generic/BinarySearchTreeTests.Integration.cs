namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class BinarySearchTreeTests
    {
        #region Setup

        public BinarySearchTree<int> InstanceEmpty { get { return Empty as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceRootOnly { get { return RootOnly as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceRootLeft { get { return RootLeft as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceRootRight { get { return RootRight as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceThreeNodesFull { get { return ThreeNodesFull as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceFourNodesLeftLeft { get { return FourNodesLeftLeft as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceFourNodesLeftRight { get { return FourNodesLeftRight as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceFourNodesRightLeft { get { return FourNodesRightLeft as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceFourNodesRightRight { get { return FourNodesRightRight as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceFiveNodesLeftFull { get { return FiveNodesLeftFull as BinarySearchTree<int>; } }
        public BinarySearchTree<int> InstanceBigger { get { return Bigger as BinarySearchTree<int>; } }


        public override void InitEmptyTreeForTests()
        {
            Empty = new BinarySearchTree<int>();
        }

        public override void InitRootOnlyForTests()
        {
            RootOnly = new BinarySearchTree<int>()
            {
                Count = 1,
                Root = new BinarySearchTreeNode<int>(50)
            };
        }

        public override void InitRootLeftForTests()
        {
            RootLeft = new BinarySearchTree<int>()
            {
                Count = 2,
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25)
                },
            };
        }

        public override void InitRootRightForTests()
        {
            RootRight = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Right = new BinarySearchTreeNode<int>(75)
                },
                Count = 2
            };
        }

        public override void InitThreeNodesFullForTests()
        {
            ThreeNodesFull = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25),
                    Right = new BinarySearchTreeNode<int>(75)
                },
                Count = 3
            };
        }

        public override void InitFourNodesLeftLeft()
        {
            FourNodesLeftLeft = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25)
                    {
                        Left = new BinarySearchTreeNode<int>(12)
                    },
                    Right = new BinarySearchTreeNode<int>(75)
                },
                Count = 4
            };
        }

        public override void InitFourNodesLeftRight()
        {
            FourNodesLeftRight = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25)
                    {
                        Right = new BinarySearchTreeNode<int>(32)
                    },
                    Right = new BinarySearchTreeNode<int>(75)
                },
                Count = 4
            };
        }

        public override void InitFourNodesRightLeft()
        {
            FourNodesRightLeft = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25),
                    Right = new BinarySearchTreeNode<int>(75)
                    {
                        Left = new BinarySearchTreeNode<int>(63)
                    }
                },
                Count = 4
            };
        }

        public override void InitFourNodesRightRight()
        {
            FourNodesRightRight = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25),
                    Right = new BinarySearchTreeNode<int>(75)
                    {
                        Right = new BinarySearchTreeNode<int>(100)
                    }
                },
                Count = 4
            };
        }


        public override void InitFiveNodesLeftFullForTests()
        {
            FiveNodesLeftFull = new BinarySearchTree<int>()
            {
                Root = new BinarySearchTreeNode<int>(50)
                {
                    Left = new BinarySearchTreeNode<int>(25)
                    {
                        Left = new BinarySearchTreeNode<int>(12),
                        Right = new BinarySearchTreeNode<int>(32)
                    },
                    Right = new BinarySearchTreeNode<int>(75)
                },
                Count = 5
            };
        }

        public override void InitBiggerForTests()
        {
            Bigger = new BinarySearchTree<int>()
            {
                Count = 9,
                Root = new BinarySearchTreeNode<int>(100)
                {
                    Left = new BinarySearchTreeNode<int>(50)
                    {
                        Left = new BinarySearchTreeNode<int>(25)
                        {
                            Right = new BinarySearchTreeNode<int>(30)
                        },
                        Right = new BinarySearchTreeNode<int>(75)
                    },
                    Right = new BinarySearchTreeNode<int>(150)
                    {
                        Left = new BinarySearchTreeNode<int>(125),
                        Right = new BinarySearchTreeNode<int>(175)
                        {
                            Left = new BinarySearchTreeNode<int>(160)
                        }
                    }
                }
            };
        }


        #endregion

        #region BinarySearchTree.Insert

        #endregion

        #region BinarySearchTree.Contains

        #endregion

        #region BinarySearchTree.Delete

        #endregion

        #region BinarySearchTree.Depth

        #endregion

        #region BinarySearchTree.AssertValidTree

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_InvalidChildren()
        {
            var root = new BinarySearchTreeNode<int>(100);
            root.Left = new BinarySearchTreeNode<int>(150);

            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        #endregion
    }
}
