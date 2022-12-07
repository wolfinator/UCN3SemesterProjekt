using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Model;
using Models;
using Newtonsoft.Json;
using RestSharpClient.Interfaces;
using WebServer.Models;

namespace WebServer.Controllers;

[Authorize]

public class ReservationController : Controller
{

    private readonly IReservationService _reservationsService;
    private readonly ICustomerService _customerService;
    private readonly IInvoiceService _invoiceService;

    private readonly int ReservationBasePrice = 150;
    private readonly int ReservationShuttlePrice = 50;

    /*static List<Reservation> _reservations = new List<Reservation>() {
            new Reservation() {Id=1, startTime = DateTime.Parse("2022-02-03 13:00:00"),
                endTime = DateTime.Parse("2022-02-03 14:00:00"), shuttleReserved = true,
                numberOfRackets = 3},
            new Reservation() {Id=2, startTime = DateTime.Parse("2022-02-03 15:00:00"),
                endTime = DateTime.Parse("2022-02-03 16:00:00"), shuttleReserved = false,
                numberOfRackets = 2}
};
    */

    public ReservationController(IReservationService reservationsService, ICustomerService customerService, IInvoiceService invoiceService)
    {
        _reservationsService = reservationsService;
        _customerService = customerService;
        _invoiceService = invoiceService;
    }


    public ActionResult Index() => View(_reservationsService);

    public ActionResult Details(int id)
    {
        //return View(_reservationsData.First(reservation => reservation.Id == id));
        return View(_reservationsService.GetById(id));
    }

    public ActionResult Create()
    {
        return View();
    }


    public ActionResult SelectDate()
    {
        return View(DateTime.Now);
    }

    
/*    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SelectDate(Reservation reservation)
    {
        return View();
    }*/

    [HttpPost]
    public ActionResult SelectHour(DateTime selectedDate)
    {
        TempData["ChosenDate"] = $"{selectedDate.ToString("dddd")} den {int.Parse(selectedDate.ToString("dd"))}. {selectedDate.ToString("MMMM yyyy")}"; 
        return View(_reservationsService.GetAvailableTimes(selectedDate.ToString("yyyy-MM-dd")));
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult SelectEquipment(string selectedCourtAndTime)
    {
        Reservation reservation = new();
        var courtAndTime = selectedCourtAndTime.Split('_', StringSplitOptions.RemoveEmptyEntries);

        //var actual = JsonConvert.DeserializeObject<object[]>(selectedCourtAndTime);

        var actualStartTime = DateTime.Parse(courtAndTime[1]);
        var actualCourtNo = int.Parse(courtAndTime[0]);

        reservation.courtNo = actualCourtNo;
        reservation.startTime = actualStartTime;
        reservation.endTime = actualStartTime.AddHours(1);

        StoreReservationInTempData(reservation);
        
        return View();
    }

    [HttpPost]
    public ActionResult ShowReservation(Reservation viewReservation)
    {
        Reservation reservation = GetReservationFromTempData();
        reservation.shuttleReserved = viewReservation.shuttleReserved;
        reservation.numberOfRackets = viewReservation.numberOfRackets;
        StoreReservationInTempData(reservation);

        reservation.customer = new Customer()
        {
            firstName = viewReservation.customer.firstName,
            lastName = viewReservation.customer.lastName,
            phoneNo = viewReservation.customer.phoneNo,
            email = viewReservation.customer.email,
            street = "",
            houseNo = "",
            zipcode = ""
        };

        reservation.customer.id = _customerService.Create(reservation.customer);
        reservation.creationDate = DateTime.Now;
        try
        {
            reservation.id = _reservationsService.Create(reservation);
            var invoice = new Invoice() {reservation = reservation, totalPrice = GetPrice(reservation) };
            _invoiceService.Create(invoice);
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["IsAlreadyBooked"] = "Den valgte tid er allerede blevet booket.";
                return RedirectToAction("Index", "Home", reservation);
            }
            throw;
        }
        TempData["Price"] = GetPrice(reservation);
        return View(reservation);
    } 
/*
    public ActionResult Edit(int id)
    {
        return View(_reservationsData.First(reservation => reservation.Id == id));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Reservation editedReservation)
    {
        try
        {
            var reservation = _reservationsData.First(reservation => reservation.Id == editedReservation.Id);
            reservation.startTime = editedReservation.startTime;
            reservation.shuttleReserved = editedReservation.shuttleReserved;
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Delete(int id)
    {
        return View(_reservations.First(reservation => reservation.Id == id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Reservation deletedReservation)
    {
        try
        {
            _reservations.RemoveAll(reservation => reservation.Id == deletedReservation.Id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
*/
    private void StoreReservationInTempData(Reservation reservation)
    {
        TempData["Reservation"] = JsonConvert.SerializeObject(reservation);
    }
    private Reservation GetReservationFromTempData()
    {
        return JsonConvert.DeserializeObject<Reservation>((string)TempData["Reservation"]);
    }
    private decimal GetPrice(Reservation reservation)
    {
        return ReservationBasePrice + (reservation.shuttleReserved ? 50 : 0);
    }
}
