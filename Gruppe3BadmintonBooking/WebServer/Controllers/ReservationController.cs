using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebServer.Controllers;

public class ReservationController : Controller
{
    static List<Reservation> _reservations = new List<Reservation>() {
            new Reservation() {Id=1, fromTime = TimeSpan.FromHours(1),
                isEquipment=true },
            new Reservation() {Id=2, fromTime = TimeSpan.FromHours(2),
                isEquipment=false },
            new Reservation() {Id=3, fromTime = TimeSpan.FromHours(1),
                isEquipment=true }



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
    public ActionResult Create(Reservation reservation)
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
            reservation.fromTime = editedReservation.fromTime;
            reservation.isEquipment = editedReservation.isEquipment;
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
}