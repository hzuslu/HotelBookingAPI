﻿using Otel.EntityLayer.Concrete;

namespace Otel.WebUI.DTOs.ContactDTO
{
    public class AdminDashboardContactDTO
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
        public bool IsReplied { get; set; }
    }
}
