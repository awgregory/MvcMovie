using System;
using System.ComponentModel.DataAnnotations; //DataAnnotations provides a built-in set of  validation attributes that you can apply declaratively to any class or property.  
using System.Data.Entity;                   // (It also contains formatting attributes like DataType that help with formatting and don't provide any validation.)


namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]// String length validation attribute
        public string Title { get; set; }
        
        [Display(Name = "Release Date"),DataType(DataType.Date)] // Example of combining attributes on one line
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")] // @=verbatum strings, ^=at start of line, [A-Z]= cap letter, + = match previous element 1 or more times 
        [Required]                                      // [a-zA-Z''-'\s]=letter, or whitespace     
        [StringLength(30)]                              // * = match previous element 0 or more times, $ = before end of line or \n
        public string Genre { get; set; }

        [Range(1, 100)] // Range validation attribute
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }

}





// How to specify which database MovieDBContext will connect to?
// EF will default to using LocalDB.  It runs in a special mode that allows you to work with databases as .mdf files typically kept in App_Data folder (click show all files)


// LocalDB is installed by default with VS 2012 and 2013


//each instance of a Movie object will correspond to a row within a database table, and each property of the Movie class will map to a column in the table.