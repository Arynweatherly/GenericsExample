using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var allMovies = new List<DVD>
            {
                new DVD { Id = 1, Title = "Out in the Dark", Genre = "Drama|Romance"},
                new DVD { Id = 2, Title = "Zapped!", Genre = "Comedy|Sci-Fi"},
                new DVD { Id = 3, Title = "Neighbours", Genre = "Comedy"},
                new DVD { Id = 4, Title = "Thing, The", Genre = "Action|Horror|Sci-Fi|Thriller"},
                new DVD { Id = 5, Title = "Around the Block", Genre = "Drama"},
                new DVD { Id = 6, Title = "Corto Maltese: Under the Sign of Capricorn (Sous le signe du capricorne)", Genre = "Animation|Drama|Romance|War"},
                new DVD { Id = 7, Title = "Warlock: The Armageddon", Genre = "Horror"},
                new DVD { Id = 8, Title = "Nico and Dani", Genre = "Comedy|Drama|Romance"},
                new DVD { Id = 9, Title = "What Doesn't Kill You", Genre = "Crime|Drama"},
                new DVD { Id = 10, Title = "Reap the Wild Wind", Genre = "Action|Adventure|Drama"},
                new DVD { Id = 11, Title = "Last Days Here", Genre = "Documentary"},
                new DVD { Id = 12, Title = "Parental Guidance", Genre = "Comedy"},
                new DVD { Id = 13, Title = "Saving Shiloh", Genre = "Children|Drama"},
                new DVD { Id = 14, Title = "Moonshot", Genre = "Drama"},
                new DVD { Id = 15, Title = "Kadosh", Genre = "Drama"},
                new DVD { Id = 16, Title = "Stanley Kubrick: A Life in Pictures", Genre = "Documentary"},
                new DVD { Id = 17, Title = "Clown and the Kid, The", Genre = "Drama"},
                new DVD { Id = 18, Title = "Confetti", Genre = "Comedy"},
                new DVD { Id = 19, Title = "Setup (Set Up)", Genre = "Action|Crime|Drama"},
                new DVD { Id = 20, Title = "Captain Video: Master of the Stratosphere", Genre = "Adventure|Sci-Fi"},
                new DVD { Id = 21, Title = "Underworld: Evolution", Genre = "Action|Fantasy|Horror"},
                new DVD { Id = 22, Title = "Nothing Left to Fear", Genre = "Horror"},
                new DVD { Id = 23, Title = "Shanghai Gesture, The", Genre = "Drama|Film-Noir"},
                new DVD { Id = 24, Title = "In My Father's Den", Genre = "Drama"},
                new DVD { Id = 25, Title = "Scapegoat, The", Genre = "Drama"},
                new DVD { Id = 26, Title = "None But the Lonely Heart", Genre = "Drama|Romance"},
                new DVD { Id = 27, Title = "Cameron's Closet", Genre = "Horror"},
                new DVD { Id = 28, Title = "Inferno", Genre = "Drama"},
                new DVD { Id = 29, Title = "Splatter University", Genre = "Horror"},
                new DVD { Id = 30, Title = "Flash Point", Genre = "Action"}

           };

            var allBooks = new List<Book>
            {
                new Book { Id = 1, Author = "Chinua Achebe", Title = "Things Fall Apart" },
                new Book { Id = 2, Author = "Hans Christian Andersen", Title = "Fairy tales" },
                new Book { Id = 3, Author = "Dante Alighieri", Title = "The Divine Comedy" },
                new Book { Id = 4, Author = "Unknown", Title = "The Epic Of Gilgamesh" },
                new Book { Id = 5, Author = "Unknown", Title = "The Book Of Job" },
                new Book { Id = 6, Author = "Unknown", Title = "One Thousand and One Nights" },
                new Book { Id = 7, Author = "Geoffrey Chaucer", Title = "The Canterbury Tales" },
                new Book { Id = 8, Author = "Jane Austen", Title = "Pride and Prejudice" },
                new Book { Id = 9, Author = "Miguel de Cervantes", Title = "Don Quijote De La Mancha" },
                new Book { Id = 10, Author = "Samuel Beckett", Title = "Molloy, Malone Dies, The Unnamable, the trilogy" },
                new Book { Id = 11, Author = "Giovanni Boccaccio", Title = "The Decameron" },
                new Book { Id = 12, Author = "Jorge Luis Borges", Title = "Ficciones" },
                new Book { Id = 13, Author = "Emily Bronte", Title = "Wuthering Heights" },
                new Book { Id = 14, Author = "Albert Camus", Title = "The Stranger" },
                new Book { Id = 15, Author = "Knut Hamsun", Title = "Hunger" },
                new Book { Id = 16, Author = "Ernest Hemingway", Title = "The Old Man and the Sea" },
                new Book { Id = 17, Author = "Homer", Title = "Iliad" },
                new Book { Id = 18, Author = "Homer", Title = "Odyssey" },
                new Book { Id = 19, Author = "Henrik Ibsen", Title = "A Doll's House" },
                new Book { Id = 20, Author = "James Joyce", Title = "Ulysses" },
                new Book { Id = 21, Author = "Franz Kafka", Title = "Stories" },
            };

            //create new pager of type book

            var bookPager = new Pager<Book>(allBooks);
            var dvdPager = new Pager<DVD>(allMovies);


            Console.WriteLine("Which listings would you like to see?");
            Console.WriteLine("1. Movies");
            Console.WriteLine("2. Books");

            var selection = Console.ReadLine();

            if (selection == "1")
            {

                var firstPage = dvdPager.GetCurrentPage();
                firstPage.ForEach(m => Console.WriteLine($"{m.Id}: {m.Title} - {m.Genre}"));

                while (true)
                {
                    Console.WriteLine("Type Next or Prev to go forward or back");
                    var forwardOrBack = Console.ReadLine();
                    Console.Clear();

                    if (forwardOrBack == "Next") //if say next we get next page and it prints them out
                    {
                        var nextPage = dvdPager.GetNextPage();
                        nextPage.ForEach(m => Console.WriteLine($"{m.Id}: {m.Title} - {m.Genre}"));
                    }
                    else if (forwardOrBack == "Prev")// same thing for previous
                    {
                        var previousPage = dvdPager.GetPreviousPage();
                        previousPage.ForEach(m => Console.WriteLine($"{m.Id}: {m.Title} - {m.Genre}"));
                    }
                    else
                    {
                        break; //how we exit the loop
                    }
                }
            }

            if (selection == "2")
            {
                var firstPage = bookPager.GetCurrentPage();
                firstPage.ForEach(b => Console.WriteLine($"{b.Id}: {b.Title} by {b.Author}"));

                while (true)
                {
                    Console.WriteLine("Type Next or Prev to go forward or back");
                    var forwardOrBack = Console.ReadLine();
                    Console.Clear();

                    if (forwardOrBack == "Next") //if say next we get next page and it prints them out
                    {
                        var nextPage = bookPager.GetNextPage();
                        nextPage.ForEach(b => Console.WriteLine($"{b.Id}: {b.Title} by {b.Author}"));
                    }
                    else if (forwardOrBack == "Prev")// same thing for previous
                    {
                        var previousPage = bookPager.GetPreviousPage();
                        previousPage.ForEach(b => Console.WriteLine($"{b.Id}: {b.Title} by {b.Author}"));
                    }
                    else
                    {
                        break; //how we exit the loop
                    }
                }
            }
        }
    }
}
