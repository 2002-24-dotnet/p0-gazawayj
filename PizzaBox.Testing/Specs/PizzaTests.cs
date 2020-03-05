using Xunit;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Testing.Specs
{
  public class PizzaTests
  {
    [Fact]
    public void Test_RepositoryGetPizza()
    {
      //ASSEMBLE
      var sut = new PizzaRepository();
      //ACT
      var actual = sut.Get();
      //ASSERT
      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }
  }
}