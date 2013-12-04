Common
======

This Common library currently contains some generic binary search trees that I've been working on lately.

See Insert.png, Find.png, and Delete.png for speed comparisons between the various trees.

* SafeBinaryTree - is an unabalanced BST that uses iterative algorithms in order to avoid stack overflows
* BinarySearchTree - Recursive base class for the AVL and Red Black trees. Cannot be used on it's own
* RedBlackTree - Self-balancing BST that has faster inserts and deletes than the AVLTree, but slower lookup speeds
* AVLTree - Self-balancing BST that has slower inserts than the RedBlackTree but faster lookup speeds

Originally I was using the SafeBinarySearchTree as the base class for the self balancing trees. However that implementation required that I maintain a stack of nodes that could be used to walk up the binary tree after insertion and deletion in order to rebalance the ancestors of the affected node. My timings found that the recursive BST was considerably faster than the iterative BST with parent stack so I decided to remove the parent stack and make the SafeBinarySearchTree sealed.