﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Library.Interfaces.Entities;
using NSubstitute;
using Xunit;

namespace Library.Tests.UnitTests
{
    [Trait("Category", "Loan Tests")]
    public class LoanStateTests
    {
        [Fact]
        public void WhenLoanIsCreatedShouldBePending()
        {
            var book = Substitute.For<IBook>();
            var member = Substitute.For<IMember>();
            DateTime borrowDate = DateTime.Today;
            DateTime dueDate = DateTime.Today;

            var loan = new Loan(book, member, borrowDate, dueDate);

            Assert.Equal(LoanState.PENDING, loan.State);
        }
    }
}
