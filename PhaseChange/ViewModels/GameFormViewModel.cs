using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhaseChange.Models;
using System.ComponentModel.DataAnnotations;

namespace PhaseChange.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Genre")]
        [Required]
        public byte? GenreId { get; set; }  //Genre completley removed because it is captured in form now with id

        [Display(Name="Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name="Number in stock")]
        [Required]
        [Range(1,20)]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie"; //If id not 0, return edit game, otherwise return new game
            }
        }

        public GameFormViewModel()
        {
            Id = 0;
        }

        public GameFormViewModel(Game game) //Constructor to pass values to controller
        {
            Id = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            NumberInStock = game.NumberInStock;
            GenreId = game.GenreId;
        }


    }
}