namespace CommonTestsInternal.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using Common.Collections.Generic;
    using Common.Collections.Generic.Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class HeapTests
    {
        #region Constructors

        [TestMethod]
        [TestCategory("Heap")]
        public void Heap_Constructor1()
        {
            Assert.AreEqual<int>(0, new Heap<int>(HeapType.Max).List.Capacity);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Heap_Constructor2()
        {
            Assert.AreEqual<int>(10, new Heap<int>(HeapType.Max, 10).List.Capacity);
        }

        #endregion

        #region Indexors

        [TestMethod]
        [TestCategory("Heap")]
        public void LeftChildOf_Root()
        {
            Assert.AreEqual<int>(1, Heap<int>.LeftChildIndexOf(0));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void RightChildOf_Root()
        {
            Assert.AreEqual<int>(2, Heap<int>.RightChildIndexOf(0));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void LeftChildOf_RootLeft()
        {
            Assert.AreEqual<int>(3, Heap<int>.LeftChildIndexOf(1));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void RightChildOf_RootLeft()
        {
            Assert.AreEqual<int>(4, Heap<int>.RightChildIndexOf(1));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void LeftChildOf_RootRight()
        {
            Assert.AreEqual<int>(5, Heap<int>.LeftChildIndexOf(2));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void RightChildOf_RootRight()
        {
            Assert.AreEqual<int>(6, Heap<int>.RightChildIndexOf(2));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void LeftChildOf_RootLeftLeftLeft()
        {
            Assert.AreEqual<int>(31, Heap<int>.LeftChildIndexOf(15));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void RightChildOf_RootLeftLeftLeft()
        {
            Assert.AreEqual<int>(32, Heap<int>.RightChildIndexOf(15));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeftLeftLeftLeft()
        {
            Assert.AreEqual<int>(7, Heap<int>.ParentIndexOf(15));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeftLeftLeftRight()
        {
            Assert.AreEqual<int>(7, Heap<int>.ParentIndexOf(16));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeftLeftLeft()
        {
            Assert.AreEqual<int>(3, Heap<int>.ParentIndexOf(7));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeftLeftRight()
        {
            Assert.AreEqual<int>(3, Heap<int>.ParentIndexOf(8));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeftLeft()
        {
            Assert.AreEqual<int>(1, Heap<int>.ParentIndexOf(3));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeftRight()
        {
            Assert.AreEqual<int>(1, Heap<int>.ParentIndexOf(4));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootLeft()
        {
            Assert.AreEqual<int>(0, Heap<int>.ParentIndexOf(1));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void ParentOf_RootRight()
        {
            Assert.AreEqual<int>(0, Heap<int>.ParentIndexOf(2));
        }

        [TestMethod]
        [TestCategory("Heap")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ParentOf_Root()
        {
            Assert.IsNull(Heap<int>.ParentIndexOf(0));
        }

        #endregion

        #region Comparors

        [TestMethod]
        [TestCategory("Heap")]
        public void IsLargerThanParent_True()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            Assert.IsTrue(heap.IsLargerThan(1, 0));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void IsLargerThanParent_False()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            Assert.IsFalse(heap.IsLargerThan(0, 1));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void IsSmallerThanParent_True()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            Assert.IsTrue(heap.IsSmallerThanParent(0, 1));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void IsSmallerThanParent_False()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            Assert.IsFalse(heap.IsSmallerThanParent(1, 0));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void IsHigherPriority_MaxHeap()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            Assert.IsTrue(heap.IsHigherPriorityThanParent(1, 0));
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void IsHigherPriority_MinHeap()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            Assert.IsTrue(heap.IsHigherPriorityThanParent(0, 1));
        }

        #endregion

        #region Swap

        [TestMethod]
        [TestCategory("Heap")]
        public void Swap()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            heap.Swap(0, 1);

            Assert.AreEqual<int>(75, heap.List[0]);
            Assert.AreEqual<int>(50, heap.List[1]);
        }

        #endregion

        #region HeapifyUp

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyUp_RootOnly()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50
                }
            };

            heap.HeapifyUp(0);

            Assert.AreEqual<int>(50, heap.List[0]);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyUp_IsHigherPriority_Swap()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            using (ShimsContext.Create())
            {
                int swappedChildIx = int.MinValue;
                int swappedParentIx = int.MinValue;
                ShimHeap<int>.AllInstances.SwapInt32Int32 = (h, childIx, parentIx) =>
                {
                    swappedChildIx = childIx;
                    swappedParentIx = parentIx;
                };

                heap.HeapifyUp(1);

                Assert.AreEqual<int>(1, swappedChildIx);
                Assert.AreEqual<int>(0, swappedParentIx);
            }
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyUp_IsNotHigherPriority_DontSwap()
        {
            Heap<int> heap = new Heap<int>(HeapType.Min)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            using (ShimsContext.Create())
            {
                bool swapCalled = false;
                ShimHeap<int>.AllInstances.SwapInt32Int32 = (h, childIx, parentIx) => { swapCalled = true; };

                heap.HeapifyUp(1);

                Assert.IsFalse(swapCalled);
            }
        }

        #endregion

        #region Insert

        [TestMethod]
        [TestCategory("Heap")]
        public void Insert_IntoEmpty()
        {
            using (ShimsContext.Create())
            {
                int insertedAt = -1;
                ShimHeap<int>.AllInstances.HeapifyUpInt32 = (h, ix) => { insertedAt = ix; };

                Heap<int> heap = new Heap<int>(HeapType.Max);
                heap.Insert(50);

                Assert.AreEqual<int>(0, insertedAt);
                Assert.AreEqual<int>(50, heap.List[0]);
                Assert.AreEqual<int>(1, heap.Count);
            }
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Insert_SecondNode()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50
                }
            };

            using (ShimsContext.Create())
            {
                int insertedAt = -1;
                ShimHeap<int>.AllInstances.HeapifyUpInt32 = (h, ix) => { insertedAt = ix; };

                heap.Insert(75);

                Assert.AreEqual<int>(1, insertedAt);
                Assert.AreEqual<int>(50, heap.List[0]);
                Assert.AreEqual<int>(75, heap.List[1]);
                Assert.AreEqual<int>(2, heap.Count);
            }
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Insert_ThirdNode()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    75
                }
            };

            using (ShimsContext.Create())
            {
                int insertedAt = -1;
                ShimHeap<int>.AllInstances.HeapifyUpInt32 = (h, ix) => { insertedAt = ix; };

                heap.Insert(25);

                Assert.AreEqual<int>(2, insertedAt);
                Assert.AreEqual<int>(50, heap.List[0]);
                Assert.AreEqual<int>(75, heap.List[1]);
                Assert.AreEqual<int>(25, heap.List[2]);
                Assert.AreEqual<int>(3, heap.Count);
            }
        }

        #endregion

        #region HeapifyDown

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyDown_Empty()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max);
            heap.HeapifyDown();
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyDown_RootOnly()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50
                }
            };

            heap.HeapifyDown();

            Assert.AreEqual<int>(1, heap.Count);
            Assert.AreEqual<int>(50, heap.List[0]);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyDown_SwapLeft()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    25,
                    50,
                    10
                }
            };

            using (ShimsContext.Create())
            {
                int swappedChildIx = int.MinValue;
                int swappedParentIx = int.MinValue;

                ShimHeap<int>.AllInstances.SwapInt32Int32 = (h, childIx, parentIx) =>
                {
                    swappedChildIx = childIx;
                    swappedParentIx = parentIx;
                };

                heap.HeapifyDown();

                Assert.AreEqual<int>(1, swappedChildIx);
                Assert.AreEqual<int>(0, swappedParentIx);
            }
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyDown_SwapRight()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    25,
                    10,
                    50
                }
            };

            using (ShimsContext.Create())
            {
                int swappedChildIx = int.MinValue;
                int swappedParentIx = int.MinValue;

                ShimHeap<int>.AllInstances.SwapInt32Int32 = (h, childIx, parentIx) =>
                {
                    swappedChildIx = childIx;
                    swappedParentIx = parentIx;
                };

                heap.HeapifyDown();

                Assert.AreEqual<int>(2, swappedChildIx);
                Assert.AreEqual<int>(0, swappedParentIx);
            }
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void HeapifyDown_NoChanges()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    10,
                    25
                }
            };

            heap.HeapifyDown();

            Assert.AreEqual<int>(3, heap.Count);
            Assert.AreEqual<int>(50, heap.List[0]);
            Assert.AreEqual<int>(10, heap.List[1]);
            Assert.AreEqual<int>(25, heap.List[2]);
        }

        #endregion

        #region Remove

        [TestMethod]
        [TestCategory("Heap")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_FromEmpty()
        {
            new Heap<int>(HeapType.Max).Remove();
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Remove_HeapWithOneElement()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50
                }
            };

            using (ShimsContext.Create())
            {
                bool heapifyDownCalled = false;
                ShimHeap<int>.AllInstances.HeapifyDown = (h) => { heapifyDownCalled = true; };

                Assert.AreEqual<int>(50, heap.Remove());
                Assert.AreEqual<int>(0, heap.Count);
                Assert.IsTrue(heapifyDownCalled);
            }
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Remove_HeapWithMoreThanOneElement()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    40,
                    30,
                }
            };

            using (ShimsContext.Create())
            {
                bool heapifyDownCalled = false;
                ShimHeap<int>.AllInstances.HeapifyDown = (h) => { heapifyDownCalled = true; };

                Assert.AreEqual<int>(50, heap.Remove());
                Assert.AreEqual<int>(2, heap.Count);
                Assert.AreEqual<int>(30, heap.List[0]);
                Assert.AreEqual<int>(40, heap.List[1]);
                Assert.IsTrue(heapifyDownCalled);
            }
        }

        #endregion

        #region Peek

        [TestMethod]
        [TestCategory("Heap")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyTree()
        {
            new Heap<int>(HeapType.Max).Peek();
        }
        
        [TestMethod]
        [TestCategory("Heap")]
        public void Peek_NonEmptyTree()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    40,
                    30
                }
            };

            Assert.AreEqual<int>(50, heap.Peek());
            Assert.AreEqual<int>(50, heap.List[0]);
        }

        #endregion

    }
}
