using SverigesRadioAPI.SverigesRadio.Models;

namespace SverigesRadioAPI.ViewModels
{
    public class ProgramPodcastViewModel
    {
        public RadioProgram Program { get; set; } = new();

        public List<Podfile> Podfiles { get; set; } = new();
    }
}
