using System;
using System.Collections.Generic;
using BLL.DTO;

namespace WUI.Models
{
    public class StatisticViewModel
    {
        public long TotalIncome { get; set; }
        
        public List<Tuple<GoodDTO, int>> StatByCount { get; set; }
    }
}