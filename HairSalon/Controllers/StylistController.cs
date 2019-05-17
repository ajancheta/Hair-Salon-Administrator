using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();

      List<Stylist> allStylist = Stylist.GetAll();

      return View("Index", allStylist);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> info = new Dictionary<string, object> ();
      Stylist selectStylist = Stylist.Find(id);
      List<Client> stylistClients = selectStylist.GetClients();

      info.Add("stylist", selectStylist);
      info.Add("clients", stylistClients);

      return View(info);
    }

    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(int stylistId, string clientName, string clientPhone)
    {
      Dictionary<string, object> info = new Dictionary<string, object>();
      Stylist selectStylist = Stylist.Find(stylistId);
      Client newClient = new Client(stylistId, clientName, clientPhone);
      newClient.Save();
      List<Client> stylistClients = selectStylist.GetClients();
      info.Add("clients", stylistClients);
      info.Add("stylist", selectStylist);
      return View("Show", info);
    }

    [HttpPost("/stylists/{stylistId}/clients/delete")]
    public ActionResult DeleteClients(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.DeleteClients();
      return RedirectToAction("Show", new { id = stylistId });
    }

    [HttpPost("/stylists/{stylistId}/delete")]
    public ActionResult Delete(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{stylistId}/edit")]
    public ActionResult Edit(int stylistId)
    {
      Dictionary<string, object> info = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      info.Add("stylist", stylist);
      return View(info);
    }

    [HttpPost("/stylists/{stylistId}/update")]
    public ActionResult Update(int stylistId, string newName)
    {
      Dictionary<string, object> info = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      stylist.Edit(newName);
      info.Add("stylist", stylist);
      return RedirectToAction("Show", new { id = stylistId });
    }
  }
}
