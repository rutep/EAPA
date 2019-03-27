using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;


namespace webApi.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<MyUser> _signInManager;
        private readonly UserManager<MyUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHostingEnvironment he;

        public RegisterModel(
            UserManager<MyUser> userManager,
            SignInManager<MyUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IHostingEnvironment e)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            he = e;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Required]
            [Display(Name = "Fyrst Name")]
            [StringLength(100, ErrorMessage = "fyrst name cannot be less that one letter", MinimumLength = 1)]
            public string fyrstName { get; set; }

            [Display(Name = "Middle name")]
            public string middleName { get; set; }

            [Required]
            [Display(Name = "Surname")]
            [StringLength(100, ErrorMessage = "Surname cannot be less that one letter", MinimumLength = 1)]
            public string surName { get; set; }

            [Required]
            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Other email")]
            public string other_email { get; set; }

            [Required]
            [Phone]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "phone")]
            public string phone { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string address { get; set; }

            [Display(Name = "Address2")]
            public string address2 { get; set; }

            [Display(Name = "Your Affiliation")]
            public string affiliation { get; set; }

            [Display(Name = "Postcode")]
            [DataType(DataType.PostalCode)]
            public string postcode { get; set; }

            [Display(Name = "Region")]
            public string region { get; set; }

            [Display(Name = "City")]
            public string city { get; set; }

            [Display(Name = "Country")]
            public string Country { get; set; }
            [Display(Name = "Pdf file")]
            public string pdfFile { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        [HttpPost("UploadPdf")]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new MyUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    firstName = Input.fyrstName,
                    middleName = Input.middleName,
                    lastName = Input.surName,
                    address = Input.address,
                    address2 = Input.address2,
                    affiliation = Input.affiliation,
                    postcode = Input.postcode,
                    region = Input.region,
                    city = Input.city,
                    country = Input.Country,
                };

                if (Input.Country != "none")
                {
                    IFormFile file = HttpContext.Request.Form.Files[0];
                    if (file.ContentType != "application/pdf")
                    {
                        ModelState.AddModelError(string.Empty, "File Extension Is Invalid - Only Upload PDF File");
                        return Page();
                    }
                    Random random = new System.Random();
                    int id = random.Next(0, 100000);
                    var fileName = Path.Combine(he.WebRootPath + "/images/usersPdf", id + file.FileName);
                    user.pdfFile = id + file.FileName;
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    //User has to chose a country

                    if (result.Succeeded)
                    {
                        if (HttpContext.Request.Form.Files.Count > 0)
                        {
                            // If we are successful, and the pdf exists. Create the pdf locally
                            using (var stream = new FileStream(fileName, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }

                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);
                        await _emailSender.SendEmailAsync(Input.Email, "Please confirm your email address",
                            $"Velcome " + Input.Email +
                            $"<br/>" +
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                        await _signInManager.SignInAsync(user, isPersistent: false);

                        await _userManager.AddToRoleAsync(user, "Member");
                        return LocalRedirect(returnUrl);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
                ModelState.AddModelError(string.Empty, "Choose a country");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
