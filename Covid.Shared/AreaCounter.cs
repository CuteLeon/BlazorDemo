using System;

namespace Covid.Shared
{
    public class AreaCounter
    {
        public AreaCounter()
        {
        }

        public AreaCounter(string area, int count)
        {
            Area = area;
            Count = count;
        }

        public string Area { get; set; }

        public int Count { get; set; }

        public DateTime PublishDate { get; set; }

        public DataSources DataSource { get; set; }

        public string Remark { get; set; }

        public bool Hide { get; set; }
    }
}
