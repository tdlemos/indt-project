using Bogus;
using Indt.Proposta.Application.Propostas.Create;
using Indt.Proposta.Domain.Enums;

namespace Indt.Unit.Application.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateUserHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid User entities.
    /// The generated users will have valid:
    /// - Username (using internet usernames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<CreatePropostaCommand> createUserHandlerFaker = new Faker<CreatePropostaCommand>()
        .RuleFor(u => u.Username, f => f.Internet.UserName())
        .RuleFor(u => u.Password, f => $"Test@{f.Random.Number(100, 999)}")
        .RuleFor(u => u.Email, f => f.Internet.Email())
        .RuleFor(u => u.Phone, f => $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}")
        .RuleFor(u => u.Status, f => f.PickRandom(ProposalStatus.Active, ProposalStatus.Suspended))
        .RuleFor(u => u.Role, f => f.PickRandom(UserRole.Customer, UserRole.Admin));

    /// <summary>
    /// Generates a valid User entity with randomized data.
    /// The generated user will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid User entity with randomly generated data.</returns>
    public static CreatePropostaCommand GenerateValidCommand()
    {
        return createUserHandlerFaker.Generate();
    }
}
