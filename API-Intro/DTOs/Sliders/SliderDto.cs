﻿using Swashbuckle.AspNetCore.Annotations;

namespace API_Intro.DTOs.Sliders
{
    public class SliderDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

       
        public string Image { get; set; }

    }
}
