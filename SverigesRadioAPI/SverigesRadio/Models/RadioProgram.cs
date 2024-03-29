﻿using System.Text.Json.Serialization;

namespace SverigesRadioAPI.SverigesRadio.Models
{
    public class RadioProgram
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;

        public string ResponsibleEditor { get; set; } = string.Empty;

        public string ProgramUrl { get; set; } = string.Empty;
        
        public string ProgramImage { get; set; } = string.Empty;
        
        [JsonPropertyName("programimagetemplate")]
        public string ProgramImageUrlTemplate { get; set; } = string.Empty;
        
        [JsonPropertyName("programimagewide")]
        public string ProgramImageWideUrl { get; set; } = string.Empty;
        
        [JsonPropertyName("programimagetemplatewide")]
        public string ProgramImageUrlTemplateWide { get; set; } = string.Empty;
        
        [JsonPropertyName("socialimage")]
        public string SocialImageUrl { get; set; } = string.Empty;

        [JsonPropertyName("socialimagetemplate")]
        public string SocialImageUrlTemplate { get; set; } = string.Empty;

        public ProgramCategory ProgramCategory { get; set; } = new ProgramCategory();
        
        public ProgramChannel Channel { get; set; } = new ProgramChannel();


        [JsonPropertyName("archived")]
        public bool IsArchived { get; set; }
        
        public bool HasOnDemand { get; set; }

        public bool HasPod { get; set; }

        public string ProgramSlug { get; set; } = string.Empty;
    }
}
