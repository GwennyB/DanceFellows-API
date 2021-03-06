﻿using System;
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
        //Result
        [Fact]
        public void CanGetPlacementOfResult()
        {
            Result result = new Result();
            result.Placement = Placement.Finalled;
            Assert.True(result.Placement == Placement.Finalled);
        }
        [Fact]
        public void CanSetPlacementOfResult()
        {
            Result result = new Result();
            result.Placement = Placement.Position2;
            result.Placement = Placement.Finalled;
            Assert.True(result.Placement == Placement.Finalled);
        }
        [Fact]
        public void CanGetRoleOfResult()
        {
            Result result = new Result();
            result.Role = Role.Follow;
            Assert.True(result.Role == Role.Follow);
        }
        [Fact]
        public void CanSetRoleOfResult()
        {
            Result result = new Result();
            result.Role = Role.Lead;
            result.Role = Role.Follow;
            Assert.True(result.Role == Role.Follow);
        }
        [Fact]
        public void CanGetChiefScoreInResult()
        {
            Result result = new Result();
            result.ScoreChief = 1;
            Assert.True(result.ScoreChief == 1);
        }
        [Fact]
        public void CanSetChiefScoreInResult()
        {
            Result result = new Result();
            result.ScoreChief = 7;
            result.ScoreChief = 1;
            Assert.True(result.ScoreChief == 1);
        }
        [Fact]
        public void CanGetScoreOneInResult()
        {
            Result result = new Result();
            result.ScoreOne = 1;
            Assert.True(result.ScoreOne == 1);
        }
        [Fact]
        public void CanSetScoreOneInResult()
        {
            Result result = new Result();
            result.ScoreOne = 7;
            result.ScoreOne = 1;
            Assert.True(result.ScoreOne == 1);
        }
        [Fact]
        public void CanGetScoreTwoInResult()
        {
            Result result = new Result();
            result.ScoreTwo = 1;
            Assert.True(result.ScoreTwo == 1);
        }
        [Fact]
        public void CanSetScoreTwoInResult()
        {
            Result result = new Result();
            result.ScoreTwo = 7;
            result.ScoreTwo = 1;
            Assert.True(result.ScoreTwo == 1);
        }
        [Fact]
        public void CanGetScoreThreeInResult()
        {
            Result result = new Result();
            result.ScoreThree = 1;
            Assert.True(result.ScoreThree == 1);
        }
        [Fact]
        public void CanSetScoreThreeInResult()
        {
            Result result = new Result();
            result.ScoreThree = 7;
            result.ScoreThree = 1;
            Assert.True(result.ScoreThree == 1);
        }
        [Fact]
        public void CanGetScoreFourInResult()
        {
            Result result = new Result();
            result.ScoreFour = 1;
            Assert.True(result.ScoreFour == 1);
        }
        [Fact]
        public void CanSetScoreFourInResult()
        {
            Result result = new Result();
            result.ScoreFour = 7;
            result.ScoreFour = 1;
            Assert.True(result.ScoreFour == 1);
        }
        [Fact]
        public void CanGetScoreFiveInResult()
        {
            Result result = new Result();
            result.ScoreFive = 1;
            Assert.True(result.ScoreFive == 1);
        }
        [Fact]
        public void CanSetScoreFiveInResult()
        {
            Result result = new Result();
            result.ScoreFive = 7;
            result.ScoreFive = 1;
            Assert.True(result.ScoreFive == 1);
        }
        [Fact]
        public void CanGetScoreSixInResult()
        {
            Result result = new Result();
            result.ScoreSix = 1;
            Assert.True(result.ScoreSix == 1);
        }
        [Fact]
        public void CanSetScoreSixInResult()
        {
            Result result = new Result();
            result.ScoreSix = 7;
            result.ScoreSix = 1;
            Assert.True(result.ScoreSix == 1);
        }
        [Fact]
        public void CanGetECIDInResult()
        {
            Result result = new Result();
            result.EventCompetitionID = 1;
            Assert.True(result.EventCompetitionID == 1);
        }
        [Fact]
        public void CanSetECIDInResult()
        {
            Result result = new Result();
            result.EventCompetitionID = 7;
            result.EventCompetitionID = 1;
            Assert.True(result.EventCompetitionID == 1);
        }
        [Fact]
        public void CanGetCompIDInResult()
        {
            Result result = new Result();
            result.CompetitorID = 1;
            Assert.True(result.CompetitorID == 1);
        }
        [Fact]
        public void CanSetCompIDInResult()
        {
            Result result = new Result();
            result.CompetitorID = 7;
            result.CompetitorID = 1;
            Assert.True(result.CompetitorID == 1);
        }
        [Fact]
        public void CanGetCompetitorInResult()
        {
            Result result = new Result();
            Competitor competitor = new Competitor();
            competitor.ID = 1;
            result.Competitor = competitor;
            Assert.True(result.Competitor.ID == 1);
        }
        [Fact]
        public void CanSetCompetitorInResult()
        {
            Result result = new Result();
            Competitor competitor = new Competitor();
            competitor.ID = 2;
            result.Competitor = competitor;
            competitor.ID = 1;
            result.Competitor = competitor;
            Assert.True(result.Competitor.ID == 1);
        }
        [Fact]
        public void CanGetEventCompetitionInResult()
        {
            Result result = new Result();
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.ID = 1;
            result.EventCompetition = eventCompetition;
            Assert.True(result.EventCompetition.ID == 1);
        }
        [Fact]
        public void CanSetEventCompetitionInResult()
        {
            Result result = new Result();
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.ID = 2;
            result.EventCompetition = eventCompetition;
            eventCompetition.ID = 1;
            result.EventCompetition = eventCompetition;
            Assert.True(result.EventCompetition.ID == 1);
        }
        //Event
        [Fact]
        public void CanGetIDInEvent()
        {
            Event newEvent = new Event();
            newEvent.ID = 1;
            Assert.True(newEvent.ID == 1);
        }
        [Fact]
        public void CanSetIDInEvent()
        {
            Event newEvent = new Event();
            newEvent.ID = 2;
            newEvent.ID = 1;
            Assert.True(newEvent.ID == 1);
        }
        [Fact]
        public void CanGetYearInEvent()
        {
            Event newEvent = new Event();
            newEvent.Year = 1;
            Assert.True(newEvent.Year == 1);
        }
        [Fact]
        public void CanSetYearInEvent()
        {
            Event newEvent = new Event();
            newEvent.Year = 2;
            newEvent.Year = 1;
            Assert.True(newEvent.Year == 1);
        }
        [Fact]
        public void CanGetDirectorInEvent()
        {
            Event newEvent = new Event();
            newEvent.Director = "Foo";
            Assert.True(newEvent.Director == "Foo");
        }
        [Fact]
        public void CanSetDirectorInEvent()
        {
            Event newEvent = new Event();
            newEvent.Director = "Bar";
            newEvent.Director = "Foo";
            Assert.True(newEvent.Director == "Foo");
        }
        [Fact]
        public void CanGetSeriesIDInEvent()
        {
            Event newEvent = new Event();
            newEvent.SeriesID = 1;
            Assert.True(newEvent.SeriesID == 1);
        }
        [Fact]
        public void CanSetSeriesIDInEvent()
        {
            Event newEvent = new Event();
            newEvent.SeriesID = 2;
            newEvent.SeriesID = 1;
            Assert.True(newEvent.SeriesID == 1);
        }
        [Fact]
        public void CanGetEventCompetitionsFromEvent()
        {
            Event newEvent = new Event();
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.ID = 1;
            List<EventCompetition> eventCompetitions = new List<EventCompetition>();
            eventCompetitions.Add(eventCompetition);
            newEvent.EventCompetitions = eventCompetitions;
            Assert.True(newEvent.EventCompetitions.Contains(eventCompetition));
        }
        //bit of a mess here, tough to "update" something in a list much less a collection
        [Fact]
        public void CanSetEventCompetitionsFromEvent()
        {
            Event newEvent = new Event();
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.ID = 1;
            List<EventCompetition> eventCompetitions = new List<EventCompetition>();
            eventCompetitions.Add(eventCompetition);
            newEvent.EventCompetitions = eventCompetitions;
            eventCompetition.ID = 2;
            eventCompetitions.Remove(eventCompetition);
            eventCompetitions.Add(eventCompetition);
            newEvent.EventCompetitions = eventCompetitions;
            Assert.True(newEvent.EventCompetitions.Contains(eventCompetition));
        }
        [Fact]
        public void CanGetSeriesFromEvent()
        {
            Event newEvent = new Event();
            Series series = new Series();
            series.ID = 1;
            newEvent.Series = series;
            Assert.True(newEvent.Series.ID == 1);
        }
        [Fact]
        public void CanSetSeriesInEvent()
        {
            Event newEvent = new Event();
            Series series = new Series();
            series.ID = 2;
            newEvent.Series = series;
            series.ID = 1;
            newEvent.Series = series;
            Assert.True(newEvent.Series.ID == 1);
        }
        //EventCompetition
        [Fact]
        public void CanGetIDInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.ID = 1;
            Assert.True(eventCompetition.ID == 1);
        }
        [Fact]
        public void CanSetIDInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.ID = 2;
            eventCompetition.ID = 1;
            Assert.True(eventCompetition.ID == 1);
        }
        [Fact]
        public void CanGetEventIDInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.EventID = 1;
            Assert.True(eventCompetition.EventID == 1);
        }
        [Fact]
        public void CanSetEventIDInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.EventID = 2;
            eventCompetition.EventID = 1;
            Assert.True(eventCompetition.EventID == 1);
        }
        [Fact]
        public void CanGetCompTypeInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.CompType = CompType.Classic;
            Assert.True(eventCompetition.CompType == CompType.Classic);
        }
        [Fact]
        public void CanSetCompTypeInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.CompType = CompType.JackAndJill;
            eventCompetition.CompType = CompType.Classic;
            Assert.True(eventCompetition.CompType == CompType.Classic);
        }
        [Fact]
        public void CanGetLevelInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.Level = Level.Newcomer;
            Assert.True(eventCompetition.Level == Level.Newcomer);
        }
        [Fact]
        public void CanSetLevelInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            eventCompetition.Level = Level.AllStar;
            eventCompetition.Level = Level.Newcomer;
            Assert.True(eventCompetition.Level == Level.Newcomer);
        }
        [Fact]
        public void CanGetEventFromEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            Event newEvent = new Event();
            newEvent.ID = 1;
            eventCompetition.Event = newEvent;
            Assert.True(eventCompetition.Event.ID == 1);
        }
        [Fact]
        public void CanSetEventInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            Event newEvent = new Event();
            newEvent.ID = 2;
            eventCompetition.Event = newEvent;
            newEvent.ID = 1;
            eventCompetition.Event = newEvent;
            Assert.True(eventCompetition.Event.ID == 1);
        }
        [Fact]
        public void CanGetResultsFromEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            Result result = new Result();
            result.CompetitorID = 1;
            List<Result> results = new List<Result>();
            results.Add(result);
            eventCompetition.Results = results;
            Assert.True(eventCompetition.Results.Contains(result));
        }
        [Fact]
        public void CanSetResultsInEventCompetition()
        {
            EventCompetition eventCompetition = new EventCompetition();
            Result result = new Result();
            List<Result> results = new List<Result>();
            result.CompetitorID = 1;
            results.Add(result);
            eventCompetition.Results = results;
            result.CompetitorID = 2;
            results.Add(result);
            eventCompetition.Results = results;
            Assert.True(eventCompetition.Results.Contains(result));
        }
        //And finally Series
        [Fact]
        public void CanGetIDInSeries()
        {
            Series series = new Series();
            series.ID = 1;
            Assert.True(series.ID == 1);
        }
        [Fact]
        public void CanSetIDInSeries()
        {
            Series series = new Series();
            series.ID = 2;
            series.ID = 1;
            Assert.True(series.ID == 1);
        }
        [Fact]
        public void CanGetNameInSeries()
        {
            Series series = new Series();
            series.Name = "Foo";
            Assert.True(series.Name == "Foo");
        }
        [Fact]
        public void CanSetNameInSeries()
        {
            Series series = new Series();
            series.Name = "Bar";
            series.Name = "Foo";
            Assert.True(series.Name == "Foo");
        }
        [Fact]
        public void CanGetLocationInSeries()
        {
            Series series = new Series();
            series.Location = "Foo";
            Assert.True(series.Location == "Foo");
        }
        [Fact]
        public void CanSetLocationInSeries()
        {
            Series series = new Series();
            series.Location = "Bar";
            series.Location = "Foo";
            Assert.True(series.Location == "Foo");
        }
        [Fact]
        public void CanGetEventFromSeries()
        {
            Series series = new Series();
            List<Event> seriesEvents = new List<Event>();
            Event newEvent = new Event();
            newEvent.ID = 1;
            seriesEvents.Add(newEvent);
            series.SeriesEvents = seriesEvents;
            Assert.True(series.SeriesEvents.Contains(newEvent));
        }
        [Fact]
        public void CanSetEventFromSeries()
        {
            Series series = new Series();
            List<Event> seriesEvents = new List<Event>();
            Event newEvent = new Event();
            newEvent.ID = 1;
            seriesEvents.Add(newEvent);
            series.SeriesEvents = seriesEvents;
            newEvent.ID = 2;
            seriesEvents.Add(newEvent);
            series.SeriesEvents = seriesEvents;
            Assert.True(series.SeriesEvents.Contains(newEvent));
        }
    }
}
