namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class Podfile
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Url { get; set; } = string.Empty;

        
        public ProgramChannel Program { get; set; } = new ProgramChannel();
        
        public DateTime AvailableFromUtc { get; set; }
        
        public DateTime PublishDateUtc { get; set; }

        public int FileSizeInBytes { get; set; }

        public int Duration { get; set; }

        public string DurationString
        {
            get
            {
                var timespan = TimeSpan.FromSeconds(Duration);
                return timespan.ToString(@"hh\:mm\:ss");
            }
        }

        public string Statkey { get; set; } = string.Empty;
    }
}
