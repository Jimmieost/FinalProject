using Bunit;
using FinalProject.Pages;
using System.Data;

namespace TestProject
{
	public class UnitTest1 : TestContext



	{

        [Fact] // Testing the function of adding items to the shopping list
        public void ShoppingList_AddToList_AddsItemToList()
        {
            // Arrange
            var component = RenderComponent<ShoppingList>();
            var inputField = component.Find("input.inputField");
            var addButton = component.Find("button.add-button");
            inputField.Change("Test item"); // Writing something to add to the list

            // Act
            addButton.Click(); // Adding to the list

            // Assert
            var shoppingListItems = component.FindAll("li").ToList();
            Assert.Single(shoppingListItems);
            Assert.Contains("Test item", shoppingListItems[0].InnerHtml); //Checking if it's added to the list
        }

       

    }
}




