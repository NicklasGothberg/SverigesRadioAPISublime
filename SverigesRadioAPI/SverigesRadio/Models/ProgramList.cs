namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class ProgramList : ResponseBaseList
    {
        public List<RadioProgram> Programs { get; set; } = new();
    }
}
