using System.Text.Json.Serialization;

namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class ProgramChannel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
