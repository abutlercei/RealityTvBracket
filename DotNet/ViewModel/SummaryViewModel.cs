namespace DotNet.Models.ViewModels
{
    public class SummaryViewModel
    {
        public int? SingleContestantPoints { get; set; }
        public double? SingleContestantAverageRank { get; set; }
        public int? BracketPoints { get; set; }
        public string? BracketTotalAccuracy { get; set; }
        public List<Pool>? AllPools { get; set; }

        public SummaryViewModel MapToSummaryViewModel
            (List<Pool> pools, String username)
        {
            return new SummaryViewModel
            {
                SingleContestantPoints = pools
                      .Where(p => !p.IsBracketStyle)
                      .Sum(p =>
                      p.Members.Sum(m => m.UsernameFK == username ? m.Points : 0)),

                SingleContestantAverageRank = pools
                      .Where(p => !p.IsBracketStyle && p.Members.Any())
                      .Average(p =>
                      p.Members.Average(m => m.UsernameFK == username ? m.Rank : null)),

                BracketPoints = pools
                      .Where(p => p.IsBracketStyle)
                      .Sum(p => p.Brackets.Sum(b => b.UserFK == username ? b.Points : 0)),

                BracketTotalAccuracy = $"{pools
                      .Where(p => p.IsBracketStyle)
                      .Sum(p => p.Brackets
                      .Count(b => b.IsCorrect == true && b.UserFK == username))} / {pools
                      .Where(p => p.IsBracketStyle)
                      .Sum(p => p.Brackets.Max(b => b.UserFK == username ? b.OrderOut : null))}",

                AllPools = pools
            };
        }

    }
}