﻿using System.ComponentModel.DataAnnotations;

namespace Bootcamp2_AspMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; } = null;
        public decimal Salary { get; set; } = 0;

        public bool Islock { get; set; } = false; 
        public bool IsDelete { get; set; } = false; 
        public DateTime AddDate { get; set; } = DateTime.Now;

    }
}
