using System.Collections.Generic;
using Xunit;

namespace Yatzy.Tests
{
    public class CategoryTests
    {
         [Theory]
         [InlineData("yatzy")]
         public void ShouldRemoveCategoryForCategoriesCollection(string categoryName)
         {
            var category = new Category();
            
            Assert.Contains(category.Categories, x => x == categoryName);
            category.RemoveCategory(categoryName);
            Assert.DoesNotContain(category.Categories, x => x == categoryName);
         }

         [Fact]
         public void ShouldCreateCategoriesList()
         {
             var category = new Category();
             Assert.True(category.Categories.Count > 0);
         }

         [Fact]
         public void ShouldReturnTrue_ForValidUserInput()
         {
             var category = new Category();
             Assert.True(category.ValidateCategoryInput("yatzy"));
         }

         [Fact]
         public void ShouldReturnFalse_ForInValidUserInput()
         {
             var category = new Category();
             Assert.False(category.ValidateCategoryInput("atzy"));
         }

    }
}