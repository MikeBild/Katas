namespace KataTennis
{
    public class TennisGame
    {
        public PlayerScore PlayerOne { get; set; }
        public PlayerScore PlayerTwo { get; set; }

        public bool Finished { get; set; }

        public TennisGame()
        {
            PlayerOne = new PlayerScore();
            PlayerTwo = new PlayerScore();
        }
        public void Win(PlayerScore player)
        {
            if (Finished) return;

            if (IsPlayerTwoAdvantage(player))
            {
                this.PlayerTwo.RemovePoints();
                return;
            }

            if (IsPlayerOneAdvantage(player))
            {
                this.PlayerOne.RemovePoints();
                return;
            }

            AddPointsWhenPlayerHasNoAdvantage(player);
            AddPointsToPlayer(player);
            FinishGame();
        }

        private void AddPointsToPlayer(PlayerScore player)
        {
            player.AddPoints();
        }
        private bool IsPlayerTwoAdvantage(PlayerScore player)
        {
            return (player == this.PlayerOne && this.PlayerOne.Points == Points.Forty && this.PlayerTwo.Points == Points.Advantage);
        }
        private bool IsPlayerOneAdvantage(PlayerScore player)
        {
            return (player == this.PlayerTwo && this.PlayerTwo.Points == Points.Forty && this.PlayerOne.Points == Points.Advantage);

        }
        private void FinishGame()
        {
            if (PlayerOne.Points == Points.Game || PlayerTwo.Points == Points.Game)
                Finished = true;
        }
        private void AddPointsWhenPlayerHasNoAdvantage(PlayerScore player)
        {
            if (player.Points == Points.Forty && PlayerTwo.Points < Points.Forty
                ||
                player.Points == Points.Forty && PlayerOne.Points < Points.Forty)
            {
                player.AddPoints();
            }
        }
    }
}