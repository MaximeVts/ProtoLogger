using System;
using System.ComponentModel.DataAnnotations;

namespace SqliteDb
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
