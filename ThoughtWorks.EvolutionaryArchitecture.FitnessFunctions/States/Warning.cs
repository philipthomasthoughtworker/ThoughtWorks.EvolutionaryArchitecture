namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States
{
    public class Warning : FunctionState
    {
        public override string Message(FunctionStateContext functionStateContext) =>

            $"{functionStateContext.ToString()} is in a warning state.";
    }
}
