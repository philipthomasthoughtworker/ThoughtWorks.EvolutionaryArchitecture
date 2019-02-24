using Xunit;
using Moq;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.States;
using ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tools;

namespace ThoughtWorks.EvolutionaryArchitecture.FitnessFunctions.Tests
{
    public class DebugModeTests
    {
        [Fact]
        public void HarmlessState_DebugModeState_EqualToThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetDebugMode()).Returns(true);

            var debugMode = new DebugMode(codeAnalysisToolMock.Object);
            var stateContext = debugMode.Check(true);

            Assert.IsType<Harmless>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a harmless state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetDebugMode(), Times.Once);
        }

        [Fact]
        public void ToxicState_DebugModeState_NotEqualToThreshold_Test()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var codeAnalysisToolMock = mockRepository.Create<CodeAnalysisTool>();
            codeAnalysisToolMock.Setup(x => x.GetDebugMode()).Returns(true);

            var debugMode = new DebugMode(codeAnalysisToolMock.Object);
            var stateContext = debugMode.Check(false);

            Assert.IsType<Toxic>(stateContext.GetState());
            Assert.Equal($"{stateContext.GetType().Name} is in a toxic state.", stateContext.GetStateMessage());

            codeAnalysisToolMock.Verify(x => x.GetDebugMode(), Times.Once);
        }
    }
}
