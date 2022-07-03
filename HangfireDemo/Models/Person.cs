using System;
using System.ComponentModel.DataAnnotations;

namespace HangfireDemo.Models
{
	public class Person
	{
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}

