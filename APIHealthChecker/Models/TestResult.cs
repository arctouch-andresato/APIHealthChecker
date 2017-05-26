using System;
namespace APIHealthChecker.Models
{
    public class TestResult
    {
        public EndPoint EndPoint { get; set; }
		public bool IsWorking { get; set; }
        public string Details { get; set; }
	}
}
