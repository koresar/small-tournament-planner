
namespace Tournament_Planner.BL
{
    public class TournamentData
    {
        public PlayersCollection Players { get; private set; }

        public CompaniesCollection Companies { get; private set; }

        public TournamentData()
        {
            this.Players = new PlayersCollection();
            this.Companies = new CompaniesCollection();
        }
    }
}
