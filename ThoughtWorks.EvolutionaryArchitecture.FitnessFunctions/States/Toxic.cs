namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States
{
    public class Toxic : FunctionState
    {
        public override string Message(FunctionStateContext functionStateContext) =>
            $"{functionStateContext.ToString()} is in a toxic state.";
    }

}
