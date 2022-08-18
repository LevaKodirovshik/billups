namespace RPSLS
{
    public enum EChoice : byte
    {
        // start with 1 so that the default value of 0 would be undefined 
        // this means we can use Enum.IsDefined to validate cases when the value was not provided
        rock = 1,
        paper,
        scissors,
        lizard,
        spock
    }
}
