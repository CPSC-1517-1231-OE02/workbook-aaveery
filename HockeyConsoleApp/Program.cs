using HockeyClassLibrary.Data;

Console.WriteLine("Welcome to the HockeyPlayer Test App");

// initializing an object using the default constructor
HockeyPlayer player1 = new HockeyPlayer();
player1.FirstName = "Stewart";
player1.LastName = "Skinner";

// object-initializer - initializaing some of the properties and using default constructor values for the rest of them
HockeyPlayer player2 = new HockeyPlayer()
{
    FirstName = "Connor",
    LastName = "McDavid"
};

// initializing an object using the greedy constructor
HockeyPlayer player3 = new HockeyPlayer("Bobby", "Orr", "Parry Sound", new DateOnly(1948, 03, 20), 196, 73, Position.Defense, Shot.Right);

// output things bout the playerrs
Console.WriteLine($"The player's name is {player1.FirstName} {player1.LastName} and they are born on {player1.DateOfBirth}.");
Console.WriteLine($"The player's name is {player2.FirstName} {player2.LastName} and they are born on {player2.DateOfBirth}.");
Console.WriteLine($"The player's name is {player3.FirstName} {player3.LastName} and they are born on {player3.DateOfBirth}.");