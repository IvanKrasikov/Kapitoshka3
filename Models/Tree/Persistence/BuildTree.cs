using Kapitoshka3.Models.Tree.Domain.UseCase;
using System.Linq;

namespace Kapitoshka3.Models.Tree.Persistence
{
    using Kapitoshka3.Models.Tree.Domain.Entity;
    using Kapitoshka3.Models.Node.Domain.Entity;
    using Kapitoshka3.Models.Node.Domain.ValueObject;
    using Kapitoshka3.Models.StringListTree.Domain.Entity;
    // Класс реализующий дерево
    public  class BuildTree : ITree
    {
        // Данный метод строид дерево и возвращает это root
        public Tree  Build(List<Node> nodes)
        {
            Tree root = new(new Node("root"));
            List<Tree> nodesTree = [];
            nodesTree.AddRange(nodes.Select(node => new Tree(node)));

            for (int i = 0; i < nodes.Count; i++)
            {
                ParentId parentId = nodes[i].ParentId;

                if (parentId.IsZero())
                {
                    root.Chuldren.Add(nodesTree[i]);
                }
                else
                {
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (nodes[j].Id == parentId.GetParentId())
                        {
                            nodesTree[j].Chuldren.Add(nodesTree[i]);
                        }
                    }
                }
            }
            return root;
        }

        // Данный метод детей в группе + дети из подгрупп данной группы
        public int FullQuentity(Tree tree)
        {
            int sum = 0;
            sum += tree.Node.Quentity.GetQuentity();

            foreach (Tree temp in tree.Chuldren)
            {
                sum += FullQuentity(temp);
            }

            return sum;
        }

        // Метод из дерева делает лист специальных строк, удобный для передачи в Index.cshtml
        public List<StringListTree> TreeToListString(Tree tree, int tab = 0) 
        {
            List<StringListTree> list = [];
            
            foreach (Tree chuld in tree.Chuldren)
            {
                string str = "";
                for (int i = 0; i < tab; i++)
                { 
                    str += "        "; 
                }
                str += (tab % 3 == 0)? " • ":(tab % 2 == 0)? " ▪ " : " o ";
                str += chuld.Node.Name.ToString();
                str += "    ";
                str += FullQuentity(chuld).ToString();

                list.Add(new StringListTree(chuld.Node.Id,str));
                list.AddRange(TreeToListString(chuld, tab + 1));
            }

            return list;
        }
    }
}
