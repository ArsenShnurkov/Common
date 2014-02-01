namespace CommonTestsInternal.Collections.Generic
{
    using System.Collections.Generic;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class HeapTests
    {
        #region Insert

        [TestMethod]
        [TestCategory("Heap")]
        public void Insert_SingleBubbleToRoot()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50
                }
            };

            heap.Insert(100);

            Assert.AreEqual<int>(100, heap.List[0]);
            Assert.AreEqual<int>(50, heap.List[1]);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Insert_SingleBubbleToInnerNode()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    150,
                    50,
                    100
                }
            };

            heap.Insert(75);

            Assert.AreEqual<int>(150, heap.List[0]);
            Assert.AreEqual<int>(75, heap.List[1]);
            Assert.AreEqual<int>(100, heap.List[2]);
            Assert.AreEqual<int>(50, heap.List[3]);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Insert_MultipleBubbleToRoot()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    150, // root
                    50,  // left child
                    100, // right child
                    45,  // left child of 50
                    40,  // right child of 50
                    95,  // left child of 100
                    90,  // right child of 100
                }
            };

            heap.Insert(200);

            Assert.AreEqual<int>(200, heap.List[0]);
            Assert.AreEqual<int>(150, heap.List[1]);
            Assert.AreEqual<int>(100, heap.List[2]);
            Assert.AreEqual<int>(50, heap.List[3]);
            Assert.AreEqual<int>(40, heap.List[4]);
            Assert.AreEqual<int>(95, heap.List[5]);
            Assert.AreEqual<int>(90, heap.List[6]);
            Assert.AreEqual<int>(45, heap.List[7]);
        }

        #endregion

        #region Remove

        [TestMethod]
        [TestCategory("Heap")]
        public void Remove_SingleBubbleLeftToLeaf()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    45,
                    40,
                }
            };

            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(2, heap.Count);
            Assert.AreEqual<int>(45, heap.List[0]);
            Assert.AreEqual<int>(40, heap.List[1]);
        }

        [TestMethod]
        [TestCategory("Heap")]
        public void Remove_SingleBubbleRightToLeaf()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    30,
                    40,
                    20,
                }
            };

            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(3, heap.Count);
            Assert.AreEqual<int>(40, heap.List[0]);
            Assert.AreEqual<int>(30, heap.List[1]);
            Assert.AreEqual<int>(20, heap.List[2]);
        }


        [TestMethod]
        [TestCategory("Heap")]
        public void Remove_MultipleBubbles()
        {
            Heap<int> heap = new Heap<int>(HeapType.Max)
            {
                List = new List<int>()
                {
                    50,
                    40,
                    30,
                    20,
                    10,
                }
            };

            Assert.AreEqual<int>(50, heap.Remove());
            Assert.AreEqual<int>(4, heap.Count);
            Assert.AreEqual<int>(40, heap.List[0]);
            Assert.AreEqual<int>(20, heap.List[1]);
            Assert.AreEqual<int>(30, heap.List[2]);
            Assert.AreEqual<int>(10, heap.List[3]);
        }

        #endregion
    }
}
