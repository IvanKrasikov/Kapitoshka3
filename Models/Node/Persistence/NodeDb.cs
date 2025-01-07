using System.Collections.Generic;
using Kapitoshka3.Models.Node.Domain.UseCase;

namespace Kapitoshka3.Models.Node.Persistence
{
    using Kapitoshka3.Models.Node.Domain.Entity;
    // Класс реализующий методы работы с БД из интерфейса INode
    public class NodeDb : INode
    {
        private readonly NodeContext db;

        public NodeDb()
        {
            db = new NodeContext();
        }

        public NodeContext Db { get; private set; }

        public void Add(Node node)
        {
            if (node != null)
            {
                db.Nodes.Add(node);
                db.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<Domain.Entity.Node> GetList() => [.. db.Nodes];

        public bool IsNull()
        {
                List<Node> nodes = [.. db.Nodes];
                return nodes.Count == 0;
        }

        public async void Update(int id)
        {
            Node node = db.Nodes.Find(id);
            if (node != null)
            {
                node.AddQuentityOne();
                db.Nodes.Update(node);
                await db.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
