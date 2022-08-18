using Dawn;

namespace RPSLS
{
    public static class EChoiceExtensions
    {
        /// <summary>
        /// A dictionaty containing all the choices as the key
        /// the value is a hashset containing the choices that are beaten by the value
        /// </summary>
        /// <remarks>
        /// IReadOnly collections because they should not be editable
        /// HashSet to quickly and efficiently check is a choice is in the collection using the .Contains(...) method
        /// </remarks>
        public static IReadOnlyDictionary<EChoice, IReadOnlyCollection<EChoice>> ChoiceWins { get; } = new Dictionary<EChoice, IReadOnlyCollection<EChoice>>()
        {
            { EChoice.rock, new HashSet<EChoice>(){ EChoice.scissors, EChoice.lizard } },
            { EChoice.paper, new HashSet<EChoice>(){ EChoice.rock, EChoice.spock } },
            { EChoice.scissors, new HashSet<EChoice>(){ EChoice.lizard, EChoice.paper } },
            { EChoice.lizard, new HashSet<EChoice>(){ EChoice.paper, EChoice.spock } },
            { EChoice.spock, new HashSet<EChoice>(){ EChoice.scissors, EChoice.rock} }
        };

        public static EResult Play(this EChoice choice, EChoice opponentChoice)
        {
            Guard.Argument(choice, nameof(choice)).Defined();
            Guard.Argument(opponentChoice, nameof(opponentChoice)).Defined();

            // instead of using dictionary and hashset this can optimized by using a series of nested switch statements
            // this would be more performant but would look really ugly and would take longer to write
            if (choice == opponentChoice)
            {
                return EResult.tie;
            }

            if (ChoiceWins[choice].Contains(opponentChoice))
            {
                return EResult.win;
            }

            return EResult.lose;
        }
    }
}
