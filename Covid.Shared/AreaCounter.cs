namespace Covid.Shared
{
    public class AreaCounter
    {
        public AreaCounter()
        {
        }

        public AreaCounter(string area, string count)
        {
            Area = area;
            Count = count;
        }

        public string Area { get; set; }

        public string Count { get; set; }
    }
}
