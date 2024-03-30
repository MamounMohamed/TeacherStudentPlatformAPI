using Elfie.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherStudentPlatformAPI.Database;
using TeacherStudentPlatformAPI.DataModels;
using TeacherStudentPlatformAPI.Models;


namespace TeacherStudentPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(IWebHostEnvironment environment, UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _environment = environment;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //login
                var result = await signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return StatusCode(500, "Internal Server Error");


            }
            return BadRequest();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    UserType = model.UserType!
                };

                if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                {
                    var uploadsDir = "C:\\Users\\mamou\\source\\repos\\TeacherStudentPlatformAPI\\wwwroot\\ProfilePictures";
                    var uniqueFileName = "ProfilePic"+user.Id + user.Name + Path.GetExtension(model.ProfilePicture.FileName);
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProfilePicture.CopyToAsync(stream);
                    }

                    // Save the profile picture URI to the user object
                    user.ProfilePicture = uploadsDir + uniqueFileName; // Example URI, adjust as needed
                }

                // Create the user in the database
                var result = await userManager.CreateAsync(user, model.Password!);


                if (result.Succeeded)
                {
                    if (user.UserType == "Teacher")
                    {
                        Teacher teacher = new()
                        {
                            TeacherId = user.Id,
                            NumOfWatchers = 0,
                            NumUploadedVideos = 0,                            
                        };
                        await _context.Teachers.AddAsync(teacher);

                    }
                    else
                    {
                        Student student = new() {StudentId = user.Id};
                        await _context.Students.AddAsync(student);
                    }
                    await _context.SaveChangesAsync();
                    await signInManager.SignInAsync(user, false);
                    return Ok(user);
                }
              
                return StatusCode(500, "Internal Server Error");

            }
            return BadRequest();
        }
    }
 }
