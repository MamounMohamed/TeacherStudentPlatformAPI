using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherStudentPlatformAPI.Models;
using TeacherStudentPlatformAPI.Database;
using TeacherStudentPlatformAPI.DataModels;

namespace TeacherStudentPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            return await _context.Videos.ToListAsync();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(string id)
        {
            var video = await _context.Videos.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(string id, Video video)
        {

            video.VideoId = id;
            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(VideoModel videoModel)
        {
            string newId = Guid.NewGuid().ToString();
            string videoURI = UpdateMediaFile("Videos", videoModel.VideoFile, newId);

            Video video = new()
            {
                VideoId =newId ,
                VideoName = videoModel.VideoName,
                VideoDescription = videoModel.VideoDescription,
                CourseId = videoModel.CourseId,
                VideoURI = videoURI
            };
            if (videoModel.VideoThumbnailFile != null)
            {
                string videoThumbnail = UpdateMediaFile("Video_Thumbnails", videoModel.VideoThumbnailFile, newId);
                video.VideoThumbnail = videoThumbnail;
            }



            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.VideoId }, video);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(string id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoExists(String id)
        {
            return _context.Videos.Any(e => e.VideoId == id);
        }

        private  string UpdateMediaFile(string type , IFormFile file , string videoId)
        {

                var uploadsDir = $"C:\\Users\\mamou\\source\\repos\\TeacherStudentPlatformAPI\\wwwroot\\{type}";
                var uniqueFileName = type + videoId  + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsDir, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyTo(stream);
                }

                // Save the profile picture URI to the user object
                return  uploadsDir + uniqueFileName; // Example URI, adjust as needed
            
        }
    }
}
