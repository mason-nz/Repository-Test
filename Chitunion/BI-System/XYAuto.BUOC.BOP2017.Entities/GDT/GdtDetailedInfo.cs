﻿using System;

namespace XYAuto.BUOC.BOP2017.Entities.GDT
{
    public class GdtDetailedInfo
    {
        public string UserName { get; set; }
        public string GdtNum { get; set; }
        public string AccountType { get; set; }
        public string TradeType { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}