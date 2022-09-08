﻿namespace PersonsAPI.Models
{
    public class PersonAPIModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalZip { get; set; }
        public string Country { get; set; }
    }
}