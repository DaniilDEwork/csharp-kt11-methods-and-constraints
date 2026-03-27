using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Обобщенный метод Swap<T>");

        int a = 10;
        int b = 20;
        Console.WriteLine("До: a = " + a + ", b = " + b);
        Swap(ref a, ref b);
        Console.WriteLine("После: a = " + a + ", b = " + b);

        double x = 2.5;
        double y = 7.8;
        Console.WriteLine("До: x = " + x + ", y = " + y);
        Swap(ref x, ref y);
        Console.WriteLine("После: x = " + x + ", y = " + y);

        bool f1 = true;
        bool f2 = false;
        Console.WriteLine("До: f1 = " + f1 + ", f2 = " + f2);
        Swap(ref f1, ref f2);
        Console.WriteLine("После: f1 = " + f1 + ", f2 = " + f2);

        Console.WriteLine();
        Console.WriteLine("2. Обобщенный класс LinkedList<T>");

        LinkedList<string> stringList = new LinkedList<string>();
        stringList.Add("one");
        stringList.Add("two");
        stringList.Add("three");

        Console.WriteLine("Список string содержит \"two\": " + stringList.Contains("two"));
        stringList.Remove("two");
        Console.WriteLine("После удаления \"two\": " + stringList.Contains("two"));

        LinkedList<Person> personList = new LinkedList<Person>();
        Person person1 = new Person("Иван", 20);
        Person person2 = new Person("Анна", 22);

        personList.Add(person1);
        personList.Add(person2);

        Console.WriteLine("Список Person содержит Анну: " + personList.Contains(person2));
        personList.Remove(person1);
        Console.WriteLine("После удаления Ивана: " + personList.Contains(person1));

        LinkedList<Book> bookList = new LinkedList<Book>();
        Book book1 = new Book("Война и мир", "Толстой");
        Book book2 = new Book("Преступление и наказание", "Достоевский");

        bookList.Add(book1);
        bookList.Add(book2);

        Console.WriteLine("Список Book содержит \"Война и мир\": " + bookList.Contains(book1));
        bookList.Remove(book2);
        Console.WriteLine("После удаления второй книги: " + bookList.Contains(book2));

        Console.WriteLine();
        Console.WriteLine("3. Обобщенный интерфейс IPrintable<T>");

        IPrintable<Student> student = new Student("Павел", 19, 4.7);
        IPrintable<Vector> vector = new Vector(3, 4, 5);

        student.Print();
        vector.Print();

        Console.ReadLine();
    }

    static void Swap<T>(ref T x, ref T y) where T : struct
    {
        T temp = x;
        x = y;
        y = temp;
    }
}

class Node<T> where T : class
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList<T> where T : class
{
    private Node<T> head;

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node<T> current = head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public void Remove(T item)
    {
        if (head == null)
            return;

        if (object.Equals(head.Data, item))
        {
            head = head.Next;
            return;
        }

        Node<T> current = head;

        while (current.Next != null)
        {
            if (object.Equals(current.Next.Data, item))
            {
                current.Next = current.Next.Next;
                return;
            }

            current = current.Next;
        }
    }

    public bool Contains(T item)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (object.Equals(current.Data, item))
                return true;

            current = current.Next;
        }

        return false;
    }
}

class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Book
{
    public string Title;
    public string Author;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

interface IPrintable<T> where T : notnull
{
    void Print();
}

class Student : IPrintable<Student>
{
    public string Name;
    public int Age;
    public double Grade;

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public void Print()
    {
        Console.WriteLine("Student: " + Name + ", возраст: " + Age + ", оценка: " + Grade);
    }
}

struct Vector : IPrintable<Vector>
{
    public int X;
    public int Y;
    public int Z;

    public Vector(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public void Print()
    {
        Console.WriteLine("Vector: X = " + X + ", Y = " + Y + ", Z = " + Z);
    }
}