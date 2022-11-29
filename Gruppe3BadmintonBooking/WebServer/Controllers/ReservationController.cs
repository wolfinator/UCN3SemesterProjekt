using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Models;
using Newtonsoft.Json;
using WebServer.Models;

namespace WebServer.Controllers;

[Authorize]

public class ReservationController : Controller
{
    static List<Reservation> _reservations = new List<Reservation>() {
            new Reservation() {Id=1, startTime = DateTime.Parse("2022-02-03 13:00:00"),
                endTime = DateTime.Parse("2022-02-03 14:00:00"), shuttleReserved = true,
                numberOfRackets = 3},
            new Reservation() {Id=2, startTime = DateTime.Parse("2022-02-03 15:00:00"),
                endTime = DateTime.Parse("2022-02-03 16:00:00"), shuttleReserved = false,
                numberOfRackets = 2}
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
    [ActionName("SelectDate")]
    public ActionResult SelectDate(Reservation reservation)
    {
        //Reservation res = new Reservation();
        //res.startTime = 
        //try
        //{
        //    reservation.Id = _reservations.Max(reservation => reservation.Id) + 1;
        //    _reservations.Add(reservation);

        //    return RedirectToAction(nameof(Index));
        //}
        //catch
        {
            return View();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("SelectHour")]
    public ActionResult Create2(Reservation reservation)
    {
        try
        {
            reservation.Id = _reservations.Max(reservation => reservation.Id) + 1;
            _reservations.Add(reservation);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Edit(int id)
    {
        return View(_reservations.First(reservation => reservation.Id == id));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Reservation editedReservation)
    {
        try
        {
            var reservation = _reservations.First(reservation => reservation.Id == editedReservation.Id);
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

    private void StoreReservationInTempData(Reservation reservation)
    {
        TempData["Reservation"] = JsonConvert.SerializeObject(reservation);
    }
    private Reservation GetReservationFromTempData()
    {
        return JsonConvert.DeserializeObject<Reservation>((string)TempData["Reservation"]);
    }
}