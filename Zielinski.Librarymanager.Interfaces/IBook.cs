namespace Zielinski.Librarymanager.Interfaces
{
    public interface IBook
    {
        int ID { get; set; }
        string Author { get; set; }
        string Title { get; set; }
        string ISBN { get; set; }
        IShelf Shelf { get; set; }
    }
}
