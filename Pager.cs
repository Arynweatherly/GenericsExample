using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericsExample
{
    //class can take a type parameter -> t is taco. its a variable for a type
    public class Pager<T>
    {

        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; } = 5;

        private List<T> _allRecords { get; set; }

        //for creating a new instructor type ctor

        public Pager(List<T> allRecords)
        {
            _allRecords = allRecords;
        }


        //give me results on current pg

        public List<T> GetCurrentPage()
        {
            var skipAmount = CurrentPage * RecordsPerPage;

            return _allRecords
            .Skip(skipAmount)
            .Take(RecordsPerPage)
            .ToList();
        }

        //give me result on previous page
        public List<T> GetPreviousPage()
        {
            CurrentPage--;//this is a decrement. Take one off of it
            return GetCurrentPage();
        }


        //get me results on next page 
        public List<T> GetNextPage()
        {
            CurrentPage++;
            return GetCurrentPage();
        }
    }
}