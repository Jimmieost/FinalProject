using Bunit;
using FinalProject.Pages;
using System.Data;
using FinalProject;
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

        [Fact] // Testing the function to remove items from the shopping list
        public void ShoppingList_RemovingItem_RemovesItemFromList()
        {
            // Arrange
            var component = RenderComponent<ShoppingList>();
            var inputField = component.Find("input.inputField");
            var addButton = component.Find("button.add-button");
            inputField.Change("Test item");
            addButton.Click(); // Adding something to the list
            var removeButton = component.Find("button.removeitem");

            // Act
            removeButton.Click(); // Removing from the list

            // Assert
            var shoppingListItems = component.FindAll("li").ToList();
            Assert.Empty(shoppingListItems); // Checking if it's removed
        }

        [Fact]
        public void ShoppingList_IncrementingAmount_IncreasesAmount()
        {
            // Arrange
            var component = RenderComponent<ShoppingList>();
            var inputField = component.Find("input.inputField");
            var addButton = component.Find("button.add-button");
            inputField.Change("Test item");
            addButton.Click();
            var incrementButton = component.Find("button.increment");

            // Act
            incrementButton.Click();

            // Assert
            var amount = component.Find("p.amount").InnerHtml;
            Assert.Equal("1", amount);
        }

    }

}



