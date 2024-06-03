﻿using FiCon.Models.Global;

namespace FiCon.Models.Results
{
    /// <summary>
    /// A model for parameters used in device SN generation
    /// </summary>
    public class SnResult : IRequestResult
    {
        public char Drive { get; set; }

        public string Serial { get; set; }

        public int Length { get; set; } = 0;
        public ushort DeviceId { get; set; }
    }
}