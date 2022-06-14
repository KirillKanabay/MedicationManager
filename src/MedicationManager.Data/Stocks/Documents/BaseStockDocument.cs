﻿using System;
using MedicationManager.Data.Common.Documents;

namespace MedicationManager.Data.Stocks.Documents
{
    public class BaseStockDocument : DocumentBase
    {
        public DateTime Date { get; set; }
        public string MedicationId { get; set; }
        public int Count { get; set; }
        public int PricePerItem { get; set; }
        public int TotalPrice { get; set; }
    }
}
