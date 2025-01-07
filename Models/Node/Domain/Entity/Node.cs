using Kapitoshka3.Models.Node.Domain.ValueObject;

namespace Kapitoshka3.Models.Node.Domain.Entity
{
    // Строка в БД
    public class Node
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Quentity Quentity { get; set; }
        public ParentId ParentId { get; set; }
        
        public Node(Name name, Quentity quentity, ParentId parentId)
        {
            Name = name;
            Quentity = quentity;
            ParentId = parentId;
        }

        public Node(string name, int quentity = 0, int parentId = 0)
        {
            Name = new Name(name);
            Quentity = new Quentity(quentity);
            ParentId = new ParentId(parentId);
        }

        public void AddQuentityOne() => Quentity.AddOne();

        public override bool Equals(object obj) => obj is Node Node &&
                   EqualityComparer<Name>.Default.Equals(Name, Node.Name) &&
                   EqualityComparer<ParentId>.Default.Equals(ParentId, Node.ParentId) &&
                   EqualityComparer<Quentity>.Default.Equals(Quentity, Node.Quentity);

        public override int GetHashCode() => HashCode.Combine(Name, ParentId, Quentity);

        public override string ToString() => Name.ToString();
    }
}
