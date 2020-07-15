namespace Game.GameLogic
{
    class Match         // Manages match related logic (for now just the end)
    {
        public bool MatchInProgress { get; private set; } = true;

        public void EndMatch()         // Finishes the match
        {
            MatchInProgress = false;
        }
    }
}
