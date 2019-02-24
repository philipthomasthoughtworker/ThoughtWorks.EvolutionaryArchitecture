using Xunit;
using Moq;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.CodeQuality;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tests
{
    public class LinesOfCodeTests
    {
        [Fact]
        public void HarmlessState_ClassCountOverMaxNumberOfLinesAllowed_Is_LowerThanThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetClassCountOverMaxNumberOfLinesAllowed(500)).Returns(5);

            var linesOfCode = new LinesOfCode(codeAnalysisToolMock.Object, 500);
            var stateContext = linesOfCode.Check(10);

            Assert.IsType<Harmless>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a harmless state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetClassCountOverMaxNumberOfLinesAllowed(500), Times.Once);
        }

        [Fact]
        public void ToxicState_ClassCountOverMaxNumberOfLinesAllowed_Is_GreaterThanThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetClassCountOverMaxNumberOfLinesAllowed(500)).Returns(10);

            var linesOfCode = new LinesOfCode(codeAnalysisToolMock.Object, 500);
            var stateContext = linesOfCode.Check(5);

            Assert.IsType<Toxic>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a toxic state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetClassCountOverMaxNumberOfLinesAllowed(500), Times.Once);
        }

        [Fact]
        public void WarningState_ClassCountOverMaxNumberOfLinesAllowed_Is_EqualToThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetClassCountOverMaxNumberOfLinesAllowed(500)).Returns(10);

            var linesOfCode = new LinesOfCode(codeAnalysisToolMock.Object, 500);
            var stateContext = linesOfCode.Check(10);

            Assert.IsType<Warning>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a warning state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetClassCountOverMaxNumberOfLinesAllowed(500), Times.Once);
        }
    }
}
