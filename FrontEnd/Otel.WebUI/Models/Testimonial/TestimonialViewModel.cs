namespace Otel.WebUI.Models.Testimonial
{
    public class TestimonialViewModel
    {
        public int TestimonialId { get; set; }

        public required string Name { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
    }
}

