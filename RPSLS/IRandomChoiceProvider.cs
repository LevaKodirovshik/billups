
namespace RPSLS
{
    public interface IRandomChoiceProvider
    {
        Task<EChoice> GetRandomChoice();
    }
}