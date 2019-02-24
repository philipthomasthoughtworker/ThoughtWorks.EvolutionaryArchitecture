using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions
{
    public class CodeComplexity : Metric<int>
    {
        CodeAnalysisTool codeAnalysisTool;

        public CodeComplexity(CodeAnalysisTool codeAnalysisTool)
        {
            this.codeAnalysisTool = codeAnalysisTool;
        }

        public override FunctionStateContext Check(int threshold)
        {
            var stateContext = new FunctionStateContext();
            var codeComplexityRating = codeAnalysisTool.GetCodeComplexityRating();

            if (IsRatingGreatherThreshold(threshold, codeComplexityRating))
                stateContext.SetState(new Toxic());
            else if (IsRatingLessThanThreshold(threshold, codeComplexityRating))
                stateContext.SetState(new Harmless());
            else
                stateContext.SetState(new Warning());

            return stateContext;
        }

        bool IsRatingLessThanThreshold(int threshold, int codeComplexityRating)
        {
            return codeComplexityRating < threshold;
        }

        bool IsRatingGreatherThreshold(int threshold, int codeComplexityRating)
        {
            return codeComplexityRating > threshold;
        }
    }
}
