using FluentAssertions;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Core.Domain.Validation;
using System;
using Xunit;

namespace RendaSolidaria.Core.Domain.Tests
{
    public class UserUnitTests
    {
        [Fact(DisplayName = "Create a Valid User")]
        public void InsertUser_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new User("Bruneca");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Invalid Category with empty name")]
        public void InsertUser_WithEmptyName_ResultDomainExceptionInvalidName()
        {
            Action action = () => new User("");
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
