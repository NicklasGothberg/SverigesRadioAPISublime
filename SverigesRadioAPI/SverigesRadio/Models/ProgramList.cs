namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class ProgramList : RequestBaseList
    {
        public List<RadioProgram> Programs { get; set; } = new();
    }
}
