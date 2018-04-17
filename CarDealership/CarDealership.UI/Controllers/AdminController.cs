using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        private SpecialManager _specialManager;
        private ListingManager _listingManager;
        private MakeManager _makeManager;
        private ModelManager _modelManager;
        private ExteriorColorManager _exteriorColorManager;
        private InteriorColorManager _interiorColorManager;
        private BodyStyleManager _bodyStyleManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ActionResult Admin()
        {
            //menu 
            return View();
        }

        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            _makeManager = MakeManagerFactory.Create();
            _modelManager = ModelManagerFactory.Create();
            _interiorColorManager = InteriorColorManagerFactory.Create();
            _exteriorColorManager = ExteriorColorManagerFactory.Create();
            _bodyStyleManager = BodyStyleManagerFactory.Create();

            try
            {
                var model = new AddListingVM();

                //load all the items 
                var modelResponse = _modelManager.GetAllModels();
                var makeResponse = _makeManager.GetAllMakes();
                var interiorResponse = _interiorColorManager.GetAll();
                var exteriorReponse = _exteriorColorManager.GetAll();
                var bodyResponse = _bodyStyleManager.GetAll();

                //verify they all loaded
                if (!modelResponse.Success 
                    || !makeResponse.Success
                    || !interiorResponse.Success
                    || !exteriorReponse.Success
                    || !bodyResponse.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:" +
                        $"{modelResponse.Message} " +
                        $"{makeResponse.Message}" +
                        $"{interiorResponse.Message}" +
                        $"{exteriorReponse.Message}" +
                        $"{bodyResponse.Message}");
                }
                else
                {
                    //create select list items 
                    model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.MakeName,
                        Value = m.MakeId.ToString()
                    });

                    model.Models = modelResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.ModelName,
                        Value = m.ModelId.ToString()
                    });

                    model.ExteriorColors = exteriorReponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.ExteriorColorName,
                        Value = m.ExteriorColorId.ToString()
                    });

                    model.InteriorColors = interiorResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.InteriorColorName,
                        Value = m.InteriorColorId.ToString()
                    });

                    model.BodyStyles = bodyResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.BodyStyleName,
                        Value = m.BodyStyleId.ToString()
                    });

                    return View(model);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something wrong happened loading the add screen:", ex);
            }
        }

        [HttpPost]
        public ActionResult AddVehicle(AddListingVM model)
        {
            _listingManager = ListingManagerFactory.Create();

            if (ModelState.IsValid)
            {
                try
                {
                    model.Listing.DateAdded = DateTime.Now;

                    if(model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images/");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Listing.ImageFileUrl = Path.GetFileName(filePath);
                    }


                    //send to manager and repo 
                    var listingResponse = _listingManager.SaveListing(model.Listing);

                    if (listingResponse.Success)
                    {
                        return RedirectToAction("EditVehicle", new { id = listingResponse.Payload.ListingId });
                    }
                    else
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:" +
                       $"{listingResponse.Message}");
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Something wrong happened while trying to add a new listing:", ex);
                }
            }
            else
            {
                //reset page with items 
                _makeManager = MakeManagerFactory.Create();
                _modelManager = ModelManagerFactory.Create();
                _interiorColorManager = InteriorColorManagerFactory.Create();
                _exteriorColorManager = ExteriorColorManagerFactory.Create();
                _bodyStyleManager = BodyStyleManagerFactory.Create();

                //load all the items 
                var modelResponse = _modelManager.GetAllModels();
                var makeResponse = _makeManager.GetAllMakes();
                var interiorResponse = _interiorColorManager.GetAll();
                var exteriorReponse = _exteriorColorManager.GetAll();
                var bodyResponse = _bodyStyleManager.GetAll();

                //verify they all loaded
                if (!modelResponse.Success
                    || !makeResponse.Success
                    || !interiorResponse.Success
                    || !exteriorReponse.Success
                    || !bodyResponse.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:" +
                        $"{modelResponse.Message} " +
                        $"{makeResponse.Message}" +
                        $"{interiorResponse.Message}" +
                        $"{exteriorReponse.Message}" +
                        $"{bodyResponse.Message}");
                }
                else
                {
                    //create select list items 
                    model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.MakeName,
                        Value = m.MakeId.ToString()
                    });

                    model.Models = modelResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.ModelName,
                        Value = m.ModelId.ToString()
                    });

                    model.ExteriorColors = exteriorReponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.ExteriorColorName,
                        Value = m.ExteriorColorId.ToString()
                    });

                    model.InteriorColors = interiorResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.InteriorColorName,
                        Value = m.InteriorColorId.ToString()
                    });

                    model.BodyStyles = bodyResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.BodyStyleName,
                        Value = m.BodyStyleId.ToString()
                    });

                    return View(model);
                }
            }
        }

        public ActionResult EditVehicle(int id)
        {
            var model = new EditListingVM();

            //reset page with items 
            _makeManager = MakeManagerFactory.Create();
            _modelManager = ModelManagerFactory.Create();
            _interiorColorManager = InteriorColorManagerFactory.Create();
            _exteriorColorManager = ExteriorColorManagerFactory.Create();
            _bodyStyleManager = BodyStyleManagerFactory.Create();
            _listingManager = ListingManagerFactory.Create();

            //load all the items 
            var modelResponse = _modelManager.GetAllModels();
            var makeResponse = _makeManager.GetAllMakes();
            var interiorResponse = _interiorColorManager.GetAll();
            var exteriorReponse = _exteriorColorManager.GetAll();
            var bodyResponse = _bodyStyleManager.GetAll();

            //get listing
            var listingResponse = _listingManager.GetListingById(id);


            //verify they all loaded
            if (!modelResponse.Success
                || !makeResponse.Success
                || !interiorResponse.Success
                || !exteriorReponse.Success
                || !bodyResponse.Success
                || !listingResponse.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:" +
                    $"{modelResponse.Message} " +
                    $"{makeResponse.Message}" +
                    $"{interiorResponse.Message}" +
                    $"{exteriorReponse.Message}" +
                    $"{bodyResponse.Message}" +
                    $"{listingResponse.Message}");
            }
            else
            {
                //create select list items 
                model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                });

                model.Models = modelResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.ModelName,
                    Value = m.ModelId.ToString()
                });

                model.ExteriorColors = exteriorReponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.ExteriorColorName,
                    Value = m.ExteriorColorId.ToString()
                });

                model.InteriorColors = interiorResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.InteriorColorName,
                    Value = m.InteriorColorId.ToString()
                });

                model.BodyStyles = bodyResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.BodyStyleName,
                    Value = m.BodyStyleId.ToString()
                });

                model.Listing = listingResponse.Payload;

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult EditVehicle(EditListingVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _listingManager = ListingManagerFactory.Create();

                    var oldListingResponse = _listingManager.GetListingById(model.Listing.ListingId);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images/");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Listing.ImageFileUrl = Path.GetFileName(filePath);

                        //delete the old file, use the response to get it
                        var oldPath = Path.Combine(savepath, oldListingResponse.Payload.ImageFileUrl);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        model.Listing.ImageFileUrl = oldListingResponse.Payload.ImageFileUrl;
                    }

                    var listingResponse = _listingManager.UpdateListing(model.Listing);

                    if (listingResponse.Success)
                    {
                        return RedirectToAction("Vehicles");
                        //return RedirectToAction("EditVehicle", new { id = listingResponse.Payload.ListingId });
                    }
                    else
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:" +
                       $"{listingResponse.Message}");
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Something wrong happened while trying to edit a listing:", ex);
                }

            }
            else
            {
                //reset page with items 
                _makeManager = MakeManagerFactory.Create();
                _modelManager = ModelManagerFactory.Create();
                _interiorColorManager = InteriorColorManagerFactory.Create();
                _exteriorColorManager = ExteriorColorManagerFactory.Create();
                _bodyStyleManager = BodyStyleManagerFactory.Create();
                _listingManager = ListingManagerFactory.Create();

                //load all the items 
                var modelResponse = _modelManager.GetAllModels();
                var makeResponse = _makeManager.GetAllMakes();
                var interiorResponse = _interiorColorManager.GetAll();
                var exteriorReponse = _exteriorColorManager.GetAll();
                var bodyResponse = _bodyStyleManager.GetAll();

                //verify they all loaded
                if (!modelResponse.Success
                    || !makeResponse.Success
                    || !interiorResponse.Success
                    || !exteriorReponse.Success
                    || !bodyResponse.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:" +
                        $"{modelResponse.Message} " +
                        $"{makeResponse.Message}" +
                        $"{interiorResponse.Message}" +
                        $"{exteriorReponse.Message}" +
                        $"{bodyResponse.Message}");
                }
                else
                {
                    //create select list items 
                    model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.MakeName,
                        Value = m.MakeId.ToString()
                    });

                    model.Models = modelResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.ModelName,
                        Value = m.ModelId.ToString()
                    });

                    model.ExteriorColors = exteriorReponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.ExteriorColorName,
                        Value = m.ExteriorColorId.ToString()
                    });

                    model.InteriorColors = interiorResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.InteriorColorName,
                        Value = m.InteriorColorId.ToString()
                    });

                    model.BodyStyles = bodyResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.BodyStyleName,
                        Value = m.BodyStyleId.ToString()
                    });

                    return View(model);
                }
            }
        }



        [HttpGet]
        public ActionResult DeleteListing(int listingId)
        {
            _listingManager = ListingManagerFactory.Create();

            var response = _listingManager.DeleteListing(listingId);

            if (response.Success)
            {
                return RedirectToAction("Vehicles");
            }
            else
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }
        }

        public ActionResult Specials()
        {
            _specialManager = SpecialManagerFactory.Create();
            var model = new AdminSpecialVM();
            var response = _specialManager.GetAllSpecials();

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }
            else
            {
                model.SetSpecialItems(response.Specials);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Specials(AdminSpecialVM model)
        {
            _specialManager = SpecialManagerFactory.Create();

            if (ModelState.IsValid)
            {
                try
                {
                    var response = _specialManager.SaveSpecial(model.Special);

                    if (!response.Success)
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var response = _specialManager.GetAllSpecials();
                model.SetSpecialItems(response.Specials);

                return View(model);
            }

            return RedirectToAction("Specials");
        }

        public ActionResult DeleteSpecial(int id)
        {
            _specialManager = SpecialManagerFactory.Create();

            var response = _specialManager.DeleteSpecial(id);

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }

            return RedirectToAction("Specials");
        }

        public ActionResult Models()
        {
            _modelManager = ModelManagerFactory.Create();
            _makeManager = MakeManagerFactory.Create();

            var model = new ModelsVM();
            var modelResponse = _modelManager.GetAllModels();
            var makeResponse = _makeManager.GetAllMakes();

            if (!modelResponse.Success || !makeResponse.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{modelResponse.Message} {makeResponse.Message}");
            }
            else
            {
                model.SetModelItems(modelResponse.Payload);

                model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                });

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Models(ModelsVM model)
        {
            _modelManager = ModelManagerFactory.Create();
            _makeManager = MakeManagerFactory.Create();

            if (ModelState.IsValid)
            {
                model.NewModel.DateAdded = DateTime.Now;
                model.NewModel.UserName = User.Identity.Name;

                //save 
                var response = _modelManager.SaveModel(model.NewModel);

                //throw error for non success
                if (!response.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                }

                return RedirectToAction("Models");
            }
            else
            {
                var modelResponse = _modelManager.GetAllModels();
                var makeResponse = _makeManager.GetAllMakes();
                model.SetModelItems(modelResponse.Payload);

                model.Makes = makeResponse.Payload.Select(m => new SelectListItem
                {
                    Text = m.MakeName,
                    Value = m.MakeId.ToString()
                });

                return View(model);
            }

        }

        public ActionResult Makes()
        {
            _makeManager = MakeManagerFactory.Create();
            var model = new MakesVM();
            var response = _makeManager.GetAllMakes();

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }
            else
            {
                model.SetMakeItems(response.Payload);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Makes(MakesVM model)
        {
            _makeManager = MakeManagerFactory.Create();

            if (ModelState.IsValid)
            {
                try
                {

                    model.NewMake.DateAdded = DateTime.Now;
                    model.NewMake.UserName = User.Identity.Name;

                    var response = _makeManager.SaveMake(model.NewMake);

                    if (!response.Success)
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                    }

                    return RedirectToAction("Makes");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var response = _makeManager.GetAllMakes();
                model.SetMakeItems(response.Payload);

                return View(model);
            }
        }

        public ActionResult Users()
        {
            var users = UserManager.Users.ToList();
            var model = users.Select(s => new UserVM
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                UserName = s.UserName,
                Role = UserManager.GetRoles(s.Id).FirstOrDefault()
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var context = new CarDealershipDbContext();
            var roles = context.Roles;
            var model = new RegisterViewModel();

            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            //get the database context
            var context = new CarDealershipDbContext();

            if (ModelState.IsValid)
            {
                //get the user
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var result = await UserManager.CreateAsync(user, model.Password);

                //successfully got user
                if (result.Succeeded)
                {
                    //create a new role manager 
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    var role = roleManager.FindById(model.Role);
                    UserManager.AddToRole(user.Id, role.Name);

                    return RedirectToAction("Users", "Admin");
                }
                AddErrors(result);
            }

            var roles = context.Roles;

            //populate roles in model
            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var context = new CarDealershipDbContext();
            var roles = context.Roles.ToList();
            var editedUser = UserManager.FindById(id);
            var model = new RegisterViewModel();

            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            });

            model.Id = editedUser.Id;
            model.FirstName = editedUser.FirstName;
            model.LastName = editedUser.LastName;
            model.Email = editedUser.Email;

            foreach (var role in editedUser.Roles)
            {
                model.Role = role.RoleId;
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult EditUser(RegisterViewModel model)
        {
            //get user, roles
            var context = new CarDealershipDbContext();
            var roles = context.Roles;
            var user = UserManager.FindById(model.Id);

            //get the current role in the db
            var oldRole = user.Roles.SingleOrDefault().RoleId;

            if (!string.IsNullOrEmpty(model.EditedPassword))
            {
                user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.EditedPassword);
            }

            //edit user
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;

            if (!user.Roles.Any(r => r.RoleId == model.Role))
            {
                //clear all roles from the user
                var dbUser = context.Users.SingleOrDefault(u => u.Id == model.Id);
                dbUser.Roles.Clear();
                context.SaveChanges();

                //get new role from model, remove user from current role, add to new role
                var newRole = roles.Where(r => r.Id == model.Role).Select(r => r.Name).SingleOrDefault();
                UserManager.RemoveFromRole(user.Id, oldRole);
                UserManager.AddToRole(user.Id, newRole);
            }

            UserManager.Update(user);

            return RedirectToAction("Users", "Admin");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}