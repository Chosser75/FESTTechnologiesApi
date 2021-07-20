﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FESTTechnologiesApi.Models
{
    public class TimeZoneResponse
    {
        public int DstOffset { get; set; }
        public int RawOffset { get; set; }
        public string Status { get; set; }
        public string TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
