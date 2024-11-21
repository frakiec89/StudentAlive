namespace StudentAlive
{
    public class BooksShop
    {
        public List<Book> Books {  get; private set; }
        
        public BooksShop ()
        {
            Books = new List<Book>()
            {
                new Book { Name="C# для Junior" , PoinstDay = 4 , Price = 200 , ExperiencePoint =2 },
                new Book { Name="C# для Middle" , PoinstDay = 100 , Price = 2000 , ExperiencePoint =4 },
                new Book { Name="C# для Senior" , PoinstDay = 100 , Price = 4000 , ExperiencePoint =6 },
                new Book { Name="C# для Lead" , PoinstDay = 100 , Price = 5000 , ExperiencePoint =7 },
            };
        }

        /// <summary>
        /// купить книгу , кто  и  какую книгу
        /// </summary>
        /// <param name="student"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public string Buy (Student student  , string  bookName)
        {
            Book book = GetBook(bookName);

            if (book == null)
                return "Книга не найдена";


            if (student.Money <  book.Price)
            {
                student.Money -= 5;
                return "у вас не хватает денег на  покупку этой книги(";
            }

            if (student.IsBook(book) == true )
                return "У вас уже есть  такая  книга";

            student.Money -= book.Price;
            student.BooksStudent.Add(book);
            student.Money += 5;

            return $"Вы купили книгу {book.Name}- ура !!!";
        }

        public string PrintInfo()
        {
            string s = "Список книг в  магазине:\n";
          
            foreach (var item in Books)
            {
                s += $"{item.Name}, цена={item.Price}, объем = {item.ExperienceTotal} ст.\n";
            }
            return  s;
        }

        private Book GetBook (string bookName)
        {
            foreach (Book b in Books)
            {
                if(b.Name == bookName)
                    return b;
            }
            return null;
        }
    }
}