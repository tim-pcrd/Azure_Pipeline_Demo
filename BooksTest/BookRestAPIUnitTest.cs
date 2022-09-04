using Azure_Pipeline_Demo.Controllers;
using Azure_Pipeline_Demo.Model.DAL.Contract;
using Azure_Pipeline_Demo.Model.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksTest;
public class BookRestAPIUnitTest
{
    private BooksController booksController;
    private int Id = 1;
    private readonly Mock<IBookRepo> bookStub = new Mock<IBookRepo>();
    Book sampleBook = new Book
    {
        Id = 1,
        Name = "State Patsy",
        Genre = "Action/Adventure",
        PublisherName = "Queens",
    };
    Book toBePostedBook = new Book
    {
        Name = "Federal Matters",
        Genre = "Suspense",
        PublisherName = "Harpers",
    };

    [Fact]
    public async Task GetBook_BasedOnId_WithNoExistingBook_ReturnNotFound()
    {
        //Arrange
        booksController = new BooksController(bookStub.Object);
        bookStub.Setup(repo => repo.GetBook(It.IsAny<int>())).ReturnsAsync(new NotFoundResult());

        //Act
        var actionResult = await booksController.GetBook(1);

        //Assert
        Assert.IsType<NotFoundResult>(actionResult.Result);

    }

    [Fact]
    public async Task GetBook_BasedOnId_WithExistingBook_ReturnBook()
    {
        //Arrange
        //use the mock to set up the test. we are basically telling here that whatever int id we pass to this method
        //it will always return a new Book object
        bookStub.Setup(service => service.GetBook(It.IsAny<int>())).ReturnsAsync(sampleBook);
        booksController = new BooksController(bookStub.Object);
        //Act
        var actionResult = await booksController.GetBook(1);
        //Assert
        Assert.IsType<Book>(actionResult.Value);
        var result = actionResult.Value;
        //Compare the result member by member
        sampleBook.Should().BeEquivalentTo(result,
            options => options.ComparingByMembers<Book>());
    }
    [Fact]
    public async Task PostVideoGame_WithNewVideogame_ReturnNewlyCreatedVideogame()
    {
        //Arrange
        bookStub.Setup(repo => repo.PostBook(It.IsAny<Book>())).ReturnsAsync(sampleBook);

        booksController = new BooksController(bookStub.Object);
        //Act
        var actionResult = await booksController.PostBook(toBePostedBook);
        //Assert
        Assert.Equal("201", ((CreatedAtActionResult)actionResult.Result).StatusCode.ToString());

    }
}
