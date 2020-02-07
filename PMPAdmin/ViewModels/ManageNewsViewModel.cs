using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMPAdmin.Models;

namespace PMPAdmin.ViewModels
{
    public class ManageNewsViewModel
    {

        public IEnumerable<News> News { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a news type.")]
        [Display(Name = "News Type")]
        public string Type { get; set; }
        public IEnumerable<SelectListItem> NewsTypes { get; set; }

        [Required(ErrorMessage = "Please select a category from the list.")]
        [Display(Name = "News Category")]
        public string CategoryId { get; set; }
        public  IEnumerable<SelectListItem> NewsCategoryList { get; set; }

        [Required(ErrorMessage = "Please enter a title for this news.")]
        [Display(Name = "News Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please write the details of this news")]
        [Display(Name = "News Details")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }


        [Display(Name = "Image Path")]
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

        [Display(Name = "Video Path")]
        public string VideoPath { get; set; }

        [Required(ErrorMessage = "Select if news is trending or not")]
        [Display(Name = "Trending News?")]
        public string Trending { get; set; }

        public string Status { get; set; }

        public Nullable<System.DateTime> TimeCreated { get; set; }

        public Nullable<System.DateTime> TimeModified { get; set; }


        public Nullable<int> AddedById { get; set; }



        public bool IsActive { get; set; }
    }

}