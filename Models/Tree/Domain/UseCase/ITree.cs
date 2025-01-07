namespace Kapitoshka3.Models.Tree.Domain.UseCase
{
    using Kapitoshka3.Models.Tree.Domain.Entity;
    using Kapitoshka3.Models.Node.Domain.Entity;
    using Kapitoshka3.Models.StringListTree.Domain.Entity;
    // Интерфейс с методами для строительства и работы с деревом
    public  interface ITree
    {
        public Tree Build(List<Node> nodes);
        public int FullQuentity(Tree tree);
        public List<StringListTree> TreeToListString(Tree tree, int tab);
    }
}
