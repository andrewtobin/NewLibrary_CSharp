﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Library.Interfaces.Entities;
using Xunit;

namespace Library.Tests.Integration.Entity
{
    [Trait("Category", "Book Tests")]
    public class BookIntegration
    {
        [Fact]
        public void CanBorrowBook()
        {
            var book = new Book("author", "title", "call number", 1);
            var member = new Member("first", "last", "phone", "email", 1);

            var loan = new Loan(book, member, DateTime.Today, DateTime.Today.AddDays(7));

            // Associate the book with the loan.
            book.Borrow(loan);

            // Set book state to ON_LOAN - affected by GetLoanFromBookReturnsNullIfBookIsNotON_LOAN()
            book.State = BookState.ON_LOAN;

            Assert.Equal(loan, book.Loan);
        }

        [Fact]
        public void BorrowBookThrowsRuntimeExceptionIfBookIsNotCurrentlyAvailable()
        {
            // Set book state to something other than Available.
            var book = new Book("author", "title", "call number", 1) { State = BookState.LOST };
            var member = new Member("first", "last", "phone", "email", 1);

            var loan = new Loan(book, member, DateTime.Today, DateTime.Today.AddDays(7));

            // Associate the book with the loan.
            var ex = Assert.Throws<InvalidOperationException>(() => book.Borrow(loan));

            Assert.Equal("Cannot borrow a book that is not available", ex.Message);
        }

        [Fact]
        public void CanGetLoanFromBook()
        {
            var book = new Book("author", "title", "call number", 1);
            var member = new Member("first", "last", "phone", "email", 1);

            var loan = new Loan(book, member, DateTime.Today, DateTime.Today.AddDays(7));

            // Associate the book with the loan.
            book.Borrow(loan);

            // Set book state to ON_LOAN - affected by GetLoanFromBookReturnsNullIfBookIsNotON_LOAN()
            book.State = BookState.ON_LOAN;

            // Testing the getter on the book.
            var loanRetrieved = book.Loan;

            Assert.Equal(loan, loanRetrieved);
        }

    }
}
