using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PMPAdmin.Models;


namespace PMPAdmin.ViewModels
{
    public class ManageNewsCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter a new category name.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public Nullable<System.DateTime> TimeCreated { get; set; }

        public string AddedBy { get; set; }

        public IEnumerable<NewsCategory> NewsCategory { get; set; }

        public IEnumerable<AspNetUser> AspNetUser { get; set; }

        public IEnumerable<News> News { get; set; }
    }
}