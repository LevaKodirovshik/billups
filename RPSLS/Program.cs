using RPSLS;

var builder = WebApplication.CreateBuilder(args);
// add it as a singleton so that the HttpClient inside can be reused and not instantiate more clients unecessarily
builder.Services.AddSingleton<IRandomChoiceProvider, RandomChoiceProvider>();
builder.Services.AddSingleton<IScoreboard, Scoreboard>();

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.WithOrigins("https://codechallenge.boohma.com", "http://localhost", "http://localhost:5272");
        p.WithHeaders("content-type");
    });
});

var app = builder.Build();

app.MapGet("/choices", () => Enum.GetValues<EChoice>().Select(e => (ChoiceDto)e).ToArray());
app.MapGet("/choice", async (IRandomChoiceProvider choiceProvider) =>
{
    var theReturn = await choiceProvider.GetRandomChoice();
    return (ChoiceDto)theReturn;
});
app.MapPost("/play", async (PlayRequestDto request
    , IRandomChoiceProvider choiceProvider
    , IScoreboard Scoreboard) =>
{
    var computerChoice = await choiceProvider.GetRandomChoice();
    var playResult = request.player.Play(computerChoice);
    var theReturn = new PlayResponseDto()
    {
        player = request.player,
        computer = computerChoice,
        results = playResult.ToString()
    };
    Scoreboard.RegisterResult(theReturn);
    return theReturn;
});

app.MapPost("/resetScoreboard", (IScoreboard scoreboard) => scoreboard.Reset());
app.MapGet("/scoreboard", (IScoreboard scoreboard) => scoreboard.GetRecentResults());

app.UseCors();

app.Run();
// docker run -p 80 --rm -it $(docker build -q .) 
