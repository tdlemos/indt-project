using Ambev.DeveloperEvaluation.Domain.Specifications;
using FluentAssertions;
using Indt.Proposta.Domain.Enums;
using Indt.Unit.Domain.Specifications.TestData;
using Xunit;

namespace Indt.Unit.Domain.Specifications
{
    public class ActiveUserSpecificationTests
    {
        [Theory]
        [InlineData(ProposalStatus.Active, true)]
        [InlineData(ProposalStatus.Inactive, false)]
        [InlineData(ProposalStatus.Suspended, false)]
        public void IsSatisfiedBy_ShouldValidateUserStatus(ProposalStatus status, bool expectedResult)
        {
            // Arrange
            var user = ActiveUserSpecificationTestData.GenerateUser(status);
            var specification = new ActiveUserSpecification();

            // Act
            var result = specification.IsSatisfiedBy(user);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
