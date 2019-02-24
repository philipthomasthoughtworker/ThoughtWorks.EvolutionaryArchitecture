namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools
{
    public interface CodeAnalysisTool
    {
        int GetCodeComplexityRating();
        bool GetDebugMode();
        int GetClassCountOverMaxNumberOfLinesAllowed(int maxNumberOfLinesAllowed);
    }
}
