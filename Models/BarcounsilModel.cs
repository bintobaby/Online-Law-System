using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MVCBarcounsil.Models
{
    public class BarcounsilModel
    {
    }

    public class login
    {
        public int lid { get; set; }
          public string type{ get; set; }
          [DisplayName("User Name")]
          [Required(ErrorMessage = "Enter Username")]
          public string username { get; set; }
          [DisplayName("Password")]
          [Required(ErrorMessage = "Enter Password")]
          public string password { get; set; }
          public string status { get; set; }
          public string message { get; set; }


          public DataTable dt { get; set; }


          

    }

    public class clientsinfo
    {

         public int clid{ get; set; }
         [DisplayName("Name")]
        [Required(ErrorMessage = "Your must provide Name")]
         public string name { get; set; }
         
         [Required(ErrorMessage = "Your must provide Date Of Birth")]
         [DisplayName("Date Of Birth")]
         public string dob { get; set; }
          [DisplayName("Address")]
         public string address { get; set; }
         [Required(ErrorMessage = "Your must provide a MobileNumber")]
         [DisplayName("Mobile")]
         [DataType(DataType.PhoneNumber)]
         [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
         public string mobile { get; set; }
         [Required(ErrorMessage = "Your must provide a Landline Number")]
         [DisplayName("Landline")]
         [DataType(DataType.PhoneNumber)]
         [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
         public string landline { get; set; }
         [Required(ErrorMessage = "Your must provide a email address")]
         [DisplayName("Email")]
       
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
         public string email { get; set; }
         public string inpath { get; set; }
         public string outpath { get; set; }
         public string datereg { get; set; }
         [Required]
         [Remote("doesUserNameExist", "Site", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
         [DisplayName("Username")]
         public string UserName { get; set; }
        [Required(ErrorMessage = "Your must provide Password")]
         public string passsword { get; set; }
         public string status { get; set; }
        [DisplayName("ID Proof")]
         [Required(ErrorMessage = "Your must provide An Id Proof")]
         public string files { get; set; }
         public DataTable dt;
        
    }

    public class advinfo
    {


      
         public int Advid { get; set; }
         [DisplayName("Name")]
         [Required(ErrorMessage = "Your must provide Name")]
         public string  name { get; set; }

         [DisplayName("Address")]
         [Required(ErrorMessage = "Your must provide Address")]
         public string address { get; set; }
        [DisplayName("District")]
        [Required(ErrorMessage = "Your must provide District")]
        public string district { get; set; }

        [DisplayName("Mobile")]
         [DataType(DataType.PhoneNumber)]
         [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
         [Required(ErrorMessage = "Your must provide Mobile Number")]

         public string mobile { get; set; }

         [DisplayName("Qualification")]
         [Required(ErrorMessage = "Your must provide Qualification")]
         public string qualification { get; set; }

         [DisplayName("Bar Counsil Number")]
         [Required(ErrorMessage = "Your must provide Bar Counsil Number")]
         public string barcounsilno { get; set; }

         [DisplayName("Specilization")]
         [Required(ErrorMessage = "Your must provide Specilization")]
         public string specilization { get; set; }

         [DisplayName("Practice Area")]
         [Required(ErrorMessage = "Your must provide Name")]
         public string practicearea { get; set; }
         [DisplayName("Court")]
         [Required(ErrorMessage = "Your must provide Court")]

         public string court { get; set; }
         [MaxLength(10)]

         [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid")]
         [DisplayName("Fees")]
         [Required(ErrorMessage = "Your must provide Fees")]

         public string fees { get; set; }

         
         public string status { get; set; }

        
         public string photo { get; set; }
         [DisplayName("Username")]
         [Required(ErrorMessage = "Your must provide Username")]
         [Remote("doesUserNameExist", "Admin", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
         public string UserName { get; set; }
         [DisplayName("Password")]
         [Required(ErrorMessage = "Your must provide Password")]
         public string pass { get; set; }

         public DataTable dt { get; set; }
         [DisplayName("Photo")]
         public string files { get; set; }
        
        

    }

    public class caseinfo
    {
        public string caseid { get; set; }
        [DisplayName("Description")]
         public string clientid { get; set; }
        
         public string clientname { get; set; }
         public string advid { get; set; }
        [DisplayName("Advocate Name")]
         public string advname { get; set; }
        [DisplayName("Specilization")]
         public string category { get; set; }
         
         [DisplayName("Court")]
         [Required(ErrorMessage = "Court Name Required")]
         public string court { get; set; }
        
         [DisplayName("Description")]
         [Required(ErrorMessage = "Enter Description")]
         public string description { get; set; }
         public string fee { get; set; }
         public string date { get; set; }
         public string status { get; set; }
         public string cstatus { get; set; }
         public string feestatus { get; set; }
         public string cliimg { get; set; }

         public string advimg { get; set; }

         public DataTable dt { get; set; }
         [DisplayName("Status")]
         [Required(ErrorMessage = "Select Status")]
         public string casestst { get; set; }

        [DisplayName("File")]
        public string files { get; set; }


    }

    public class caseupdates
    {
            public string updid { get; set; }
            public string caseid { get; set; }
            public string timestap { get; set; }
            [DisplayName("Description")]
            [Required(ErrorMessage = "Enter Description")]
            public string description { get; set; }
            public DataTable dt{ get; set; }
           
    }

    public class casefiles
    {
         public string upid { get; set; }
         public string caseid { get; set; }
         public string path { get; set; }
         [DisplayName("Description")]
         [Required(ErrorMessage = "Enter Description")]
         public string descri { get; set; }
         [DisplayName("File")]
         [Required(ErrorMessage = "Select File")]
         public string files { get; set; }
         public DataTable dt { get; set; }
      
    }

    public class notif
    {
         public string NotId { get; set; }
          public string clid { get; set; }
          public string msg { get; set; }
          public string status { get; set; }
          public DataTable dt { get; set; }
      
    }

    public class communi
    {

           public string comid { get; set; }
          public string caseid { get; set; }
          public string timestamp { get; set; }
          public string fromuser { get; set; }
          [DisplayName("Description")]
          [Required(ErrorMessage = "Please Enter message")]
          public string message { get; set; }
        
          public DataTable dt { get; set; }
      

    }

    public class uppointments
    {


        public string apoid { get; set; }
        public string pid { get; set; }
        public string pname { get; set; }
        public string did { get; set; }
        public string dname { get; set; }
        [DisplayName("Date")]
        [Required(ErrorMessage = "Please Enter Date")]
        public string dateshow { get; set; }
        public string date { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "Please Enter Description")]
        public string descri { get; set; }
        public string status { get; set; }

        public DataTable dt { get; set; }

    }

    public class gettable
    {
        public DataTable dt { get; set; }
    }

    public class discinfo
    {
        public string disid { get; set; }
        public string frid { get; set; }
        public string frname { get; set; }
        public string toid { get; set; }
        public string toname { get; set; }
        public string timestamp { get; set; }
        [DisplayName("Query")]
        [Required(ErrorMessage = "Please Enter Query")]
        public string message { get; set; }
        public DataTable dt { get; set; }

    }
    public class search
    {
        [DisplayName("Section Number or Keyword")]
        [Required(ErrorMessage = "Please Enter Section Number or Keyword")]
        public string sno{ get; set; }
        public string description { get; set; }
        public DataTable dt { get; set; }

    }

}