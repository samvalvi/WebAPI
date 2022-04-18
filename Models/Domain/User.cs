﻿namespace WebAPI.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Role>? Roles { get; set; }
    }
}