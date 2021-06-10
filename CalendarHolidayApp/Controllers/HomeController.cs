using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalendarHolidayApp.Models;
using Newtonsoft.Json;
using CalendarHolidayApp.ViewModel;

namespace CalendarHolidayApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _db;
        public HomeController(ILogger<HomeController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<TblDateHoliday> dateHolidays = _db.TblDateHolidays.ToList();

            return View(dateHolidays);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult Post([FromBody] TblDateHoliday model)
        {
            try
            {
                model.DateHoliday = model.DateHoliday.AddDays(1);
                if (_db.TblDateHolidays.Where(x => x.DateHoliday == model.DateHoliday).Any())
                {
                    return Json(new { status = false, messages = "Date Already in database" });
                }
                else
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.DateHoliday = new DateTime(model.DateHoliday.Year, model.DateHoliday.Month, model.DateHoliday.Day, 0,0,0);
                    model.CreatedDate = DateTime.Now;
                    _db.TblDateHolidays.Add(model);
                    _db.SaveChanges();
                }

                return Json(new { status = true, data = _db.TblDateHolidays.ToList() });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, messages = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetDayDate([FromBody] TblDateHoliday model)
        {
            try
            {
                return Json(new { status = true, data = model.DateHoliday.AddDays(1).DayOfWeek });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, messages = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ChekingDayDate([FromBody] RangeDateViewModel model)
        {
            model.StartDate = model.StartDate.AddDays(1);
            model.EndDate = model.EndDate.AddDays(1);
            try
            {
                var listDateMonthJune = (GetMonthJuneBetweenYear(model.StartDate, model.EndDate));
                for (int i = 0; i < listDateMonthJune.Count(); i++)
                {
                    //Queens Bday
                    DateTime QueensBday = GetDatesSecondMondayInMonth(listDateMonthJune[i].Year, listDateMonthJune[i].Month);
                    if (!_db.TblDateHolidays.Where(x => x.DateHoliday == QueensBday).Any())
                    {
                        _db.TblDateHolidays.Add(new TblDateHoliday
                        {
                            Id = Guid.NewGuid().ToString(),
                            DateHoliday = QueensBday,
                            Name = $"Queens Bday {listDateMonthJune[i].Year}",
                            IsSameDay = true,
                            CreatedDate = DateTime.Now
                        });
                        _db.SaveChanges();
                    }
                }

                List<TblDateHoliday> dateHolidays = _db.TblDateHolidays.Where(x => (x.DateHoliday >= model.StartDate && 
                                                                                    x.DateHoliday < model.EndDate)).ToList();

                int CountDate = getCountWeekDay(model.StartDate, model.EndDate, dateHolidays);
                return Json(new { status = true, data = CountDate });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, messages = ex.Message });
            }
        }

        private static DateTime GetDatesSecondMondayInMonth(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(day => new DateTime(year, month, day))
                             .Where(x => x.DayOfWeek == DayOfWeek.Monday).Skip(1).FirstOrDefault();
        }

        private static List<DateTime> GetMonthJuneBetweenYear(DateTime start, DateTime end)
        {
            return Enumerable.Range(0, Int32.MaxValue)
                     .Select(e => start.AddMonths(e))
                     .TakeWhile(e => e <= end)
                     .Select(e => new DateTime(e.Year, e.Month, 1)).Where(x => x.Month == 6).ToList();
        }

        private static int getCountWeekDay(DateTime start, DateTime end, List<TblDateHoliday> dateHolidays)
        {
            List<DateTime> holydayInWeekDay = dateHolidays.Where(x => x.IsSameDay).Select(x => x.DateHoliday).ToList();
            List<DateTime> holydayInWeekEnd = dateHolidays.Where(x => !x.IsSameDay).Select(x => x.DateHoliday).ToList();

            var resultDate = Enumerable.Range(0, Int32.MaxValue)
                     .Select(e => start.AddDays(e))
                     .TakeWhile(e => e < end)
                     .Select(e => new DateTime(e.Year, e.Month, e.Day))
                     .Where(x => (x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday)
                            && (!holydayInWeekDay.Contains(x)))
                     .ToList();

            return resultDate.Count - holydayInWeekEnd.Where(x => (x >= start && x < end)).Count();
        }
    }
}
