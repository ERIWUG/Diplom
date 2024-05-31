using AppTest.Models.Entities;
using AppTest.Models;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using System.Data;
using System.IO;



namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext db = new AppDbContext();

        private IWebHostEnvironment _appEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _logger = logger;
        }








        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.TESTS = db.Tests.AsNoTracking().ToListAsync().Result;


            List<String> Towns = db.Tests.OrderBy(c => c.TownRequirement).Select(c => c.TownRequirement).Distinct().ToList();
            Towns.RemoveAll(string.IsNullOrWhiteSpace);

            List<String> Country = db.Tests.OrderBy(c => c.CountryRequirement).Select(c => c.CountryRequirement).Distinct().ToList();
            Country.RemoveAll(string.IsNullOrWhiteSpace);

            ViewBag.Towns = Towns;
            ViewBag.Countries = Country;



            List<UserEntity> Users = [];
            int i = 0;
            foreach (var c in db.Users.OrderByDescending(c => c.Tests.Count).ToList())
            {
                if (c.Tests.Count == 0) { continue; }
                Users.Add(c);
                i++;
                if (i > 10) { break; }
            }

            ViewBag.Users = Users;

            return View();
        }


        [HttpPost]
        [Route("/Home/IndexFiltered")]
        public IActionResult IndexFiltered()
        {
            var Towns = Request.Form["Town"].ToList();
            var Countries = Request.Form["Country"].ToList();

            List<TestEntity> Tests = new List<TestEntity>();


            if (Countries.Count == 0 && Towns.Count == 0)
            {
                Tests = db.Tests.ToList();
            }
            else
            if (Towns.Count == 0)
            {
                foreach (var c in Countries)
                {
                    foreach (var q in db.Tests.Where(l => l.CountryRequirement == c).ToList())
                    {
                        if (!Tests.Contains(q)) { Tests.Add(q); }
                    }
                }
            }
            else if (Countries.Count == 0)
            {
                foreach (var c in Towns)
                {
                    foreach (var q in db.Tests.Where(l => l.TownRequirement == c).ToList())
                    {
                        if (!Tests.Contains(q)) { Tests.Add(q); }
                    }
                }
            }
            else
            {
                foreach (var c in Countries)
                {
                    foreach (var q in db.Tests.Where(l => l.CountryRequirement == c).ToList())
                    {
                        if (Towns.Contains(q.TownRequirement) && !Tests.Contains(q))
                        { Tests.Add(q); }
                    }
                }
            }



            ViewBag.TESTS = Tests;

            List<UserEntity> Users = [];
            int i = 0;
            foreach (var c in db.Users.OrderByDescending(c => c.Tests.Count).ToList())
            {
                if (c.Tests.Count == 0) { continue; }
                Users.Add(c);
                i++;
                if (i > 10) { break; }
            }

            List<String> towns = db.Tests.OrderBy(c => c.TownRequirement).Select(c => c.TownRequirement).Distinct().ToList();
            towns.RemoveAll(string.IsNullOrWhiteSpace);

            List<String> country = db.Tests.OrderBy(c => c.CountryRequirement).Select(c => c.CountryRequirement).Distinct().ToList();
            country.RemoveAll(string.IsNullOrWhiteSpace);

            ViewBag.Towns = towns;
            ViewBag.Countries = country;


            ViewBag.Users = Users;
            ViewBag.CheckedTowns = Towns;
            ViewBag.CheckedCountries = Countries;

            return View();
        }


        [Authorize]
        [HttpPost]
        public RedirectResult AddCommentTest()
        {
            int TestID = Convert.ToInt16(Request.Form["TestID"]);

            var UUser = db.Users.Single(c => c.Login == User.Identity.Name);

            var CommentText = Request.Form["PostText"];

            var test = db.Tests.Single(c => c.Id == TestID);
            var q = new CommentEntity() { User = UUser, Test = test, Text = CommentText, Time = DateTime.Now, UserID = UUser.Id };
            test.Comments.Add(q);
            db.SaveChanges();

            return Redirect("/Home/Test/" + TestID);
        }
        [HttpPost]
        [Route("/Home/Search/")]
        public IActionResult SearchPage()
        {

            string text = Request.Form["SearchField"];
            List<TestEntity> tests = [];
            List<UserEntity> users = [];

            bool flag = false;

            UserEntity? userEntity = null;

            try
            {
                userEntity = db.Users.Single(c => c.Login == text);
            }
            catch (System.InvalidOperationException)
            {
                userEntity = null;
            }



            flag = userEntity is not null;

            foreach (var q in db.Tests.ToList())
            {
                if (q.Name.ToLower().IndexOf(text.ToLower()) != -1)
                {
                    tests.Add(q);
                }

                if ((q.Author.Login.ToLower().IndexOf(text.ToLower()) != -1) && (flag))
                {


                    if (!users.Contains(q.Author))
                    {
                        users.Add(q.Author);
                    }

                }

            }

            if (flag)
            {
                tests.AddRange(userEntity.Tests);
            }

            ViewBag.Users = users;
            ViewBag.Tests = tests;
            ViewBag.Text = text;

            return View();
        }

        [Authorize]
        [HttpPost]
        public RedirectResult ReportTest()
        {
            TestEntity test = db.Tests.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"]));
            ReportEntity report = new ReportEntity();
            report.Test = test;
            db.Reports.Add(report);
            db.SaveChanges();

            return Redirect($"/Home/Test/{Request.Form["TestID"]}");
        }

        [Authorize]
        [Route("/Home/ReportPost/{PostID:int}")]
        public RedirectResult ReportPost(int PostID)
        {
            PostEntity post = db.Posts.Single(c => c.Id == PostID);
            ReportEntity report = new ReportEntity();
            report.Post = post;
            db.Reports.Add(report);
            db.SaveChanges();

            return Redirect($"/UserPage/{post.UserPage.User.Login}");
        }

        [Authorize]
        [Route("/Home/ReportComment/{CommentID:int}")]
        public RedirectResult ReportComment(int CommentID)
        {
            CommentEntity comment = db.Comments.Single(c => c.Id == CommentID);
            ReportEntity report = new ReportEntity();
            report.Comment = comment;
            db.Reports.Add(report);
            db.SaveChanges();

            if (comment.Test is not null)
            {
                return Redirect($"/Home/Test/{comment.Test.Id}");
            }
            else
            {
                return Redirect($"/UserPage/{comment.Post.UserPage.User.Login}");
            }


        }


        [Route("/Home/Test/{TestID:int}")]
        public IActionResult TestPage(int TestID)
        {
            int id = TestID;
            var Test = db.Tests.Where(c => c.Id == id).First();



            var flag = false;
            if (User.Identity.Name is not null)
            {
                foreach (var q in db.Users.Single(c => c.Login == User.Identity.Name).Results)
                {
                    if (q.Test is null) { continue; }
                    flag = q.Test.Id == id;
                    if (flag) { break; }
                }
            }

            ViewBag.Test = Test;
            ViewBag.Flag = flag;

            return View();
        }

        [Authorize]
        public IActionResult GenerateTest()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectResult> AddComment()
        {
            var UUser = await db.Users.Where(c => c.Login == User.Identity.Name).FirstAsync();

            var CommentText = Request.Form["PostText"];
            var PostId = Convert.ToInt16(Request.Form["PostID"]);

            var post = await db.Posts.SingleAsync(c => c.Id == PostId);
            var q = new CommentEntity() { User = UUser, Post = post, Text = CommentText, Time = DateTime.Now, UserID = UUser.Id };
            post.Comments.Add(q);
            await db.SaveChangesAsync();

            var Owner = Request.Form["Owner"];

            return Redirect("/UserPage/" + Owner);
        }

        [Route("/Home/Registration")]
        public IActionResult RegistrationForm()
        {
            ViewBag.Users = db.Users.AsNoTracking().Select(c => c.Login).ToArray();
            return View();
        }




        [Authorize]
        [HttpPost]
        public async Task<RedirectResult> AddPost()
        {
            var PostText = Request.Form["PostText"];
            var PostTitle = Request.Form["PostTitle"];

            var UUser = await db.Users.Where(c => c.Login == User.Identity.Name).FirstAsync();

            var q = new PostEntity() { Text = PostText, Title = PostTitle, UserPage = UUser.Page, time = DateTime.Now };
            UUser.Page.Posts.Add(q);

            await db.SaveChangesAsync();

            return Redirect("/UserPage/" + User.Identity.Name);
        }
        [Authorize(Roles = "Admin")]
        [Route("/Home/AdminPanel/1")]
        public IActionResult AdminPanel1()
        {
            ViewBag.Users = db.Users.ToListAsync().Result;
            return View();
        }


        [Authorize(Roles = "Admin")]
        [Route("/Home/AdminPanel/Reports")]

        public IActionResult AdminPanelReports() {
            ViewBag.Tests = db.Tests.Where(c => c.Reports.Count > 0).ToList();
            ViewBag.Comments = db.Comments.Where(c => c.Reports.Count > 0).ToList();
            ViewBag.Posts = db.Posts.Where(c => c.Reports.Count > 0).ToList();

            return View();
        }

        [Authorize(Roles = "Admin")]
        public RedirectResult TestProcess()
        {
            if (Convert.ToInt16(Request.Form["TestChoise"]) == 1)
            {
                db.Tests.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).Reports.Clear();
                db.Tests.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).TestResults.Clear();
                db.Tests.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).TestContents.Clear();
                db.Tests.Remove(db.Tests.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])));

            }
            else
            {
                db.Tests.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).Reports.Clear();
            }

            db.SaveChanges();

            return Redirect("/Home/AdminPanel/Reports");
        }

        [Authorize(Roles = "Admin")]
        public RedirectResult CommentProcess()
        {
            if (Convert.ToInt16(Request.Form["TestChoise"]) == 1)
            {
                db.Comments.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).Reports.Clear();
                db.Comments.Remove(db.Comments.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])));
            }
            else
            {
                db.Comments.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).Reports.Clear();
            }

            db.SaveChanges();

            return Redirect("/Home/AdminPanel/Reports");
        }

        [Authorize(Roles = "Admin")]
        public RedirectResult PostProcess()
        {
            if (Convert.ToInt16(Request.Form["TestChoise"]) == 1)
            {
                db.Posts.Remove(db.Posts.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])));
            }
            else
            {
                db.Posts.Single(c => c.Id == Convert.ToInt16(Request.Form["TestID"])).Reports.Clear();
            }

            db.SaveChanges();

            return Redirect("/Home/AdminPanel/Reports");
        }


        [Authorize(Roles = "Admin")]
        [Route("/Home/ShowPosts/{ItemId:int}/{ModeId:int}")]
        public IActionResult ShowPosts(int ItemId, int ModeId)
        {
            ViewBag.Mode = ModeId;

            if (ModeId == 1)
            {
                ViewBag.Post = db.Posts.Single(c => c.Id == ItemId);
                
            }
            else
            {
                ViewBag.Comment = db.Comments.Single(c => c.Id == ItemId); 
            }




            return View();
        }




        [HttpPost]
        public async Task<RedirectResult> TestAnalyze()
        {
            TestResultEntity testResult = new TestResultEntity();
            UserEntity? MyUser;

            if (!User.IsInRole("User"))
            {
                MyUser = null;
            }
            else
            {
                MyUser = db.Users.Single(c => c.Login == User.Identity.Name);
            }
            
            testResult.User = MyUser;

            var TestID = Convert.ToInt16(Request.Form["TestID"]);

            var Test = db.Tests.Single(c => c.Id == TestID);

            

            int i = 0;
            #region Delete existed Test
            bool flag = false;
            if (MyUser is not null)
            {
                foreach (var c in MyUser.Results)
                {
                    flag = c.Test.Id == TestID;
                    if (flag)
                    {
                        i = c.Id;
                        break;
                    }
                }
            }
            if (flag)
            {
                Test.TestResults.Remove(Test.TestResults.Single(c => c.Id == i));
                MyUser.Results.Remove(MyUser.Results.Single(c => c.Id == i));
            }
            #endregion

            testResult.Test = Test;

            i = Test.TestContents.Count;
            List<AnswerEntity> Answers = new List<AnswerEntity>();

            for(int j = 0; j < i; j++)
            {
                switch (Test.TestContents[j].Answers[0].AnswerType)
                {
                    case 1:
                        Answers.Add(Test.TestContents[j].Answers.Single(c=>c.Id == Convert.ToInt16(Request.Form[$"Answers-{j + 1}"])));
                        break;
                    case 2:
                        foreach (var q in Request.Form[$"Answers-{j+1}"])
                        {
                            Answers.Add(Test.TestContents[j].Answers.Single(c => c.Id == Convert.ToInt16(q)));
                        }
                        break;
                    case 3:
                        Answers.Add(new AnswerEntity()
                        {
                            Text = Request.Form[$"Answers-{j + 1}"],
                            Value = Test.TestContents[j].Answers[0].Value,
                            AnswerType=3, Results = new List<TestResultEntity>() {testResult },
                        }
                        );

                        break;
                    case 4:
                        Answers.Add(Test.TestContents[j].Answers.Single(c => c.Id == Convert.ToInt16(Request.Form[$"Answers-{j + 1}"])));
                        break;
                    default:
                        break;
                }
            
            }
            testResult.Answers = Answers;
            db.TestResults.Add(testResult);

          
            
            
            db.SaveChanges();

            return Redirect($"/Home/Index");
        }

        [Authorize]
        [HttpPost]
        public RedirectResult DeleteComment()
        {
            int id =Convert.ToInt16( Request.Form["CommentID"]);
            
            var Comment = db.Comments.Single(c => c.Id == id);

            db.Comments.Remove(Comment);

            db.SaveChanges();

            return Redirect($"/UserPage/{Request.Form["Login"]}");
        }

        [Authorize]
        [HttpPost]
        public RedirectResult DeleteCommentTest()
        {
            int id = Convert.ToInt16(Request.Form["CommentID"]);

            var Comment = db.Comments.Single(c => c.Id == id);

            db.Comments.Remove(Comment);

            db.SaveChanges();

            return Redirect($"/Home/Test/{Request.Form["Test"]}");
        }




        [Route("/UserPage/{login:maxlength(99)}/Tests")]
        public IActionResult TestsInformation(string login)
        {
            ViewBag.Flag = login == User.Identity.Name;
            ViewBag.MyUser = db.Users.Single(c => c.Login == login);
            ViewBag.Count = db.Users.Single(c => c.Login == login).Tests.Where(c => c.isClosed == false).ToList().Count();
            ViewBag.CountAll = db.Users.Single(c => c.Login == login).Tests.ToList().Count();

            return View();
        }

        [Route("/UserPage/{login:maxlength(99)}/Tests/{testid:int}")]
        public IActionResult TestAnalizer(string login, int testid)
        {
            var test = db.Tests.Single(c => c.Id == testid);

            List<TestResultEntity>? TestResults = test.TestResults;

            List<Dictionary<string, int>> Answer1 = new List<Dictionary<string, int>>();
            List<Dictionary<string, int>> Answer2 = new List<Dictionary<string, int>>();
            List<List<string>> Answer3 = new List<List<string>>();
            List<Dictionary<string, int>> Answer4 = new List<Dictionary<string, int>>();

            List<string> Text1 = new List<string>();
            List<string> Text2 = new List<string>();
            List<string> Text3 = new List<string>();
            List<string> Text4 = new List<string>();

            if (TestResults is null)
            {
                return View();
            }
            else
            {

                foreach(var kl in test.TestContents)
                {
                    switch (kl.Answers[0].AnswerType)
                    {
                        case 1:
                            Text1.Add(kl.Text);
                            break;
                        case 2:
                            Text2.Add(kl.Text);
                            break;
                        case 3:
                            Text3.Add(kl.Text);
                            break;
                        case 4:
                            Text4.Add(kl.Text);
                            break;
                    }
                }



                Dictionary<int, int> Flag = new Dictionary<int, int>();

                foreach (var kl in TestResults)
                {
                    foreach (var q in kl.Answers)
                    {
                        switch (q.AnswerType)
                        {
                            case 1:
                                if (!Flag.ContainsKey(q.Value))
                                {
                                    int INDEX = Answer1.Count();
                                    Flag.Add(q.Value, INDEX);
                                    Answer1.Add(new Dictionary<string, int>());
                                }

                                if (Answer1[Flag[q.Value]].ContainsKey(q.Text))
                                {
                                    Answer1[Flag[q.Value]][q.Text]++;
                                }
                                else
                                {
                                    Answer1[Flag[q.Value]].Add(q.Text, 1);
                                }

                                break;
                            case 2:
                                if (!Flag.ContainsKey(q.Value))
                                {
                                    int INDEX = Answer2.Count();
                                    Flag.Add(q.Value, INDEX);
                                    Answer2.Add(new Dictionary<string, int>());
                                }

                                if (Answer2[Flag[q.Value]].ContainsKey(q.Text))
                                {
                                    Answer2[Flag[q.Value]][q.Text]++;
                                }
                                else
                                {
                                    Answer2[Flag[q.Value]].Add(q.Text, 1);
                                }
                                break;
                            case 3:
                                if (!Flag.ContainsKey(q.Value))
                                {
                                    int INDEX = Answer3.Count();
                                    Flag.Add(q.Value, INDEX);
                                    Answer3.Add(new List<string>());
                                }

                                Answer3[Flag[q.Value]].Add(q.Text);
                                break;
                            case 4:
                                if (!Flag.ContainsKey(q.Value))
                                {
                                    int INDEX = Answer4.Count();
                                    Flag.Add(q.Value, INDEX);
                                    Answer4.Add(new Dictionary<string, int>());
                                }

                                if (Answer4[Flag[q.Value]].ContainsKey(q.Text))
                                {
                                    Answer4[Flag[q.Value]][q.Text]++;
                                }
                                else
                                {
                                    Answer4[Flag[q.Value]].Add(q.Text, 1);
                                }
                                break;
                        }
                    }
                }  
            }
            ViewBag.Answer1 = Answer1;
            ViewBag.Answer2 = Answer2;
            ViewBag.Answer3 = Answer3;
            ViewBag.Answer4 = Answer4;

            ViewBag.Text1 = Text1;
            ViewBag.Text2 = Text2;
            ViewBag.Text3 = Text3;
            ViewBag.Text4 = Text4;

            return View();
        }

        [HttpPost]
        [Route("/UserPage/{login:maxlength(99)}/Tests/{testid:int}")]
        public IActionResult TestAnalizer(int testid)
        {
            List<TestResultEntity>? TestResults=null;


            ViewBag.TestResults = TestResults;

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectResult> CreateTest(List<IFormFile> AnswerImage, List<IFormFile> QuestionImage)
        {
            





            
            var prom = Request.Form["AmountQuestion"].ToList();
            var QuestionText = Request.Form[$"QuestionText"].ToList();
            string TownRequirment = Request.Form["Town"];
            string CountryRequirment = Request.Form["Country"];

            List<int> AnswerImageID = [];
            List<int> QuestionImageID = [];

            foreach(var c in Request.Form["AnswerImageID"])
            {
                AnswerImageID.Add(Convert.ToInt16(c));

            }

            foreach (var c in Request.Form["QuestionImageID"])
            {
                QuestionImageID.Add(Convert.ToInt16(c));

            }



            int ALLAMOUNT = 0;
            List<int> AmountQuestion = new();

            foreach(var c in prom)
            {
                AmountQuestion.Add(Convert.ToInt16(c)-1);
            }

            TestEntity test = new() {
                Author = db.Users.Single(c => c.Login == User.Identity.Name),
                Name = Request.Form["TestName"],
                Description = Request.Form["TestDescription"],
                isClosed = Request.Form["isClosed"] == "true",
                isRequiredAuthorization = Request.Form["isNeedAuthentification"] == "true",
                TownRequirement = TownRequirment == "" ? "" : TownRequirment.Substring(0, 1).ToUpper() + TownRequirment.Substring(1).ToLower(),
                CountryRequirement = CountryRequirment == "" ? "": CountryRequirment.Substring(0, 1).ToUpper() + CountryRequirment.Substring(1).ToLower(),
        };

            int j = 1;
            foreach (var c in AmountQuestion)
            {
                prom = Request.Form[$"AnswerType-{j}"].ToList();
                var Texts = Request.Form[$"AnswerText-{j}"].ToList();
                List<int> Types = new();
                foreach (var q in prom)
                {
                    Types.Add(Convert.ToInt16(q));
                }
                int klkl = 0;

                test.TestContents.Add(new TicketEntity()
                    {
                        Text = QuestionText[j-1],
                    }
                );

                if (QuestionImageID.Contains(j)){
                    string path = "/Files/" + QuestionImage[QuestionImageID.IndexOf(j)].FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await QuestionImage[QuestionImageID.IndexOf(j)].CopyToAsync(fileStream);
                    }
                    ImageEntity img = new ImageEntity { src = path };
                    test.TestContents.Last().Image=img;
                }

                for (int i = 0; i < c; i++)
                {
                    string Options = "";
                    AnswerEntity answer = new AnswerEntity()
                    {
                        AnswerType = Types[i],
                        
                        Value = j,
                        Text = Texts[i]
                    };

                    if (AnswerImageID.Contains(ALLAMOUNT+1))
                    {
                        string path = "/Files/" + AnswerImage[AnswerImageID.IndexOf(ALLAMOUNT + 1)].FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await AnswerImage[AnswerImageID.IndexOf(ALLAMOUNT + 1)].CopyToAsync(fileStream);
                        }
                        ImageEntity img = new ImageEntity { src = path };
                        answer.Image = img;
                    }

                    test.TestContents.Last().Answers.Add(answer);

                    ALLAMOUNT++;
                }
                j++;

            }


            

            db.Tests.Add(test);

            
            await db.SaveChangesAsync();
          
            return Redirect("/Home/Index");
        }

        
        public IActionResult TestAction(int TestId)
        {
            int id = Int32.Parse(Request.Form["TestID"]);
            ViewBag.Test = db.Tests.Where(c => c.Id == id)
                .AsNoTracking()
                .FirstAsync()
                .Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    
    }



}
