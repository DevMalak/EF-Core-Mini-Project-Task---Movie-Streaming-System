namespace project01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();

           
            if (!db.Categories.Any())
            {
                db.Categories.Add(new Category { Name = "Action" });
                db.SaveChanges();
            }
            int defaultCategoryId = db.Categories.First().Id;


            // ==================== [ 1.ADD ] ====================
            Console.WriteLine("=== 1. Add New Movie ===");
            Movie m1 = new Movie();

            Console.WriteLine("Please Enter Movie Title:");
            m1.Title = Console.ReadLine();

            Console.WriteLine("Please Enter Movie Description:");
            m1.Description = Console.ReadLine();

            Console.WriteLine("Please Enter Release Year:");
            m1.ReleaseYear = Convert.ToInt32(Console.ReadLine());

           
            m1.CategoryId = defaultCategoryId;

            db.Movies.Add(m1);
            db.SaveChanges();
            Console.WriteLine(" Movie Added Successfully!");
            Console.WriteLine("========================================\n");


            // ==================== [ 2.UPDATE ] ====================
            Console.WriteLine("=== 2. Edit Movie Title ===");
            Console.WriteLine("Please Enter Movie ID you want to edit:");
            int editId = Convert.ToInt32(Console.ReadLine());

          
            Movie m2 = db.Movies.Find(editId);

            if (m2 != null)
            {
                Console.WriteLine($"The Old Title is: {m2.Title}");
                Console.WriteLine("Please Enter New Title:");
                m2.Title = Console.ReadLine();

                db.SaveChanges();
                Console.WriteLine($"🔄 Movie Title Updated to: {m2.Title}");
            }
            else
            {
                Console.WriteLine("❌ Movie not found!");
            }
            Console.WriteLine("========================================\n");


            // ==================== [ 3.DELETE ] ====================
            Console.WriteLine("=== 3. Delete Movie ===");
            Console.WriteLine("Please Enter Movie ID you want to delete:");
            int deleteId = Convert.ToInt32(Console.ReadLine());

            Movie movieToDelete = db.Movies.Find(deleteId);

            if (movieToDelete != null)
            {
                db.Movies.Remove(movieToDelete);
                db.SaveChanges();
                Console.WriteLine(" Movie Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
            Console.WriteLine("========================================\n");


            // ==================== [ 4.GET ALL ] ====================
            Console.WriteLine("=== 4. Display All Movies ===");
            var allMovies = db.Movies.ToList();

            foreach (var item in allMovies)
            {
                Console.WriteLine($"ID: {item.Id} | Title: {item.Title} | Year: {item.ReleaseYear}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}