﻿using Azure_Pipeline_Demo.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Pipeline_Demo.Model.DAL.Contract;

public interface IBookRepo
{
    Task<ActionResult<IEnumerable<Book>>> GetBooks();
    Task<ActionResult<Book>> GetBook(int id);
    Task<IActionResult> PutBook(int id, Book book);
    Task<ActionResult<Book>> PostBook(Book book);
    Task<IActionResult> DeleteBook(int id);
}
