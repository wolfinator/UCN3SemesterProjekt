using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebServer.Controllers;

public class CustomerController : Controller
{
    static List<Customer> _customer = new List<Customer>() {
            new Customer() {id=1, firstName = "Bobby", lastName = "Bryan", email = "BobbyBryan@Colmail.com", houseNo = "24",
                          phoneNo = "30222889", street = "Venøvej", zipcode = "8000", },
            new Customer() {id=1, firstName = "Caroline ", lastName = "Oswaldsen ", email = "Co@Colmail.com ", houseNo = "69 ",
                          phoneNo = "60159023 ", street = "Strandvej ", zipcode = "9000", },
            new Customer() {id=1, firstName = "Joe", lastName = "Schmock", email = "JoeSchmock@Colmail.com", houseNo = "420",
                          phoneNo = "42069699", street = "Fasanvej", zipcode = "8800", },


        };
    public ActionResult Index() => View(_customer);

    public ActionResult Details(int id)
    {
        return View(_customer.First(customer => customer.id == id));
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Customer customer)
    {
        try
        {
            customer.id = _customer.Max(customer => customer.id) + 1;
            customer.firstName = customer.firstName;
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
        return View(_customer.First(customer => customer.id == id));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Customer editedCustomer)
    {
        try
        {
            var customer = _customer.First(customer => customer.id == editedCustomer.id);
            customer.firstName = editedCustomer.firstName;
            customer.lastName = editedCustomer.lastName;
            customer.email = editedCustomer.email;
            customer.houseNo = editedCustomer.houseNo;
            customer.street = editedCustomer.street;
            customer.phoneNo = editedCustomer.phoneNo;
            customer.zipcode = editedCustomer.zipcode;

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Delete(int id)
    {
        return View(_customer.First(customer => customer.id == id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Customer deletedCustomer)
    {
        try
        {
            _customer.RemoveAll(customer => customer.id == deletedCustomer.id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
