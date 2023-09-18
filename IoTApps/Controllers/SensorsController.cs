using IoTApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoTApps.Controllers
{
    public class SensorsController : Controller
    {
        DBModel db = new DBModel();

        public ActionResult Index()
        {
            return View();
        }
        public string AnalogReading(int sensor, double value)
        {
            string msg = "Error processing the request.";
            try
            {
                if (sensor > 0)
                {
                    Reading reading = new Reading()
                    {
                        IdSensor = sensor,
                        Value = value,
                        Data = value.ToString(),
                        Date = DateTime.Now
                    };
                    db.Readings.Add(reading);
                    db.SaveChanges();
                    msg = "Value stored successfully";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}