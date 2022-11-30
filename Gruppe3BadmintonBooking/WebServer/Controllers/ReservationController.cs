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

    private readonly IReservationService _reservationsData;

    /*static List<Reservation> _reservations = new List<Reservation>() {
            new Reservation() {Id=1, startTime = DateTime.Parse("2022-02-03 13:00:00"),
                endTime = DateTime.Parse("2022-02-03 14:00:00"), shuttleReserved = true,
                numberOfRackets = 3},
            new Reservation() {Id=2, startTime = DateTime.Parse("2022-02-03 15:00:00"),
                endTime = DateTime.Parse("2022-02-03 16:00:00"), shuttleReserved = false,
                numberOfRackets = 2}
};
    */

    public ReservationController(IReservationService reservationsData)
    {
        _reservationsData = reservationsData;
    }


    public ActionResult Index() => View(_reservationsData);

    public ActionResult Details(int id)
    {
        //return View(_reservationsData.First(reservation => reservation.Id == id));
        return View(_reservationsData.GetById);
    }

    public ActionResult Create()
    {
        return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult SelectDate()
    {
        return View();
    }

    
/*    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SelectDate(Reservation reservation)
    {
        return View();
    }*/

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult SelectHour(DateTime startTime)
    {
        return View(_reservationsData.GetAvailableTimes);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult SelectEquipment(DateTime startTime)
    {
        return View(_reservationsData);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult ShowReservation(bool seleshuttleReserved, int numberOfRackets)
    {
        return View();
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
}
