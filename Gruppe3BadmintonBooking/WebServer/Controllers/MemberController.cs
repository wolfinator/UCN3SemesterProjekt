using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebServer.Controllers;

public class MemberController : Controller
{
    static List<Member> _member = new List<Member>() {
            new Member() {id=1, firstName = "Bobby", lastName = "Bryan", email = "BobbyBryan@Colmail.com", houseNo = "24",
                          phoneNo = "30222889", street = "Venøvej", zipcode = "8000", },
            new Member() {id=1, firstName = "Caroline ", lastName = "Oswaldsen ", email = "Co@Colmail.com ", houseNo = "69 ",
                          phoneNo = "60159023 ", street = "Strandvej ", zipcode = "9000", },
            new Member() {id=1, firstName = "Joe", lastName = "Schmock", email = "JoeSchmock@Colmail.com", houseNo = "420",
                          phoneNo = "42069699", street = "Fasanvej", zipcode = "8800", },


        };
    public ActionResult Index() => View(_member);

    public ActionResult Details(int id)
    {
        return View(_member.First(member => member.id == id));
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Member member)
    {
        try
        {
            member.id = _member.Max(member => member.id) + 1;
            member.firstName = member.firstName;
            //TODO

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Edit(int id)
    {
        return View(_member.First(member => member.id == id));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Member editedMember)
    {
        try
        {
            var member = _member.First(member => member.id == editedMember.id);
            member.firstName = editedMember.firstName;
            member.lastName = editedMember.lastName;
            member.email = editedMember.email;
            member.houseNo = editedMember.houseNo;
            member.street = editedMember.street;
            member.phoneNo = editedMember.phoneNo;
            member.zipcode = editedMember.zipcode;

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Delete(int id)
    {
        return View(_member.First(member => member.id == id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Member deletedMember)
    {
        try
        {
            _member.RemoveAll(member => member.id == deletedMember.id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
