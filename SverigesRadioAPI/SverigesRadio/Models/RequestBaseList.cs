namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class RequestBaseList : RequestBase
    {
        public Pagination Pagination { get; set; } = new();

    }
}
