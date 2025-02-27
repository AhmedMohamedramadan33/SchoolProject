﻿namespace School.Core.Feature.Authentication.Query.Results
{
    public class GetUsers
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
