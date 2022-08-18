#nullable disable

namespace RPSLS
{
    public class ChoiceDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public static explicit operator EChoice(ChoiceDto choiceDto) => (EChoice)choiceDto.id;
        public static explicit operator ChoiceDto(EChoice choice) => new ChoiceDto() { id = (int)choice, name = choice.ToString() };
    }
}
