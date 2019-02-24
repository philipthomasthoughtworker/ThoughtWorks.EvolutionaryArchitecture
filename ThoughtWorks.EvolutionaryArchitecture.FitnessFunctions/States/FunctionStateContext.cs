namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States
{
    public class FunctionStateContext
    {
        FunctionState currentState = new Harmless();

        public void SetState(FunctionState functionState) => currentState = functionState;
        public FunctionState GetState() => currentState;
        public string GetStateMessage() => currentState.Message(this);
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
