using NUnit.Framework;

namespace Training
{
	[TestFixture]
	public class Test19 : TestBase
	{
		[Test]
		public void CanAddAndDeleteProductsToCart()
		{
			var numberOfElements = 3;

			app.AddElementsToCart(numberOfElements);
			var productsInCart = app.GetNumberOfProductsInCart();
			Assert.True(productsInCart.Equals(numberOfElements.ToString()));

			app.DeleteAllFromCart();
		}
	}
}
