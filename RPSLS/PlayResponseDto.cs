#nullable disable

namespace RPSLS
{
    public class PlayResponseDto
    {
        public string results { get; set; }
        public EChoice player { get; set; }
        public EChoice computer { get; set; }
    }
}
