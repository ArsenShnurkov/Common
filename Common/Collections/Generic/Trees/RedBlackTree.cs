namespace Common.Collections.Generic
{
    using System;

    public class RedBlackTree<T> : BinarySearchTree<T>, IBinarySearchTree<T> where T : IComparable<T>
    {
        public RedBlackTree()
            : base()
        {
        }

        #region Properties

        /// <summary>
        /// Returns the root of the red black tree casted to a RedBlackNode so we can
        /// access it's colour more easily.
        /// </summary>
        internal RedBlackNode<T> RootRaw
        {
            get { return base.Root as RedBlackNode<T>; }
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the given value into the tree and ensures that the tree is rebalanced according to the red-black tree rules
        /// 
        /// Throws a ArgumentException if the value already exists in the tree
        /// 
        /// O(log n)
        /// </summary>
        public new void Insert(T value)
        {
            RedBlackNode<T> node = new RedBlackNode<T>(value);
            this.Root = this.Insert(this.Root, node);

            if (this.RootRaw.Colour == Colour.Red)
                this.RootRaw.Colour = Colour.Black;
        }

        /// <summary>
        /// Inserts the given node underneath the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree according to the red-black tree rules
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal override IInternalBinaryNode<T> Insert(IInternalBinaryNode<T> root, IInternalBinaryNode<T> node)
        {
            return this.Insert(root as RedBlackNode<T>, node as RedBlackNode<T>);
        }

        /// <summary>
        /// Inserts the given node underneath the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree according to the red-black tree rules
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private RedBlackNode<T> Insert(RedBlackNode<T> root, RedBlackNode<T> node)
        {
            root = base.Insert(root, node) as RedBlackNode<T>;

            if (root.Value.CompareTo(node.Value) > 0)
                root = Insert_Case1_LeftTwoRedChidren(root);
            else
                root = Insert_Case1_RightTwoRedChidren(root);

            return root;
        }


        /// <summary>
        /// Deals with the case where after inserting a node to the left, a node has two red children. If this case is not matched we move on to case 2
        /// </summary>
        private RedBlackNode<T> Insert_Case1_LeftTwoRedChidren(RedBlackNode<T> root)
        {
            if (this.IsNodeRed(root.Left) && (this.IsNodeRed(root.Left.Left) || this.IsNodeRed(root.Left.Right)))
            {
                if (this.IsNodeRed(root.Right))
                    MoveBlackDown(root);
                else
                {
                    root = Insert_Case2_TwoLeftReds(root);
                }
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the right, a node has two red children. If this case is not matched we move on to case 2
        /// </summary>
        private RedBlackNode<T> Insert_Case1_RightTwoRedChidren(RedBlackNode<T> root)
        {
            if (this.IsNodeRed(root.Right) && (this.IsNodeRed(root.Right.Right) || this.IsNodeRed(root.Right.Left)))
            {
                if (this.IsNodeRed(root.Left))
                    MoveBlackDown(root);
                else
                {
                    root = Insert_Case2_TwoRightReds(root);
                }
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after an insert to the left we have two red nodes as left sub-children of each-other
        /// </summary>
        private RedBlackNode<T> Insert_Case2_TwoLeftReds(RedBlackNode<T> root)
        {
            if (this.IsNodeRed(root.Left.Left))
            {
                root = root.RotateRight();
            }
            else if (this.IsNodeRed(root.Left.Right))
            {
                root = Insert_Case3_LeftRightReds(root);
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after an insert to the right we have two red nodes as right sub-children of each-other
        /// </summary>
        private RedBlackNode<T> Insert_Case2_TwoRightReds(RedBlackNode<T> root)
        {
            if (this.IsNodeRed(root.Right.Right))
            {
                root = root.RotateLeft();
            }
            else if (this.IsNodeRed(root.Right.Left))
            {
                root = Insert_Case3_RightLeftReds(root);
            }

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the right we have a red node as a right sub-child of its parent and has another red node as a left subchild.
        /// </summary>
        private RedBlackNode<T> Insert_Case3_RightLeftReds(RedBlackNode<T> root)
        {
            root.Right = root.Right.RotateRight();
            root = root.RotateLeft();

            return root;
        }

        /// <summary>
        /// Deals with the case where after inserting a node to the left we have a red node as a left sub-child of its parent and has another red node as a right subchild.
        /// </summary>
        private RedBlackNode<T> Insert_Case3_LeftRightReds(RedBlackNode<T> root)
        {
            root.Left = root.Left.RotateLeft();
            root = root.RotateRight();

            return root;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the given value from the tree at the given root and ensures red-black tree properties are maintained ny recolouring nodes and rotations
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal override IInternalBinaryNode<T> Delete(IInternalBinaryNode<T> root, T value)
        {
            bool done = false;
            RedBlackNode<T> result = this.Delete(root as RedBlackNode<T>, value, ref done);
            root = result;

            if (result != null)
                result.Colour = Colour.Black;

            --this.Count;

            return root;
        }

        /// <summary>
        /// Deletes the given value from the tree at the given root and ensures red-black tree properties are maintained ny recolouring nodes and rotations
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <param name="done">A flag determining if more rebalancing and recolouring is necessary</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal RedBlackNode<T> Delete(RedBlackNode<T> root, T value, ref bool done)
        {
            int compareResult = root.Value.CompareTo(value);
            if (compareResult == 0)
            {
                // Node has two children, replace with in order predecessor and then recursively delete predecessor
                if (root.Left != null && root.Right != null)
                {
                    compareResult = 1;
                    root.Value = root.InOrderPredecessor.Value;
                    value = root.Value;
                    root.ResetHeight();
                }
                // Node only has left child
                else if (root.Left != null)
                {
                    root.Left.ResetHeight();
                    if (this.IsNodeRed(root)) // node to delete is red - no problems
                        done = true;
                    else if (this.IsNodeRed(root.Left)) // node to delete is black but has red child that can be recoloured
                    {
                        root.Left.Colour = Colour.Black;
                        done = true;
                    }

                    root = root.Left;
                }
                // Node only has Right child
                else if (root.Right != null)
                {
                    root.Right.ResetHeight();
                    if (this.IsNodeRed(root)) // node to delete is red - no problems
                        done = true;
                    else if (this.IsNodeRed(root.Right)) // node to delete is black but has red child that can be recoloured
                    {
                        root.Right.Colour = Colour.Black;
                        done = true;
                    }

                    root = root.Right;
                }
                else // deleting leaf - done if red
                {
                    done = this.IsNodeRed(root);
                    root = null;
                }
            }

            if (compareResult > 0)
            {
                root.Left = Delete(root.Left, value, ref done);
                if (!done)
                    root = this.DeleteRebalanceLeft(root, ref done);
            }
            else if (compareResult < 0)
            {
                root.Right = Delete(root.Right, value, ref done);
                if (!done)
                    root = this.DeleteRebalanceRight(root, ref done);
            }

            return root;
        }

        /// <summary>
        /// Rebalances the root after a black node was deleted in the right sub-tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="done"></param>
        /// <returns></returns>
        private RedBlackNode<T> DeleteRebalanceRight(RedBlackNode<T> root, ref bool done)
        {
            RedBlackNode<T> parent = root;
            RedBlackNode<T> sibling = root.Left;

            // Rotation to reduce the red sibling case to the easier to handle black sibling case
            if (this.IsNodeRed(sibling))
            {
                root = root.RotateRight();
                sibling = parent.Left;
            }

            if (sibling != null)
            {
                if (!this.IsNodeRed(sibling.Left) && !this.IsNodeRed(sibling.Right))
                {
                    if (this.IsNodeRed(parent))
                        done = true;

                    parent.Colour = Colour.Black;
                    sibling.Colour = Colour.Red;
                }
                else
                {
                    Colour parentColour = parent.Colour;
                    bool sameRoot = root == parent;

                    if (this.IsNodeRed(sibling.Left))
                        parent = parent.RotateRight();
                    else
                    {
                        parent.Left = parent.Left.RotateLeft();
                        parent = parent.RotateRight();
                    }

                    parent.Colour = parentColour;
                    parent.Left.Colour = Colour.Black;
                    parent.Right.Colour = Colour.Black;

                    if (sameRoot)
                        root = parent;
                    else
                        root.Right = parent;

                    done = true;
                }
            }

            return root;
        }

        private RedBlackNode<T> DeleteRebalanceLeft(RedBlackNode<T> root, ref bool done)
        {
            // Rotation to reduce the red sibling case to the easier to handle black sibling case
            RedBlackNode<T> parent = root;
            RedBlackNode<T> sibling = root.Right;

            if (this.IsNodeRed(sibling))
            {
                root = root.RotateLeft();
                sibling = parent.Right;
            }

            if (sibling != null)
            {
                if (!this.IsNodeRed(sibling.Left) && !this.IsNodeRed(sibling.Right))
                {
                    if (this.IsNodeRed(parent))
                    {
                        done = true;
                    }

                    parent.Colour = Colour.Black;
                    sibling.Colour = Colour.Red;
                }
                else
                {
                    Colour parentColour = parent.Colour;
                    bool sameRoot = root == parent;

                    if (this.IsNodeRed(sibling.Right))
                        parent = parent.RotateLeft();
                    else
                    {
                        parent.Right = parent.Right.RotateRight();
                        parent = parent.RotateLeft();
                    }

                    parent.Colour = parentColour;
                    parent.Left.Colour = Colour.Black;
                    parent.Right.Colour = Colour.Black;

                    if (sameRoot)
                        root = parent;
                    else
                        root.Left = parent;

                    done = true;
                }
            }

            return root;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns true if the node is red. Returns false if the node is black or null.
        /// </summary>
        private bool IsNodeRed(RedBlackNode<T> node)
        {
            return (node != null && node.Colour == Colour.Red);
        }

        /// <summary>
        /// Moves a black root node down to it's two children and colours the root red
        /// </summary>
        /// <param name="root"></param>
        private static void MoveBlackDown(RedBlackNode<T> root)
        {
            root.Colour = Colour.Red;
            root.Left.Colour = Colour.Black;
            root.Right.Colour = Colour.Black;
        }

        #endregion

        public override void AssertValidTree()
        {
            base.AssertValidTree();

            int numBlack;
            this.AssertValidTree(this.RootRaw, out  numBlack);
        }

        private void AssertValidTree(RedBlackNode<T> root, out int numBlack)
        {
            if (root == null)
            {
                numBlack = 0;
            }
            else
            {
                if (this.IsNodeRed(root))
                {
                    if (this.IsNodeRed(root.Left) || this.IsNodeRed(root.Right))
                        throw new InvalidTreeException();
                }

                int leftBlack;
                int rightBlack;

                AssertValidTree(root.Left, out leftBlack);
                AssertValidTree(root.Right, out rightBlack);

                if (leftBlack != rightBlack)
                    throw new InvalidTreeException();

                if (this.IsNodeRed(root))
                    numBlack = leftBlack;
                else
                    numBlack = leftBlack + 1;
            }
        }
    }
}
