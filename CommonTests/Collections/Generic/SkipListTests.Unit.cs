namespace CommonTestsInternal.Collections.Generic
{
    using Common.Collections.Generic;
    using Common.Collections.Generic.Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class SkipListTests
    {
        #region Setup

        public TestContext TestContext { set; get; }

        public SkipList<int> Empty;
        public SkipList<int> OneLevelOneNode;
        public SkipList<int> OneLevelTwoNodes;
        public SkipList<int> TwoLevelsThreeNodes;
        public SkipList<int> TwoLevelsFourNodes;

        [TestInitialize]
        public void InitTest()
        {
            if (TestContext.TestName.Contains("Empty"))
                this.InitEmptyListForTests();
            else if (TestContext.TestName.Contains("1LevelOneNode"))
                this.Init1LevelOneNodeListForTests();
            else if (TestContext.TestName.Contains("1LevelTwoNodes"))
                this.Init1LevelTwoNodesForTests();
            else if (TestContext.TestName.Contains("2LevelsThreeNodes"))
                this.Init2LevelsThreeNodesForTests();
            else if (TestContext.TestName.Contains("2LevelsFourNodes"))
                this.Init2LevelsFourNodesForTests();
        }

        private void Init2LevelsFourNodesForTests()
        {
            SkipListNode<int> fourth = new SkipListNode<int>(2, 125);
            SkipListNode<int> third = new SkipListNode<int>(1, 100)
            {
                Next = new SkipListNode<int>[]
                {
                    fourth,
                }
            };
            SkipListNode<int> second = new SkipListNode<int>(2, 75)
            {
                Next = new SkipListNode<int>[]
                {
                    third,
                    fourth,
                }
            };
            SkipListNode<int> first = new SkipListNode<int>(1, 50)
            {
                Next = new SkipListNode<int>[]
                {
                    second
                }
            };

            this.TwoLevelsFourNodes = new SkipList<int>()
            {
                Count = 3,
                Levels = 2,
                Head = new SkipListNode<int>(2, 0)
                {
                    Next = new SkipListNode<int>[]
                    {
                        first,
                        second
                    }
                }
            };
        }

        private void Init2LevelsThreeNodesForTests()
        {
            SkipListNode<int> third = new SkipListNode<int>(1, 100);
            SkipListNode<int> second = new SkipListNode<int>(2, 75)
            {
                Next = new SkipListNode<int>[]
                {
                    third,
                    null,
                }
            };
            SkipListNode<int> first = new SkipListNode<int>(1, 50)
            {
                Next = new SkipListNode<int>[]
                {
                    second
                }
            };

            this.TwoLevelsThreeNodes = new SkipList<int>()
            {
                Count = 3,
                Levels = 2,
                Head = new SkipListNode<int>(2, 0)
                {
                    Next = new SkipListNode<int>[]
                    {
                        first,
                        second
                    }
                }
            };
        }

        private void Init1LevelTwoNodesForTests()
        {
            this.OneLevelTwoNodes = new SkipList<int>()
            {
                Count = 2,
                Levels = 1,
                Head = new SkipListNode<int>(2, 0)
                {
                    Next = new SkipListNode<int>[]
                    {
                        new SkipListNode<int>(1, 50)
                        {
                            Next = new SkipListNode<int>[]
                            {
                                new SkipListNode<int>(1, 100)
                            }
                        },
                        null
                    }
                }
            };
        }

        private void Init1LevelOneNodeListForTests()
        {
            this.OneLevelOneNode = new SkipList<int>()
            {
                Count = 1,
                Levels = 1,
                Head = new SkipListNode<int>(1, 0)
                {
                    Next = new SkipListNode<int>[]
                    {
                        new SkipListNode<int>(1, 50)
                    }
                }
            };
        }

        private void InitEmptyListForTests()
        {
            this.Empty = new SkipList<int>();
        }

        #endregion

        #region Insert

        [TestMethod]
        [TestCategory("SkipList")]
        public void CreateSkipListNode()
        {
            using (ShimsContext.Create())
            {
                ShimSkipList<int>.AllInstances.RandomLevel = (sl) => { return 33; };
                SkipList<int> skipList = new SkipList<int>();

                SkipListNode<int> node = skipList.CreateSkipListNode(50);
                Assert.AreEqual(50, node.Value);
                Assert.AreEqual(33, node.Next.Length);
            }
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void InsertValue()
        {
            using (ShimsContext.Create())
            {
                int valuePassedToCreateSkipListNode = int.MinValue;
                SkipListNode<int> insertedNode = null;
                ShimSkipList<int>.AllInstances.CreateSkipListNodeT0 = (sl, value) => { valuePassedToCreateSkipListNode = value; return new SkipListNode<int>(1, value); };
                ShimSkipList<int>.AllInstances.InsertSkipListNodeOfT0 = (sl, newNode) => { insertedNode = newNode; };

                SkipList<int> skipList = new SkipList<int>();
                skipList.Insert(50);
                Assert.AreEqual<int>(50, valuePassedToCreateSkipListNode);
                Assert.AreEqual<int>(50, insertedNode.Value);
            }
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_IntoEmpty()
        {
            SkipListNode<int> node = new SkipListNode<int>(1, 50);
            this.Empty.Insert(node);

            Assert.AreEqual<int>(50, this.Empty.Head.Next[0].Value);
            Assert.AreEqual<int>(1, this.Empty.Levels);
            Assert.AreEqual<int>(1, this.Empty.Count);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_1LevelOneNode_AtStart()
        {
            SkipListNode<int> node = new SkipListNode<int>(1, 25);
            this.OneLevelOneNode.Insert(node);

            Assert.AreEqual<int>(25, this.OneLevelOneNode.Head.Next[0].Value);
            Assert.AreEqual<int>(50, this.OneLevelOneNode.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(1, this.OneLevelOneNode.Levels);
            Assert.AreEqual<int>(2, this.OneLevelOneNode.Count);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_1LevelOneNode_AtEnd()
        {
            SkipListNode<int> node = new SkipListNode<int>(1, 75);
            this.OneLevelOneNode.Insert(node);

            Assert.AreEqual<int>(50, this.OneLevelOneNode.Head.Next[0].Value);
            Assert.AreEqual<int>(75, this.OneLevelOneNode.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(1, this.OneLevelOneNode.Levels);
            Assert.AreEqual<int>(2, this.OneLevelOneNode.Count);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_1LevelTwoNodes_AtMiddle()
        {
            SkipListNode<int> node = new SkipListNode<int>(1, 75);
            this.OneLevelTwoNodes.Insert(node);

            Assert.AreEqual<int>(50, this.OneLevelTwoNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(75, this.OneLevelTwoNodes.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(100, this.OneLevelTwoNodes.Head.Next[0].Next[0].Next[0].Value);
            Assert.AreEqual<int>(1, this.OneLevelTwoNodes.Levels);
            Assert.AreEqual<int>(3, this.OneLevelTwoNodes.Count);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_1LevelTwoNodes_2ndLevel_AtStart()
        {
            SkipListNode<int> node = new SkipListNode<int>(2, 25);
            this.OneLevelTwoNodes.Insert(node);

            Assert.AreEqual<int>(25, this.OneLevelTwoNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(50, this.OneLevelTwoNodes.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(100, this.OneLevelTwoNodes.Head.Next[0].Next[0].Next[0].Value);

            Assert.AreEqual<int>(25, this.OneLevelTwoNodes.Head.Next[1].Value);

            Assert.AreEqual<int>(2, this.OneLevelTwoNodes.Levels);
            Assert.AreEqual<int>(3, this.OneLevelTwoNodes.Count);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_1LevelTwoNodes_2ndLevel_AtEnd()
        {
            SkipListNode<int> node = new SkipListNode<int>(2, 150);
            this.OneLevelTwoNodes.Insert(node);

            Assert.AreEqual<int>(50, this.OneLevelTwoNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(100, this.OneLevelTwoNodes.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(150, this.OneLevelTwoNodes.Head.Next[0].Next[0].Next[0].Value);

            Assert.AreEqual<int>(150, this.OneLevelTwoNodes.Head.Next[1].Value);

            Assert.AreEqual<int>(2, this.OneLevelTwoNodes.Levels);
            Assert.AreEqual<int>(3, this.OneLevelTwoNodes.Count);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Insert_1LevelTwoNodes_2ndLevel_AtMiddle()
        {
            SkipListNode<int> node = new SkipListNode<int>(2, 75);
            this.OneLevelTwoNodes.Insert(node);

            Assert.AreEqual<int>(50, this.OneLevelTwoNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(75, this.OneLevelTwoNodes.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(100, this.OneLevelTwoNodes.Head.Next[0].Next[0].Next[0].Value);

            Assert.AreEqual<int>(75, this.OneLevelTwoNodes.Head.Next[1].Value);

            Assert.AreEqual<int>(2, this.OneLevelTwoNodes.Levels);
            Assert.AreEqual<int>(3, this.OneLevelTwoNodes.Count);
        }

        #endregion

        #region Contains

        [TestMethod]
        [TestCategory("SkipList")]
        public void Contains_Found()
        {
            using (ShimsContext.Create())
            {
                ShimSkipList<int>.AllInstances.FindT0 = (skipList, value) => { return new SkipListNode<int>(1, value); };

                Assert.IsTrue(new SkipList<int>().Contains(50));
            }
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Contains_NotFound()
        {
            using (ShimsContext.Create())
            {
                ShimSkipList<int>.AllInstances.FindT0 = (skipList, value) => { return null; };
                Assert.IsFalse(new SkipList<int>().Contains(50));
            }
        }

        #endregion

        #region Find

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_EmptyList_NotFound()
        {
            Assert.IsNull(this.Empty.Find(50));
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_1LevelOneNode_NotFound()
        {
            Assert.IsNull(this.OneLevelOneNode.Find(75));
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_1LevelOneNode_FoundStart()
        {
            SkipListNode<int> node = this.OneLevelOneNode.Find(50);
            Assert.AreEqual<int>(50, node.Value);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_1LevelTwoNodes_FoundEnd()
        {
            SkipListNode<int> node = this.OneLevelTwoNodes.Find(100);
            Assert.AreEqual<int>(100, node.Value);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_2LevelsThreeNodes_FoundOnSecondLevel()
        {
            SkipListNode<int> node = this.TwoLevelsThreeNodes.Find(75);
            Assert.AreEqual<int>(75, node.Value);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_2LevelsThreeNodes_FoundAtEndOfFirstLevel()
        {
            SkipListNode<int> node = this.TwoLevelsThreeNodes.Find(100);
            Assert.AreEqual<int>(100, node.Value);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_2LevelsThreeNodes_NotFoundPastEnd()
        {
            Assert.IsNull(this.TwoLevelsThreeNodes.Find(150));
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Find_2LevelsThreeNodes_NotFoundMiddle()
        {
            Assert.IsNull(this.TwoLevelsThreeNodes.Find(80));
        }

        #endregion

        #region Delete
        
        [TestMethod]
        [TestCategory("SkipList")]
        public void Delete_2LevelsThreeNodes_Start()
        {
            Assert.IsTrue(this.TwoLevelsThreeNodes.Delete(50));

            Assert.AreEqual<int>(75, this.TwoLevelsThreeNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(100, this.TwoLevelsThreeNodes.Head.Next[0].Next[0].Value);

            Assert.AreEqual<int>(75, this.TwoLevelsThreeNodes.Head.Next[1].Value);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Delete_2LevelsThreeNodes_Middle()
        {
            Assert.IsTrue(this.TwoLevelsThreeNodes.Delete(75));

            Assert.AreEqual<int>(50, this.TwoLevelsThreeNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(100, this.TwoLevelsThreeNodes.Head.Next[0].Next[0].Value);

            Assert.IsNull(this.TwoLevelsThreeNodes.Head.Next[1]);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Delete_2LevelsThreeNodes_End()
        {
            Assert.IsTrue(this.TwoLevelsThreeNodes.Delete(100));

            Assert.AreEqual<int>(50, this.TwoLevelsThreeNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(75, this.TwoLevelsThreeNodes.Head.Next[0].Next[0].Value);

            Assert.IsNull(this.TwoLevelsThreeNodes.Head.Next[0].Next[0].Next[0]);
            Assert.IsNull(this.TwoLevelsThreeNodes.Head.Next[1].Next[1]);
        }

        [TestMethod]
        [TestCategory("SkipList")]
        public void Delete_2LevelsFourNodes_StartOfSecondLevel()
        {
            Assert.IsTrue(this.TwoLevelsFourNodes.Delete(75));

            Assert.AreEqual<int>(50, this.TwoLevelsFourNodes.Head.Next[0].Value);
            Assert.AreEqual<int>(100, this.TwoLevelsFourNodes.Head.Next[0].Next[0].Value);
            Assert.AreEqual<int>(125, this.TwoLevelsFourNodes.Head.Next[0].Next[0].Next[0].Value);

            Assert.AreEqual<int>(125, this.TwoLevelsFourNodes.Head.Next[1].Value);
            Assert.IsNull(this.TwoLevelsFourNodes.Head.Next[0].Next[0].Next[0].Next[0]);
        }

        #endregion
    }
}
