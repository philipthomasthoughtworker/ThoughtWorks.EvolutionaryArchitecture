using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions
{
    public abstract class Metric<ThresholdType>
    {
        public abstract FunctionStateContext Check(ThresholdType threshold);
    }
}
