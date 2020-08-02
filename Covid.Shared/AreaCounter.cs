using System;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "区域不可为空")]
        public string Area { get; set; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public DateTime PublishDate { get; set; }

        public DataSources DataSource { get; set; }

        [MaxLength(1024)]
        public string Remark { get; set; }

        public bool Hide { get; set; }
    }
}
