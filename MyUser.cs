using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class MyUser : IdentityUser
{
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string address2 { get; set; }
    public string affiliation { get; set; }
    public string postcode { get; set; }
    public string region { get; set; }
    public string city { get; set; }
    public string country { get; set; } 
    
    //custom properties
}