﻿using FluentAssertions;

using Refit;

using Xunit;

namespace Refitter.Tests.AdditionalFiles;

public class SingleInterfaceGeneratorTest
{
    [Fact]
    public void Should_Type_Exist() =>
        typeof(SingeInterface.ISwaggerPetstore)
            .Namespace
            .Should()
            .Be("Refitter.Tests.AdditionalFiles.SingeInterface");

    [Fact]
    public void Can_Resolve_Refit_Interface() =>
        RestService.For<SingeInterface.ISwaggerPetstore>("https://petstore3.swagger.io/api/v3")
            .Should()
            .NotBeNull();
}