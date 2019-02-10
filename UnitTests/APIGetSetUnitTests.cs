using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_DanceFellows.Data;
using API_DanceFellows.Models;
using API_DanceFellows.Models.Services;

namespace API_UnitTests
{
    public class APIGetSetUnitTests
    {
        //Time for a billion get/set tests!
        //Starting with Competitor...
        [Fact]
        public void CanGetIDOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.ID = 1;
            Assert.True(comp.ID == 1);
        }
        [Fact]
        public void CanSetIDOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.ID = 1;
            comp.ID = 2;
            Assert.True(comp.ID == 2);
        }
        [Fact]
        public void CanGetWSCDIDOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.WSDC_ID = 1;
            Assert.True(comp.WSDC_ID == 1);
        }
        [Fact]
        public void CanSetWSCDIDOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.WSDC_ID = 1;
            comp.WSDC_ID = 2;
            Assert.True(comp.WSDC_ID == 2);
        }
        [Fact]
        public void CanGetFirstNameOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.FirstName = "Foo";
            Assert.True(comp.FirstName == "Foo");
        }
        [Fact]
        public void CanSetFirstNameOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.FirstName = "Bar";
            comp.FirstName = "Foo";
            Assert.True(comp.FirstName == "Foo");
        }
        [Fact]
        public void CanGetLastNameOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.LastName = "Foo";
            Assert.True(comp.LastName == "Foo");
        }
        [Fact]
        public void CanSetLastNameOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.LastName = "Bar";
            comp.LastName = "Foo";
            Assert.True(comp.LastName == "Foo");
        }
        [Fact]
        public void CanGetMinLevelOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.MinLevel = Level.Novice;
            Assert.True(comp.MinLevel == Level.Novice);
        }
        [Fact]
        public void CanSetMinLevelOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.MinLevel = Level.AllStar;
            comp.MinLevel = Level.Novice;
            Assert.True(comp.MinLevel == Level.Novice);
        }
        [Fact]
        public void CanGetMaxLevelOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.MaxLevel = Level.Novice;
            Assert.True(comp.MaxLevel == Level.Novice);
        }
        [Fact]
        public void CanSetMaxLevelOfCompetitor()
        {
            Competitor comp = new Competitor();
            comp.MaxLevel = Level.AllStar;
            comp.MaxLevel = Level.Novice;
            Assert.True(comp.MaxLevel == Level.Novice);
        }
    }
}
