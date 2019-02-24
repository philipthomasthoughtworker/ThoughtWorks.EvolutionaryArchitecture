using Xunit;
using Moq;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tests
{

    public class CodeComplexityTests
    {

        [Fact]
        public void HarmlessState_CodeComplexityRating_Is_LowerThanThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetCodeComplexityRating()).Returns(0);

            var codeComplexity = new CodeComplexity(codeAnalysisToolMock.Object);
            var stateContext = codeComplexity.Check(100);

            Assert.IsType<Harmless>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a harmless state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetCodeComplexityRating(), Times.Once);
        }

        [Fact]
        public void ToxicState_CodeComplexityRating_Is_HigherThanThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetCodeComplexityRating()).Returns(101);

            var codeComplexity = new CodeComplexity(codeAnalysisToolMock.Object);
            var stateContext = codeComplexity.Check(100);

            Assert.IsType<Toxic>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a toxic state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetCodeComplexityRating(), Times.Once);
        }

        [Fact]
        public void WarningState_CodeComplexityRating_Is_EqualToThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetCodeComplexityRating()).Returns(100);

            var codeComplexity = new CodeComplexity(codeAnalysisToolMock.Object);
            var stateContext = codeComplexity.Check(100);

            Assert.IsType<Warning>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a warning state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetCodeComplexityRating(), Times.Once);
        }
    }
}
