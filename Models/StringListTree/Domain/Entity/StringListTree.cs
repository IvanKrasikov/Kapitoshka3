namespace Kapitoshka3.Models.StringListTree.Domain.Entity
{
    // Класс созданый для передачи всех нужных данный в Index.cshtml
    public class StringListTree(int id, string name)
    {
        private int Id { get; set; } = id;
        private string Name { get; set; } = name;

        public int GetId() => Id;
        public string GetName() => Name;
    }
}
