namespace RPSLS
{
    public interface IScoreboard
    {
        PlayResponseDto[] GetRecentResults();
        void RegisterResult(PlayResponseDto result);
        void Reset();
    }
}