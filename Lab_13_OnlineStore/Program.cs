using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Book<int> book1 = new("Достоевский", 1843, 504, "Преступление и наказание");
        book1.printInfo();

        Console.WriteLine();

        Book<string> book2 = new("Достоевский", "1843", 504, "Преступление и наказание");
        book2.printInfo();

        Console.WriteLine();

        User<int> user1 = new(141414, "1234");
        user1.printUsername();
        user1.printPassword();

        Console.WriteLine();

        User<string> user2 = new("User", "4321");
        user2.printUsername();
        user2.printPassword();

        Console.WriteLine();

        Purchace purchace = new(user1, book1);
        purchace.printPurchase();
    }
}
interface IPublishing
{
    void printBookName();
    void printAuthor();
}
interface IBook : IPublishing
{
    void printPublicationDate();
    void printPageCount();
}
class Book<T> : IBook
{
    public Book(string author, T publicationDate, int pageCount, string bookName)
    {
        this.author = author;
        this.publicationDate = publicationDate;
        this.pageCount = pageCount;
        this.bookName = bookName;
    }

    public string author { get; set; }
    public T publicationDate { get; set; }
    public int pageCount { get; set; }
    public string bookName { get; set; }
    public void printAuthor()
    {
        Console.WriteLine(author);
    }

    public void printBookName()
    {
        Console.WriteLine($"Название: {bookName}");
    }

    public void printPageCount()
    {
        Console.WriteLine($"Количество страниц : {pageCount}");
    }

    public void printPublicationDate()
    {
        Console.WriteLine($"Дата публикации: {publicationDate}");
    }
    public void printInfo()
    {
        printAuthor();
        printBookName();
        printPageCount();
        
    }
}
interface IUser
{
    void printPassword();
    void printUsername();
}
class User<T> : IUser
{
    private T username;
    private string password;

    public User(T username, string password)
    {
        this.username = username;

        var hash = SHA256.Create();
        var hashpass= hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder sb = new StringBuilder();
        foreach(var i in hashpass)
        {
            sb.Append(i.ToString());
        }
        this.password = sb.ToString();
    }

    public void printUsername()
    {
        Console.WriteLine($"Имя пользователя {username}");
    }

    public void printPassword()
    {
        Console.WriteLine($"Пароль: {password}");
    }
}
class Purchace : IBook, IUser
{
    private IUser user;
    private IBook book;

    public Purchace(IUser user, IBook book)
    {
        this.user = user;
        this.book = book;
    }

    public void printPurchase()
    {
        user.printUsername();
        Console.WriteLine("купил");
        book.printBookName();
    }

    public void printAuthor()
    {
        
    }

    public void printBookName()
    {
        
    }

    public void printPageCount()
    {
        
    }

    public void printPassword()
    {
        
    }

    public void printPublicationDate()
    {
        
    }

    public void printUsername()
    {
     
    }
}