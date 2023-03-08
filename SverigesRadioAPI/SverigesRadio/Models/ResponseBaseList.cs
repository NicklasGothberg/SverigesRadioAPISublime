namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class ResponseBaseList : ResponseBase
    {
        public Pagination Pagination { get; set; } = new();

    }
}
