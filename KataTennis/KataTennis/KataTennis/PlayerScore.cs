

namespace KataTennis
{
    public class PlayerScore
    {
        public Points Points { get; private set; }
        public void AddPoints()
        {
            Points++;
        }
        public void RemovePoints()
        {
            Points--;
        }

    }
}