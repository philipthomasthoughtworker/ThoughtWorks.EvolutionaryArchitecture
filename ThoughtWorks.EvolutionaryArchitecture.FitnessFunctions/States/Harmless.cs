namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States
{
    public class Harmless : FunctionState
    {
        public override string Message(FunctionStateContext functionStateContext) =>
            $"{functionStateContext.ToString()} is in a harmless state.";
    }
}
