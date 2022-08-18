namespace RPSLS
{
    public class Scoreboard : IScoreboard
    {
        /// <summary>
        /// Use a list with a lock instead of a concurrent collection because we need to perform several operations when registering a result
        /// </summary>
        private readonly List<PlayResponseDto> _results = new List<PlayResponseDto>(10);
        public void RegisterResult(PlayResponseDto result)
        {
            lock (_results)
            {
                // if we already have 10 results, remove the oldest one
                if (_results.Count == 10)
                {
                    _results.RemoveAt(0);
                }
                _results.Add(result);
            }
        }

        public PlayResponseDto[] GetRecentResults()
        {
            lock (_results)
            {
                return _results.ToArray();
            }
        }

        public void Reset()
        {
            lock (_results)
            {
                _results.Clear();
            }
        }
    }
}
