namespace Kapitoshka3.Models.Tree.Domain.Entity
{
    using Kapitoshka3.Models.Node.Domain.Entity;
    // Класс реализующий узел дерева
    public class Tree(Node node)
    {
        public Node Node { get; set; } = node;
        public List<Tree> Chuldren { get; set; } = [];
    }
}
