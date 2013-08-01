Common
======

This Common library currently contains some generic binary search trees that I've been working on lately.

Notice that there are two basic binary search trees.

SafeBinarySearchTree is a sealed class and uses iterative algorithms to avoid stack overflows on a tree that is highly unbalanced, or even linear.
BinarySearchTree uses recursive algorithms and is used as the base class for the self balancing binary search trees.

Originally I was using the SafeBinarySearchTree as the base class for the self balancing trees. However that implementation required that I maintain a stack of nodes that could be used to walk up the binary tree after insertion and deletion in order to rebalance the ancestors of the affected node. My timings found that the recursive BST was considerably faster than the iterative BST with parent stack so I decided to remove the parent stack and make the SafeBinarySearchTree sealed.

The RedBlackTree is functional, but I only just finished it. When I get the chance I will be refactoring it a bit to clean up the code and will at the same time hopefully be able to find some optimizations.