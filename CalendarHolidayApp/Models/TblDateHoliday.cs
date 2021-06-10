using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarHolidayApp.Models
{
    [Table("DateHolidays")]
    public class TblDateHoliday
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateHoliday { get; set; }
        public bool IsSameDay { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
