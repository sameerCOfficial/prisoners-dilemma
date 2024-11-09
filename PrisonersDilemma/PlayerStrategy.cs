namespace PrisonersDilemma
{
    public class PlayerStrategy
    {
        private Types.Strategy strategy;
        public PlayerStrategy(Types.Strategy strategy)
        {
            this.strategy = strategy;
        }

        public Types.Strategy GetStrategy()
        {
            return strategy;
        }

        public Types.Move GetMove(Types.Move player1Move)
        {
            return strategy switch
            {
                Types.Strategy.TFT => player1Move,
                Types.Strategy.CU => Types.Move.Cooperate,
                Types.Strategy.DU => Types.Move.Defect,
                _ => throw new InvalidOperationException("Unknown strategy")
            };
        }
    }
}
