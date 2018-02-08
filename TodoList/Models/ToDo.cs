using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a new task")]
        [StringLength(100)]
        [Display(Name = "Task Description")]
        public string description { get; set; }

        [Display(Name = "Is Done")]
        public bool IsDone { get; set; }
        

    }
}