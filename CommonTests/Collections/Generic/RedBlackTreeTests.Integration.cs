namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class RedBlackTreeTests
    {

        #region Setup

        public RedBlackTree<int> InstanceEmpty { get { return Empty as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceRootOnly { get { return RootOnly as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceRootLeft { get { return RootLeft as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceRootRight { get { return RootRight as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceThreeNodesFull { get { return ThreeNodesFull as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceFourNodesLeftLeft { get { return FourNodesLeftLeft as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceFourNodesLeftRight { get { return FourNodesLeftRight as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceFourNodesRightLeft { get { return FourNodesRightLeft as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceFourNodesRightRight { get { return FourNodesRightRight as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceFiveNodesLeftFull { get { return FiveNodesLeftFull as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceBigger { get { return Bigger as RedBlackTree<int>; } }
        public RedBlackTree<int> InstanceDelete_BlackRightLeafRedSibling1 { get; set; }
        public RedBlackTree<int> InstanceDelete_BlackLeftLeafRedSibling1 { get; set; }
        public RedBlackTree<int> InstanceDelete_BlackRightLeafRedSibling2 { get; set; }
        public RedBlackTree<int> InstanceDelete_BlackLeftLeafRedSibling2 { get; set; }

        public override void InitEmptyTreeForTests()
        {
            Empty = new RedBlackTree<int>();
        }

        public override void InitRootOnlyForTests()
        {
            RootOnly = new RedBlackTree<int>()
            {
                Count = 1,
                Root = new RedBlackNode<int>(50, Colour.Black)
            };
        }

        public override void InitRootLeftForTests()
        {
            RootLeft = new RedBlackTree<int>()
            {
                Count = 2,
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Red)
                },
            };
        }

        public override void InitRootRightForTests()
        {
            RootRight = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Right = new RedBlackNode<int>(75, Colour.Red)
                },
                Count = 2
            };
        }

        public override void InitThreeNodesFullForTests()
        {
            ThreeNodesFull = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Red),
                    Right = new RedBlackNode<int>(75, Colour.Red)
                },
                Count = 3
            };
        }
            
        public override void InitFourNodesLeftLeft()
        {
            FourNodesLeftLeft = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Black)
                    {
                        Left = new RedBlackNode<int>(12, Colour.Red)
                    },
                    Right = new RedBlackNode<int>(75, Colour.Black)
                },
                Count = 4
            };
        }

        public override void InitFourNodesLeftRight()
        {
            FourNodesLeftRight = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Black)
                    {
                        Right = new RedBlackNode<int>(32, Colour.Red)
                    },
                    Right = new RedBlackNode<int>(75, Colour.Black)
                },
                Count = 4
            };
        }

        public override void InitFourNodesRightLeft()
        {
            FourNodesRightLeft = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Black),
                    Right = new RedBlackNode<int>(75, Colour.Black)
                    {
                        Left = new RedBlackNode<int>(63, Colour.Red)
                    }
                },
                Count = 4
            };
        }   
        
        public override void InitFourNodesRightRight()
        {
            FourNodesRightRight = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Black),
                    Right = new RedBlackNode<int>(75, Colour.Black)
                    {
                        Right = new RedBlackNode<int>(100, Colour.Red)
                    }
                },
                Count = 4
            };
        }


        public override void InitFiveNodesLeftFullForTests()
        {
            FiveNodesLeftFull = new RedBlackTree<int>()
            {
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Black)
                    {
                        Left = new RedBlackNode<int>(12, Colour.Red),
                        Right = new RedBlackNode<int>(32, Colour.Red)
                    },
                    Right = new RedBlackNode<int>(75, Colour.Black)
                },
                Count = 5
            };
        }
            
        public override void InitBiggerForTests()
        {
            Bigger = new RedBlackTree<int>()
            {
                Count = 9,
                Root = new RedBlackNode<int>(100, Colour.Black)
                {
                    Left = new RedBlackNode<int>(50, Colour.Red)
                    {
                        Left = new RedBlackNode<int>(25, Colour.Black)
                        {
                            Right = new RedBlackNode<int>(30, Colour.Red)
                        },
                        Right = new RedBlackNode<int>(75, Colour.Black)
                    },
                    Right = new RedBlackNode<int>(150, Colour.Red)
                    {
                        Left = new RedBlackNode<int>(125, Colour.Black),
                        Right = new RedBlackNode<int>(175, Colour.Black)
                        {
                            Left = new RedBlackNode<int>(160, Colour.Red)
                        }
                    }
                }
            };
        }

        public void InitDelete_BlackLeftLeafRedSibling1()
        {
            InstanceDelete_BlackLeftLeafRedSibling1 = new RedBlackTree<int>()
                {
                    Count = 0,
                    Root = new RedBlackNode<int>(50, Colour.Black)
                    {
                        Left = new RedBlackNode<int>(25, Colour.Black),
                        Right = new RedBlackNode<int>(75, Colour.Red)
                        {
                            Left = new RedBlackNode<int>(63, Colour.Black),
                            Right = new RedBlackNode<int>(100, Colour.Black)
                            {
                                Left = new RedBlackNode<int>(80, Colour.Red)
                            },
                        },
                    }
                };
        }

        public void InitDelete_BlackRightLeafRedSibling1()
        {
            InstanceDelete_BlackRightLeafRedSibling1 = new RedBlackTree<int>()
            {
                Count = 0,
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Red)
                    {
                        Left = new RedBlackNode<int>(12, Colour.Black)
                        {
                            Right = new RedBlackNode<int>(20, Colour.Red),
                        },
                        Right = new RedBlackNode<int>(32, Colour.Black)
                    },
                    Right = new RedBlackNode<int>(75, Colour.Black),
                }
            };
        }

        public void InitDelete_BlackLeftLeafRedSibling2()
        {
            InstanceDelete_BlackLeftLeafRedSibling2 = new RedBlackTree<int>()
            {
                Count = 0,
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Black),
                    Right = new RedBlackNode<int>(75, Colour.Red)
                    {
                        Left = new RedBlackNode<int>(60, Colour.Black)
                        {
                            Right = new RedBlackNode<int>(70, Colour.Red)
                        },
                        Right = new RedBlackNode<int>(100, Colour.Black)
                    },
                }
            };
        }

        public void InitDelete_BlackRightLeafRedSibling2()
        {
            InstanceDelete_BlackRightLeafRedSibling2 = new RedBlackTree<int>()
            {
                Count = 0,
                Root = new RedBlackNode<int>(50, Colour.Black)
                {
                    Left = new RedBlackNode<int>(25, Colour.Red)
                    {
                        Left = new RedBlackNode<int>(10, Colour.Black),
                        Right = new RedBlackNode<int>(40, Colour.Black)
                        {
                            Left = new RedBlackNode<int>(30, Colour.Red),
                        }
                    },
                    Right = new RedBlackNode<int>(75, Colour.Black),
                }
            };
        }

        public override void InitCustomForTests()
        {
            switch (TestContext.TestName)
            {
                case "Delete_BlackLeftLeafRedSibling1":
                    this.InitDelete_BlackLeftLeafRedSibling1();
                    break;
                case "Delete_BlackRightLeafRedSibling1":
                    this.InitDelete_BlackRightLeafRedSibling1();
                    break;
                case "Delete_BlackLeftLeafRedSibling2":
                    this.InitDelete_BlackLeftLeafRedSibling2();
                    break;
                case "Delete_BlackRightLeafRedSibling2":
                    this.InitDelete_BlackRightLeafRedSibling2();
                    break;
            }
        }

        public override void CleanupCustom()
        {
            InstanceDelete_BlackLeftLeafRedSibling1 = null;
            InstanceDelete_BlackLeftLeafRedSibling2 = null;
            InstanceDelete_BlackRightLeafRedSibling1 = null;
            InstanceDelete_BlackRightLeafRedSibling2 = null;

        }

        #endregion

        #region RedBlackTree.Insert

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThreeNodesFull_RightRight()
        {
            InstanceThreeNodesFull.Insert(100);

            Assert.AreEqual<int>(50, InstanceThreeNodesFull.Root.Value);
            Assert.AreEqual<int>(25, InstanceThreeNodesFull.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceThreeNodesFull.Root.Right.Value);
            Assert.AreEqual<int>(100, InstanceThreeNodesFull.Root.Right.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceThreeNodesFull.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceThreeNodesFull.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceThreeNodesFull.Root.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceThreeNodesFull.Root.Right.Right.Colour);

            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Right);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Right.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Right.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Insert_ThreeNodesFull_LeftLeft()
        {
            ThreeNodesFull.Insert(1);

            Assert.AreEqual<int>(50, InstanceThreeNodesFull.Root.Value);
            Assert.AreEqual<int>(25, InstanceThreeNodesFull.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceThreeNodesFull.Root.Right.Value);
            Assert.AreEqual<int>(1, InstanceThreeNodesFull.Root.Left.Left.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceThreeNodesFull.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceThreeNodesFull.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceThreeNodesFull.Root.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceThreeNodesFull.Root.Left.Left.Colour);

            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Left.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Left.Right);
            Assert.IsNull(InstanceThreeNodesFull.Root.Left.Right);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Left);
            Assert.IsNull(InstanceThreeNodesFull.Root.Right.Right);
        }

        #endregion

        #region RedBlackTree.Delete

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_FourNodesLeftLeft_BlackLeaf()
        {
            Assert.IsTrue(FourNodesLeftLeft.Delete(75));

            Assert.AreEqual<int>(25, InstanceFourNodesLeftLeft.Root.Value);
            Assert.AreEqual<int>(12, InstanceFourNodesLeftLeft.Root.Left.Value);
            Assert.AreEqual<int>(50, InstanceFourNodesLeftLeft.Root.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesLeftLeft.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesLeftLeft.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesLeftLeft.Root.Right.Colour);

            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Right.Left);
            Assert.IsNull(InstanceFourNodesLeftLeft.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_FourNodesRightRight_BlackLeaf()
        {
            Assert.IsTrue(FourNodesRightRight.Delete(25));

            Assert.AreEqual<int>(75, InstanceFourNodesRightRight.Root.Value);
            Assert.AreEqual<int>(50, InstanceFourNodesRightRight.Root.Left.Value);
            Assert.AreEqual<int>(100, InstanceFourNodesRightRight.Root.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesRightRight.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesRightRight.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesRightRight.Root.Right.Colour);

            Assert.IsNull(InstanceFourNodesRightRight.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesRightRight.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesRightRight.Root.Right.Left);
            Assert.IsNull(InstanceFourNodesRightRight.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackLeftLeafRedSibling1()
        {
            Assert.IsTrue(InstanceDelete_BlackLeftLeafRedSibling1.Delete(25));

            Assert.AreEqual<int>(75, InstanceDelete_BlackLeftLeafRedSibling1.Root.Value);
            Assert.AreEqual<int>(50, InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Value);
            Assert.AreEqual<int>(100, InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Value);
            Assert.AreEqual<int>(63, InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Right.Value);
            Assert.AreEqual<int>(80, InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Left.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling1.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Left.Colour);

            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Left);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Right.Left);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling1.Root.Left.Right.Right);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Right);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Left.Left);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling1.Root.Right.Left.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackRightLeafRedSibling1()
        {
            Assert.IsTrue(InstanceDelete_BlackRightLeafRedSibling1.Delete(75));

            Assert.AreEqual<int>(25, InstanceDelete_BlackRightLeafRedSibling1.Root.Value);
            Assert.AreEqual<int>(12, InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Value);
            Assert.AreEqual<int>(50, InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Value);
            Assert.AreEqual<int>(20, InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Right.Value);
            Assert.AreEqual<int>(32, InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Left.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling1.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Left.Colour);

            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Left);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Right.Left);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling1.Root.Left.Right.Right);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Right);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Left.Left);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling1.Root.Right.Left.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackLeftLeafRedSibling2()
        {
            Assert.IsTrue(InstanceDelete_BlackLeftLeafRedSibling2.Delete(25));

            Assert.AreEqual<int>(75, InstanceDelete_BlackLeftLeafRedSibling2.Root.Value);
            Assert.AreEqual<int>(60, InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Value);
            Assert.AreEqual<int>(100, InstanceDelete_BlackLeftLeafRedSibling2.Root.Right.Value);
            Assert.AreEqual<int>(50, InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Left.Value);
            Assert.AreEqual<int>(70, InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling2.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling2.Root.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Right.Colour);

            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Left.Left);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Left.Right);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Right.Left);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling2.Root.Left.Right.Right);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling2.Root.Right.Left);
            Assert.IsNull(InstanceDelete_BlackLeftLeafRedSibling2.Root.Right.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_BlackRightLeafRedSibling2()
        {
            Assert.IsTrue(InstanceDelete_BlackRightLeafRedSibling2.Delete(75));

            Assert.AreEqual<int>(25, InstanceDelete_BlackRightLeafRedSibling2.Root.Value);
            Assert.AreEqual<int>(10, InstanceDelete_BlackRightLeafRedSibling2.Root.Left.Value);
            Assert.AreEqual<int>(40, InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Value);
            Assert.AreEqual<int>(30, InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Left.Value);
            Assert.AreEqual<int>(50, InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling2.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling2.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Red, InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Right.Colour);

            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Left.Left);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Left.Right);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Right.Left);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling2.Root.Right.Right.Right);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling2.Root.Left.Left);
            Assert.IsNull(InstanceDelete_BlackRightLeafRedSibling2.Root.Left.Right);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_FourNodesLeftRight_BlackLeaf()
        {
            Assert.IsTrue(FourNodesLeftRight.Delete(75));

            Assert.AreEqual<int>(32, InstanceFourNodesLeftRight.Root.Value);
            Assert.AreEqual<int>(25, InstanceFourNodesLeftRight.Root.Left.Value);
            Assert.AreEqual<int>(50, InstanceFourNodesLeftRight.Root.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesLeftRight.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesLeftRight.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesLeftRight.Root.Right.Colour);

            Assert.IsNull(InstanceFourNodesLeftRight.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesLeftRight.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesLeftRight.Root.Right.Left);
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        public void Delete_FourNodesRightLeft_BlackLeaf()
        {
            Assert.IsTrue(FourNodesRightLeft.Delete(25));

            Assert.AreEqual<int>(63, InstanceFourNodesRightLeft.Root.Value);
            Assert.AreEqual<int>(50, InstanceFourNodesRightLeft.Root.Left.Value);
            Assert.AreEqual<int>(75, InstanceFourNodesRightLeft.Root.Right.Value);

            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesRightLeft.Root.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesRightLeft.Root.Left.Colour);
            Assert.AreEqual<Colour>(Colour.Black, InstanceFourNodesRightLeft.Root.Right.Colour);

            Assert.IsNull(InstanceFourNodesRightLeft.Root.Left.Left);
            Assert.IsNull(InstanceFourNodesRightLeft.Root.Left.Right);
            Assert.IsNull(InstanceFourNodesRightLeft.Root.Right.Left);
        }

        #endregion

        #region RedBlackTree.AssertTree

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_InvalidChildren()
        {
            var root = new RedBlackNode<int>(100);
            root.Left = new RedBlackNode<int>(150);

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_Invalid_DoubleRed_Left()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Left.Left = new RedBlackNode<int>(40) { Colour = Colour.Red };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_Invalid_DoubleRed_Right()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Right.Right = new RedBlackNode<int>(160) { Colour = Colour.Red };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_Invalid_BlackMismatch_Left()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Left.Left = new RedBlackNode<int>(40) { Colour = Colour.Black };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("RedBlackTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void AssertValidTree_Invalid_BlackMismatch_Right()
        {
            RedBlackNode<int> root = new RedBlackNode<int>(100) { Colour = Colour.Black };
            root.Left = new RedBlackNode<int>(50) { Colour = Colour.Red };
            root.Right = new RedBlackNode<int>(150) { Colour = Colour.Red };
            root.Right.Right = new RedBlackNode<int>(160) { Colour = Colour.Black };

            RedBlackTree<int> bst = new RedBlackTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        #endregion

    }
}
