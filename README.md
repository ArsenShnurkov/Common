Common
======

This library contains some commonly used data structures. I mainly wrote them for the educational challenge, but I believe they've evolved to the point where they could be quite useful over a wide variety of applications.

* BinarySearchTree is an unabalanced BST that uses iterative algorithms in order to avoid stack overflows.
* RedBlackTree is a self-balancing BST that has faster inserts and deletes than the AVLTree, but slower lookup speeds. RedBlackTree uses recursive algorithms.
* AVLTree is a self-balancing BST that has slower inserts than the RedBlackTree but faster lookup speeds. This tree is also recursive.
* Skip List achiieves approximately the same performance as a Red-Black or AVL tree but it's implementation is much more simple and easy to understand.
* Heap can be constructed as either a min or a max heap.

The insert, delete, and find timings are for an older itereation of the code but can still be used to see an approximate comparison of the efficiency of each operation. The timings included for the BinarySearchTreeBase can be ignored. This used to be a base class shared between the AVL and RedBlackTrees and has been removed in order to increase their efficiency.

This solution includes 574 unit tests that cover all of the important functionality in the library.