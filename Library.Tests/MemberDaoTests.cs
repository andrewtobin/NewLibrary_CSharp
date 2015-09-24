﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Daos;
using Library.Interfaces.Entities;
using NSubstitute;
using Xunit;

namespace Library.Tests
{
    [Trait("Category", "Member Tests")]
    public class MemberDaoTests
    {
        [Fact]
        public void CanCreateMemberDao()
        {
            var helper = Substitute.For<IMemberHelper>();

            var memberDao = new MemberDao(helper);

            Assert.NotNull(memberDao);
        }
    }
}
