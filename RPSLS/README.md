# billups coding challenge

This is the solution to the Rock Paper Scissors Lizard Spock coding challenge.

## Running from container

The containerized application can be built and run with the following command,
it will expose the application on `http://localhost:80` and remove the container after exiting

```bash
docker run -p 80:80 --rm -it $(docker build -q .)
```

Use `http://localhost` as the 'root URL' for https://codechallenge.boohma.com/

## Running from command line

Assuming the `dotnet` cli is installed, the solution can be run from the command line with the following command, 
this will run the web app and expose the api on the default url `http://localhost:5272`

```bash
dotnet run
```

Use `http://localhost:5272` as the 'root URL' for https://codechallenge.boohma.com/
