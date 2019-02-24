using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions
{
    public class DebugMode : Metric<bool>
    {
        CodeAnalysisTool codeAnalysisTool;

        public DebugMode(CodeAnalysisTool codeAnalysisTool)
        {
            this.codeAnalysisTool = codeAnalysisTool;
        }

        public override FunctionStateContext Check(bool threshold)
        {
            var stateContext = new FunctionStateContext();
            var debugMode = codeAnalysisTool.GetDebugMode();

            if (debugMode == threshold)
                stateContext.SetState(new Harmless());
            else
                stateContext.SetState(new Toxic());

            return stateContext;
        }
    }
}
