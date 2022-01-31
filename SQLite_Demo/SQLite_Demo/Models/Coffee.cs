using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLite_Demo.Models
{
    [Table("Coffee")]
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}
