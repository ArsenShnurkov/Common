Common
======

This Common library currently contains some generic binary search trees that I've been working on lately.

See Insert.png, Find.png, and Delete.png for speed comparisons between the various trees. These timings are mainly intended to serve as basic comparisons between the different trees. After my recent optimizations, the slowest operation (AVLTree Insert) is approximately 20% faster than it was.

* BinarySearchTree is an unabalanced BST that uses iterative algorithms in order to avoid stack overflows.
* BinarySearchTreeBase is a base class for the AVL and Red/Black Trees that uses recursive algorithms. This class cannot be instantiated on its own.
* RedBlackTree is a self-balancing BST that has faster inserts and deletes than the AVLTree, but slower lookup speeds.
* AVLTree is a self-balancing BST that has slower inserts than the RedBlackTree but faster lookup speeds.

Originally I was using the iterative BinarySearchTree as the base class for the self balancing trees. That implementation required that I maintain a stack of nodes that could be used to walk up and rebalance the binary tree after insertion and deletion. My timings found that the recursive BST was considerably faster than the iterative BST with parent stack so I decided to remove the parent stack and make the BinarySearchTree sealed.