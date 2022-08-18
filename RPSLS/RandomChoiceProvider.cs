namespace RPSLS
{
    public class RandomChoiceProvider : IRandomChoiceProvider
    {
        private readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://codechallenge.boohma.com/")
        };

        public async Task<EChoice> GetRandomChoice()
        {
            var generatedNumber = await _httpClient.GetFromJsonAsync<RandomNumberReturnDto>("random");
            // add 19 so that the range would be 20-119 not 1-100 simplifying further steps
            var randomNumber20to119 = generatedNumber!.random_number + 19;
            // integer division will truncate the result not round it, so it will be 1-5 which are the values of EChoice
            var randomNumber1to5 = randomNumber20to119 / 20;
            return (EChoice)(randomNumber1to5);
        }

        private class RandomNumberReturnDto
        {
            public int random_number { get; set; }
        }
    }
}
