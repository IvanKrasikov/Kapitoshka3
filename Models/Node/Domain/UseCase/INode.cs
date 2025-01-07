namespace Kapitoshka3.Models.Node.Domain.UseCase
{
    using Kapitoshka3.Models.Node.Domain.Entity;
    // Интерфейс: метода по работе с БД
    public interface INode
    {
        void Add(Node node);
        void Update(int id);
        List<Node> GetList();
        bool IsNull();
    }
}
