using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BHFunctioning.Data;
using BHFunctioning.Models;

namespace BHFunctioning.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _db = db;
            _userManager = userManager;
        }
        //Main page of role management, displays all roles
        [HttpGet]
        public IActionResult ListAllRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRoles()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoles(Role roleObj)
        {
            //System.Diagnostics.Debug.WriteLine("Rolename: " + roleObj.Name);
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new();
                identityRole.Name = roleObj.Name;
                identityRole.NormalizedName = roleObj.Name;

                var result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListAllRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
                return View(roleObj);
        }
        [HttpGet]
        public async Task<IActionResult> EditRoleAsync(string id)
        {
            var roleDb = await _roleManager.FindByIdAsync(id);
            
            EditRoleModel model = new();
            model.Id = roleDb.Id.ToString();
            model.Name = roleDb.Name;
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, model.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult EditRole(Role id)
        {
            var roleDb = _roleManager.FindByIdAsync(id.Id.ToString());
            if (roleDb == null)
            {
                ViewData["ErrorMessage"] = $"No role with Id '{id.Id}' was found";
                return View("Error");
            }
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbFirst = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (roleDb == null)
            {
                return NotFound();
            }
            return View(roleDb);
        }

    }
}
