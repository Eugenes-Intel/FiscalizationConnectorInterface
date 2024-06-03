﻿namespace FiCon.Models.Requests
{
    /// <summary>
    /// A model for parameters used in device registration
    /// </summary>
    public class RegdRequest
    {
        public char Drive { get; set; }

        public string DeviceId { get; set; }

        public string ActivationKey { get; set; }
    }
}