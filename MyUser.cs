using System;
using Microsoft.AspNetCore.Identity;

public class MyUser : IdentityUser
{
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string address2 { get; set; }
    public string other_email { get; set; }
    public string affiliation { get; set; }
    public string postcode { get; set; }
    public string region { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string pdfFile{get;set;}
    public string volunteer { get; set; }
    public string conference { get; set; }
    public string field_of_interest { get; set; }
}