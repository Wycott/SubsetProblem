using System;
using Xunit;

namespace SubsetProblem.Test
{
    public class CandidateTest
    {
        [Fact]
        public void Oddity_One()
        {            
            var testGuid = "346f0902-291a-468e-b149-658646141a35";
            var candidate = new Candidate(testGuid);
            var gss = candidate.GetSolveSet();
            var gdns = candidate.GetDisplayNumberSet();

            Assert.True(candidate.RawGuid == testGuid);
        }

        [Fact]
        public void Oddity_Two()
        {            
            var testGuid = "69671131-7ee5-421f-932e-85ee756ef5e6";

            var candidate = new Candidate(testGuid);
            var gss = candidate.GetSolveSet();
            var gdns = candidate.GetDisplayNumberSet();
            Assert.True(candidate.RawGuid == testGuid);
        }

        [Fact]
        public void Oddity_Three()
        {
            var testGuid = "03ff6505-7801-4f57-83e6-13189362060b";

            var candidate = new Candidate(testGuid);
            var gss = candidate.GetSolveSet();
            var gdns = candidate.GetDisplayNumberSet();
            Assert.True(candidate.RawGuid == testGuid);
        }

        [Fact]
        public void Oddity_Four()
        {
            var testGuid = "bdbdfa8b-ab51-484f-9aa3-a2c795be1326";

            var candidate = new Candidate(testGuid);
            var gss = candidate.GetSolveSet();
            var gdns = candidate.GetDisplayNumberSet();
            Assert.True(candidate.RawGuid == testGuid);
        }

        //bdbdfa8b-ab51-484f-9aa3-a2c795be1326
    }
}
