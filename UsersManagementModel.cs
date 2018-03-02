using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SodetsoUsersManagement.Models
{
    public class UsersManagementModel
    {
    }
    public class AddUserModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        //Using Remote validation attribute
        [Remote("IsUserExists", "UsersManagement", HttpMethod = "POST", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Position { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password confirmation must match password.")]
        public string CPassword { get; set; }

        public byte[] Image { get; set; }

        public IEnumerable<GenderModel> sex { get; set; }
    }

    public class GenderModel
    {
        public string GenderID { get; set; }
        public string Description { get; set; }
    }

    public class UsersListModel
    {
        public string UserID { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public byte[] Image { get; set; }
        public string DateCreated { get; set; }
        public int IsActive { get; set; }
        public int IsArchived { get; set; }

        public string Operation { get; set; }
    }

    public class EditUserModel
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password confirmation must match password.")]
        public string CPassword { get; set; }
        public byte[] Image { get; set; }

        public IEnumerable<GenderModel> sex { get; set; }
    }
}