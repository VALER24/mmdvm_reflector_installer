﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P25_Reflector
{
    public class P25Peer
    {
        public IPEndPoint Address { get; private set; }
        public string CallSign { get; private set; }
        private DateTime _lastActive;

        public TransmissionState State { get; private set; }

        public P25Peer(IPEndPoint address, byte[] data)
        {
            Address = address;
            CallSign = System.Text.Encoding.ASCII.GetString(data, 1, 10);
            _lastActive = DateTime.Now;
            State = new TransmissionState();
        }

        public void Refresh()
        {
            _lastActive = DateTime.Now;
        }

        public bool IsSameAddress(IPEndPoint address)
        {
            return Address.Equals(address);
        }

        public bool IsExpired()
        {
            return (DateTime.Now - _lastActive).TotalSeconds > 5;
        }
    }
}
