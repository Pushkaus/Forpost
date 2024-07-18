using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Forpost.Business;
using Forpost.Business.Mappers;

namespace Forpost.UnitTests;

public abstract class BaseUnitTest
{
    protected IFixture AutoFixture = new Fixture().Customize(new AutoMoqCustomization());

    public BaseUnitTest()
    {
        var mapper =  new MapperConfiguration(configuration =>
            {
                var profiles = BusinessAssemblyReference.Assembly.Types()
                    .Where(type => typeof(Profile).IsAssignableFrom(type));
                foreach (var profile in profiles)
                {
                    configuration.AddProfile(profile);
                }
            }).CreateMapper(); 
        AutoFixture.Register(() => mapper);
    }    
}