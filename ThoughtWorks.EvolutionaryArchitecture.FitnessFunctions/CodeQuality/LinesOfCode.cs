using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.CodeQuality
{
    public class LinesOfCode : Metric<int>
    {
        CodeAnalysisTool codeAnalysisTool;
        int maxNumberOfLinesAllowed;

        public LinesOfCode(CodeAnalysisTool codeAnalysisTool,
            int maxNumberOfLinesAllowed)
        {
            this.codeAnalysisTool = codeAnalysisTool;
            this.maxNumberOfLinesAllowed = maxNumberOfLinesAllowed;
        }

        public override FunctionStateContext Check(int threshold)
        {
            var stateContext = new FunctionStateContext();
            var classCount = codeAnalysisTool.GetClassCountOverMaxNumberOfLinesAllowed(maxNumberOfLinesAllowed);

            if (IsClassCountLessThanThreshold(threshold, classCount))
                stateContext.SetState(new Harmless());
            else if (IsClassCountGreaterThanThreshold(threshold, classCount))
                stateContext.SetState(new Toxic());
            else
                stateContext.SetState(new Warning());

            return stateContext;
        }

        bool IsClassCountLessThanThreshold(int threshold, int classCount)
        {
            return classCount < threshold;
        }

        bool IsClassCountGreaterThanThreshold(int threshold, int classCount)
        {
            return classCount > threshold;
        }
    }
}
