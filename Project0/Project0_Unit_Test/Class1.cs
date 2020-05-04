using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Project0;

namespace Project0_Unit_Test
{
    public class Class1
    {
		[Fact]
		public void UpdateQuantity_ProductInList_UpdatesQuantity()
		{

			Order order = new Order();
			Product newProd = new Product();
			order.AddToOrder(newProd, 1);

			bool result = order.UpdateQuantity(newProd, 5);



			Assert.True(result);
		}
	}
}
