using API_DanceFellows.Data;
using API_DanceFellows.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace API_DanceFellows.Models.Services
{
    public class CompetitorManagementService : ICompetitorManager
    {

        /// <summary>
        /// Standard context for repository design patterning - create a readonly context that gets set by the constructor
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }
        private API_DanceFellowsDbContext _context { get; }

        /// <summary>
        /// Constructor for this service using dependency injection - sets our readonly context to the provided context when instantiating the service
        /// </summary>
        /// <param name="context">Database context to be used for this service</param>
        public CompetitorManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
            _context = context;
        }

        /// <summary>
        /// Returns a competitor from the Competitor table with the given id.
        /// </summary>
        /// <param name="id">Id to search for a competitor by.</param>
        /// <returns>A single competitor.</returns>
        public async Task<Competitor> GetCompetitor(int id)
        {
            return await ReadOnlyContext.Competitors.FirstOrDefaultAsync(comp => comp.WSDC_ID == id);
        }







        // TODO: should we kill all this functionality to submit? It'll save a lot of testing, and it isn't required.

        /// <summary>
        /// manages process to cleanse and update all competitor records with fresh data from external API 
        /// </summary>
        /// <returns> count of records touched </returns>
        public async Task<int> RefreshAll()
        {
            //await DumpCompetitorsTable();
            int count = 0;
            //for (int i = 1; i < 18500; i += 250)
            //{
            //    GetExternalData(i, i + 249);
            //}
            for (int i = 6000; i < 7250; i += 250)
            {
                count += await RefreshCompetitorsTable(i+1, i + 250);
            }
            return count;
        }



        /// <summary>
        /// deletes all records in the Competitor table
        /// </summary>
        /// <returns> async status Ok when complete </returns>
        private async Task DumpCompetitorsTable()
        {
            var getAll = await GetAllCompetitors();
            foreach (Competitor competitor in getAll)
            {
                await DeleteCompetitor(competitor.WSDC_ID);
            }
            await SaveThis();
        }

        /// <summary>
        /// Returns all competitors from the Competitor table.
        /// </summary>
        /// <returns> IEnumerable of all competitors from the table. </returns>
        public async Task<IEnumerable<Competitor>> GetAllCompetitors()
        {
            // Thanks to https://forums.asp.net/t/1973344.aspx?How+do+I+use+async+Task+IQueryable+ for recommending a task factory for query operations without GetAwaiter.
            return await Task.Run(() => ReadOnlyContext.Competitors.AsEnumerable<Competitor>());
        }

        /// <summary>
        /// removes a single competitor from the Competitors table
        /// </summary>
        /// <param name="id"> WSDC_ID of competitor to remove </param>
        private async Task DeleteCompetitor(int id)
        {
            var item = await ReadOnlyContext.Competitors.FirstOrDefaultAsync(c => c.WSDC_ID == id);

            if (item != null)
            {
                ReadOnlyContext.Competitors.Remove(item);
            }
        }




        /// <summary>
        /// requests competitor data by WSDC_ID and writes valid returns to externalfile.csv
        /// </summary>
        private void GetExternalData(int start, int end)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter($"{_filepath}_{start}-{end}.csv"))
                {
                    string dancer = "";
                    for (int i = start; i <= end; i++)
                    {
                        dancer = GetDancer(i);
                        if (dancer != "")
                        {
                            streamWriter.WriteLine(dancer);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("empty dancer record");
            }
        }

        /// <summary>
        /// collects raw dancer data from external API
        /// </summary>
        /// <param name="dancerID"> ID of dancer whose data to collect </param>
        /// <returns> dancer data from API in string form </returns>
        private static string GetDancer(int dancerID)
        {
            var client = new WebClient();
            string _url = "https://points.worldsdc.com/lookup/find";

            NameValueCollection queryPair = new NameValueCollection();
            queryPair["num"] = dancerID.ToString();

            string stringDancer = "";
            try
            {
                var rawDancer = client.UploadValues(_url, "POST", queryPair);
                stringDancer = Encoding.UTF8.GetString(rawDancer);
            }
            catch (Exception)
            {
                Console.WriteLine("empty dancer ID");
            }
            return stringDancer;
        }




        string _filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/externaldata");
        int count = 0;

        /// <summary>
        /// populates Competitor table from external data file
        /// </summary>
        /// <returns> count of dancer records added to table </returns>
        private async Task<int> RefreshCompetitorsTable(int start, int end)
        {
            using (StreamReader reader = new StreamReader($"{_filepath}_{start}-{end}.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {

                        Competitor competitor = new Competitor();
                        JObject obj = JObject.Parse(line);
                        JToken jDancer = obj["dancer"];
                        competitor.FirstName = (string)jDancer["first_name"];
                        competitor.LastName = (string)jDancer["last_name"];
                        competitor.WSDC_ID = (int)jDancer["wscid"];
                        JToken jLevel = obj["level"];
                        competitor.MinLevel = ConvertLevel((string)jLevel["required"]);
                        competitor.MaxLevel = ConvertLevel((string)jLevel["allowed"]);

                        var query = await ReadOnlyContext.Competitors.FirstOrDefaultAsync(c => c.WSDC_ID == competitor.WSDC_ID);
                        if(query == null)
                        {
                            await CreateCompetitor(competitor);
                        }
                        else
                        {
                            query = competitor;
                            await UpdateCompetitor(query);
                        }

                        ReadOnlyContext.SaveChanges();

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed to create dancer record.");
                    }

                    count++;
                }

            }
            return count;
        }


               

        /// <summary>
        /// Takes a newly created competitor and adds it to the Competitor table.
        /// </summary>
        /// <param name="competitor">Competitor to be added to the table.</param>
        /// <returns>An asynchronous task, which will always be the saving of the database table.</returns>
        private async Task CreateCompetitor(Competitor competitor)
        {
            using (var transaction = ReadOnlyContext.Database.BeginTransaction())
            {
                // kudos to MS Docs for this amazing tidbit: https://docs.microsoft.com/en-us/ef/ef6/saving/transactions
                ReadOnlyContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Competitors] ON");
                ReadOnlyContext.Competitors.Add(competitor);
                await ReadOnlyContext.SaveChangesAsync();
                ReadOnlyContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Competitors] OFF");
                transaction.Commit();
            }
        }

        /// <summary>
        /// converts level designators from raw data file to Level data type
        /// </summary>
        /// <param name="level"> raw level designator string </param>
        /// <returns> correlated Level </returns>
        private static Level ConvertLevel(string level)
        {
            switch (level)
            {
                case "NOV":
                    return Level.Novice;
                case "INT":
                    return Level.Intermediate;
                case "ADV":
                    return Level.Advanced;
                case "ALS":
                    return Level.AllStar;
                case "ALS+":
                    return Level.Champ;
                default:
                    return Level.Newcomer;
            }
        }

        /// <summary>
        /// Given the updated state of a competitor (who already exists in the table), update the record of that competitor.
        /// </summary>
        /// <param name="comp">The competitor to be updated. If they do not already exist in the table, do not update anything.</param>
        private async Task UpdateCompetitor(Competitor comp)
        {
            Competitor compExists = await ReadOnlyContext.Competitors.FirstOrDefaultAsync(competitor => competitor.ID == comp.ID);
            if (compExists != null)
            {
                ReadOnlyContext.Competitors.Update(comp);

            }
        }

        /// <summary>
        /// HELPER: Saves changes just made to DB.
        /// Supports making synchronous updates to DB ( .Update() lacks GetAwaiter ) and saving after all iterations complete.
        /// </summary>
        /// <returns></returns>
        private async Task SaveThis()
        {
            await ReadOnlyContext.SaveChangesAsync();
        }









    }
}
