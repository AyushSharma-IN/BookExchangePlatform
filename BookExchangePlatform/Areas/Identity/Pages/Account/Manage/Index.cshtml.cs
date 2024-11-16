using System.ComponentModel.DataAnnotations;
using BookExchangePlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookExchangePlatform.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            [Length(10, 10 , ErrorMessage = "10 Digit phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Full Name is Required")]
            [Display(Name = "Full Name")]
            [Length(1, 50)]
            public string FullName { get; set; }

            [Display(Name = "Favorite Genre")]
            [MaxLength(100)]
            public string FavoriteGenres {  get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FavoriteGenres = user.FavoriteGenres,
                FullName = user.FullName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            bool flag = false;
            if (Input.FullName != user.FullName)
            {
                user.FullName = Input.FullName;
                flag = true;
            }
            if (Input.FavoriteGenres != user.FavoriteGenres)
            { 
                user.FavoriteGenres = Input.FavoriteGenres;
                flag = true;
            }
            if (Input.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber = Input.PhoneNumber;
                flag = true;
            }
            if (flag)
            {
                var result = await _userManager.UpdateAsync(user);
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to update the profile.";
                    return RedirectToPage();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your Profile has been updated";
            return RedirectToPage();
        }
    }
}
