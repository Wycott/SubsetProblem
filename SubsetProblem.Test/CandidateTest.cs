using Xunit;

namespace SubsetProblem.Test
{
    // TODO:    These don't look finished. Assertions don't do
    //          anything useful.
    public class CandidateTest
    {
        [Fact]
        public void Oddity_One()
        {
            const string TestGuid = "346f0902-291a-468e-b149-658646141a35";

            var candidate = new Candidate(TestGuid);
            //var gss = candidate.GetSolveSet();
            //var gdns = candidate.GetDisplayNumberSet();

            Assert.True(candidate.RawGuid == TestGuid);
        }

        [Fact]
        public void Oddity_Two()
        {
            const string TestGuid = "69671131-7ee5-421f-932e-85ee756ef5e6";

            var candidate = new Candidate(TestGuid);
            //var gss = candidate.GetSolveSet();
            //var gdns = candidate.GetDisplayNumberSet();

            Assert.True(candidate.RawGuid == TestGuid);
        }

        [Fact]
        public void Oddity_Three()
        {
            const string TestGuid = "03ff6505-7801-4f57-83e6-13189362060b";

            var candidate = new Candidate(TestGuid);
            //var gss = candidate.GetSolveSet();
            //var gdns = candidate.GetDisplayNumberSet();

            Assert.True(candidate.RawGuid == TestGuid);
        }

        [Fact]
        public void Oddity_Four()
        {
            const string TestGuid = "bdbdfa8b-ab51-484f-9aa3-a2c795be1326";

            var candidate = new Candidate(TestGuid);
            //var gss = candidate.GetSolveSet();
            //var gdns = candidate.GetDisplayNumberSet();

            Assert.True(candidate.RawGuid == TestGuid);
        }
    }
}
