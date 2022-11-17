using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebServer.Controllers;

public class ReservationController : Controller
{
    static List<Reservation> _reservations = new List<Reservation>() {
            new Reservation() {Id=1, dateTime = DateTime.Now.AddDays(-1),
                isEquipment="true" },
            new Reservation() {Id=2, dateTime = DateTime.Now.AddDays(-2),
                isEquipment="false" },
            new Reservation() {Id=3, dateTime = DateTime.Now.AddDays(-3),
                isEquipment="true" }



        };
    public ActionResult Index() => View(_reservations);

    public ActionResult Details(int id)
    {
        return View(_reservations.First(reservation => reservation.Id == id));
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(BlogPost blogPost)
    {
        try
        {
            blogPost.Id = _blogPosts.Max(blogPost => blogPost.Id) + 1;
            blogPost.CreationDate = DateTime.Now;
            _blogPosts.Add(blogPost);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Edit(int id)
    {
        return View(_blogPosts.First(blogPost => blogPost.Id == id));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(BlogPost editedBlogPost)
    {
        try
        {
            var blogPost = _blogPosts.First(blogPost => blogPost.Id == editedBlogPost.Id);
            blogPost.Title = editedBlogPost.Title;
            blogPost.Content = editedBlogPost.Content;
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Delete(int id)
    {
        return View(_blogPosts.First(blogPost => blogPost.Id == id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(BlogPost deletedBlogPost)
    {
        try
        {
            _blogPosts.RemoveAll(blogPost => blogPost.Id == deletedBlogPost.Id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}