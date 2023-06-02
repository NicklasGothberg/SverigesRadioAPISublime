namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class PodfileList : RequestBaseList
    {
        public List<Podfile> Podfiles { get; set; } = new();
    }
}
