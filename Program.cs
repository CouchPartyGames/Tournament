using System;
using Tournament;

namespace Tournament
{
    class Program
    {
        static void Main(string[] args)
        {

            Tournament tournay = new Tournament(new TournamentSettings());
            tournay.AddOpponent(new Opponent(1, "Bill"));
            tournay.AddOpponent(new Opponent(2, "Bob"));
            tournay.AddOpponent(new Opponent(3, "Steve"));
            //tournay.SetOpponents();
            Console.WriteLine(tournay.Opponents.Count);
            tournay.Generate();
        }
    }
}


/*
app.MapGet("/tournament");
app.Run();
*/
