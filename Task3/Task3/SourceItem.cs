using System.Text.Json.Serialization;

namespace Task3
{
    class SourceItem
    {

        public DateTime outageStart { get; set; }
        public DateTime outageEnd { get; set; }
        public string areaName { get; set; }
        public long affectedCustomers { get; set; }
        public string reason { get; set; }

    }
}
