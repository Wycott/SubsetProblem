using Xunit;

namespace SubsetProblem.Test
{
    public class CandidateTest
    {
        [Fact]
        public void Candidate_WhenRun_TheResultShouldBeAsExpected()
        {
            // Arrange
            const string TestGuid = "bdbdfa8b-ab51-484f-9aa3-a2c795be1326";
            const int ExpectedSourceNumberSet = 13;
            const int ExpectedTargetSolutionSet = 82;
            const int ExpectedTargetSum = 61;

            // Act
            var candidate = new Candidate(TestGuid);

            // Assert
            Assert.Equal(ExpectedSourceNumberSet, candidate.SourceNumberSet.Count);
            Assert.Equal(ExpectedTargetSolutionSet, candidate.TargetSolutionSet.Count);
            Assert.Equal(ExpectedTargetSum, candidate.TargetSum);
            Assert.True(candidate.RawGuid == TestGuid);
        }
    }
}
