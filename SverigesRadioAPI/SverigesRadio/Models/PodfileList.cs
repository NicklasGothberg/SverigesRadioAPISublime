namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class PodfileList : ResponseBaseList
    {
        public List<Podfile> Podfiles { get; set; } = new();
    }
}
