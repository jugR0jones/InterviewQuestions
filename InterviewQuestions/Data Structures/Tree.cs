using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions
{
    public class Tree<T>
    {
        private TreeNode<T> _rootNode = new TreeNode<T>();

        public IList<TreeNode<T>> Children
        {
            get
            {
                return _rootNode.Children;
            }
        }

        public void Clear()
        {
            _rootNode.Children.Clear();
        }
     }

    public class TreeNode<T>
    {
        public T Data { get; set; }
        public IList<TreeNode<T>> Children { get; set; }

        public TreeNode()
        {
            this.Children = new List<TreeNode<T>>();
        }
    }

    public static class TreeNodeExtensionMethods {

        public static TreeNode<string> NodeWithData(this IList<TreeNode<string>> children, string data)
        {
            // Hopefully this returns the children in the order they were added and there is no need to add further ordering
            return children.Where(x => x.Data == data).FirstOrDefault();
        }

    }
}
