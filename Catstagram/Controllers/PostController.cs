using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Catstagram.Data.IServices;
using Catstagram.Data.Static;
using Catstagram.Data.ViewModels;
using Catstagram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Controllers
{
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class PostController : Controller
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        // GET: /<Index>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var posts = await _service.GetAllAsync();

            var sortedPosts = posts.OrderByDescending(p => p.DateAdded);

            return View(sortedPosts);
        }

        // Get: /<Search>/
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allPosts = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allPosts.Where(p => p.Comment.Contains("#" + searchString) || p.Name.Contains(searchString)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index");
        }

        // GET: /<Create>/
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostVM post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            await _service.AddNewPostAsync(post);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Details>/
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var post = await _service.GetByIdAsync(id);

            if (post == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(post);
        }

        // GET: /<Edit>/
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _service.GetByIdAsync(id);

            if (post == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            var response = new PostVM()
            {
                Id = post.Id,
                Image = post.Image,
                Name = post.Name,
                Email = post.Email,
                DateAdded = post.DateAdded,
                Comment = post.Comment
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostVM post)
        {
            if (id != post.Id)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            if (!ModelState.IsValid)
            {
                return View(post);
            }

            await _service.UpdatePostAsync(post);

            return RedirectToAction(nameof(Index));
        }

        // GET: /<Delete>/
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _service.GetByIdAsync(id);

            if (post == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _service.GetByIdAsync(id);

            if (post == null)
            {
                return Content("HTTP 404 :\"Not Found\"");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

