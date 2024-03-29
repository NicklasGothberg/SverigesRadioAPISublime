﻿namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class Pagination : RequestBase
    {
        public int Page { get; set; }
     
        public int Size { get; set; }
        
        public int TotalHits { get; set; }
        
        public int TotalPages { get; set; }
        
        public string NextPage { get; set; } = string.Empty;
    }
}
