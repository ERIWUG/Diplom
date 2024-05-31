
using AppTest.Models;
using AppTest.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Dynamic;

namespace WEB.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Authorize]
        [HttpGet]
        [Route("/UserPage/{login:maxlength(99)}")]
        public async Task<IActionResult> UserPage(string login)
        {

            var c = await db.Users
                                .Where(c => c.Login == login)
                                .AsNoTracking().FirstAsync();

            ViewBag.MyUser = db.Users.Single(c => c.Login == User.Identity.Name);
            ViewBag.Owner = c;

            return View();
        }

        [Authorize]
        [Route("/AdminPanel/{login:maxlength(99)}/Role")]
        public IActionResult UserRole(string login)
        {
            UserEntity c = db.Users.AsNoTracking().Single(c => c.Login == login);
            var q = db.Roles.AsNoTracking().Select(c => c.Name).ToList();
            List<int> Help = new List<int>();
            bool flag;
            foreach (var l in q)
            {
                flag = false;

                foreach (var s in c.Roles)
                {
                    if (s.Name == l)
                    {
                        flag = true;
                        break;
                    }
                }


                if (flag)
                {
                    Help.Add(1);
                    flag = false;
                }
                else
                {
                    Help.Add(0);
                }
            }


            ViewBag.HelpInt = Help;
            ViewBag.MyUser = c;
            ViewBag.Roles = q;
            return View();
        }

        [HttpPost]
        [Route("/api/CreateNewUser")]
        public async Task<RedirectResult> CreateNewUser()
        {
            var UserRole = db.Roles.Single(c => c.Name == "User");
            UserEntity Us = new UserEntity
            {
                Login = Request.Form["LoginField"],
                Name = Request.Form["NameField"] == "" ? string.Empty : Request.Form["NameField"],
                Surname = Request.Form["SurnameField"] == "" ? string.Empty : Request.Form["SurnameField"],
                Age = Convert.ToInt16(Request.Form["AgeField"]),
                Country = Request.Form["CountryField"] == "" ? string.Empty : Request.Form["CountryField"],
                Town = Request.Form["TownField"] == "" ? string.Empty : Request.Form["TownField"],
                Password = Request.Form["PasswordField"] == "" ? string.Empty : Request.Form["PasswordField"],
                Email = Request.Form["EmailField"] == "" ? string.Empty : Request.Form["EmailField"],
                PhoneNumber = Request.Form["PhoneField"] == "" ? string.Empty : Request.Form["PhoneField"],
                Roles = new List<RoleEntity>() { UserRole }
            };
            Us.Page = new UserPageEntity() { User = Us };

            db.Users.Add(Us);

            db.SaveChanges();

            return Redirect("/Home/LoginPage");
        }

        [Authorize]
        [HttpPost]
        public RedirectResult AddFriend()
        {
            string User1ID = Request.Form["User1"];
            string USer2ID = Request.Form["User2"];

            UserEntity user1 = db.Users.Single(c => c.Login == User1ID);
            UserEntity user2 = db.Users.Single(c => c.Login == USer2ID);

            user1.Friends.Add(user2);
            db.SaveChanges();

            return Redirect($"/UserPage/{user2.Login}");
        }

        [Authorize]
        [HttpPost]
        public RedirectResult Unfriend()
        {
            string User1ID = Request.Form["User1"];
            string USer2ID = Request.Form["User2"];

            UserEntity user1 = db.Users.Single(c => c.Login == User1ID);
            UserEntity user2 = db.Users.Single(c => c.Login == USer2ID);

            user1.Friends.Remove(user2);
            db.SaveChanges();

            return Redirect($"/UserPage/{user2.Login}");
        }
       


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<RedirectResult> EditUser()
        {
            List<int> StateID = new List<int>();
            List<int> ChangeID = new List<int>();
            foreach (var q in Request.Form["StateID"])
            {
                StateID.Add(Convert.ToInt16(q));
            }
            foreach (var l in Request.Form["id"])
            {
                ChangeID.Add(Convert.ToInt16(l));
            }


            for (int i = 0; i < StateID.Count; i++)
            {
                switch (StateID[i])
                {
                    case 1:
                        break;
                    case 2:
                        string NewID = Request.Form["id"][i];

                        UserEntity Us = new UserEntity()
                        {
                            Login = Request.Form["login"].ToList()[i],
                            Name = Request.Form["name"].ToList()[i],
                            Surname = Request.Form["surname"].ToList()[i],
                            PhoneNumber = Request.Form["phone"].ToList()[i],
                            Age = Convert.ToInt16(Request.Form["age"].ToList()[i]),
                            Country = Request.Form["country"].ToList()[i],
                            Town = Request.Form["town"].ToList()[i],
                            Password = Request.Form[$"password-{ChangeID[i]}"],
                            IsVerified = Request.Form["Verify"].ToList().Contains(NewID),
                            
                        };

                        Us.Roles.Add(db.Roles.Single(c => c.Name == "User"));
                        Us.Page = new UserPageEntity() { User = Us };
                        db.Users.Add(Us);
                        db.SaveChanges();
                        break;
                    case 3:
                        var c = db.Users.Single(c => c.Id == ChangeID[i]);
                        c.Login = Request.Form["login"].ToList()[i];
                        c.Name = Request.Form["name"].ToList()[i];
                        c.Surname = Request.Form["surname"].ToList()[i];
                        c.PhoneNumber = Request.Form["phone"].ToList()[i];
                        c.Age = Convert.ToInt16(Request.Form["age"].ToList()[i]);
                        c.Country = Request.Form["country"].ToList()[i];
                        c.Town = Request.Form["town"].ToList()[i];
                        c.IsVerified = Request.Form["Verify"].ToList().Contains(Convert.ToString(ChangeID[i]));
                        db.SaveChanges();

                        break;
                    case 4:
                        db.Remove(db.Users.Single(c => c.Id == ChangeID[i]));
                        db.SaveChanges();
                        break;
                }
            }


            return Redirect("/Home/AdminPanel/1");
        }
        [Authorize]
        [Route("/UserPage/{login:maxlength(99)}/Friends")]
        public IActionResult ShowFriends(string login)
        {
            ViewBag.Friends = db.Users.Single(c => c.Login == login).Friends;
            return View();
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<RedirectResult> RoleChange()
        {
            var login = Request.Form["login"].ToString();

            var MS = db.Users.First(c => c.Login == login);
            MS.Roles.Clear();
            foreach(var c in Request.Form["CheckRole"])
            {
                int l = Convert.ToInt16(c);
                l++;
                MS.Roles.Add(db.Roles.Single(c => c.Id == l));
            }
            db.SaveChanges();


            return Redirect($"/Home/AdminPanel/{MS.Login}/Role");
        }

    }
}
