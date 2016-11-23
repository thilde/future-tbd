using System.Net;
using FutureTbd.Controllers;
using FutureTbd.Models;

namespace FutureTbd.Endpoints
{
    public class DataEndpoint : IDataEndpoint
    {
        #region Implementation of IDataEndpoint

        public SearchResult Search(string searchText)
        {
            var client = new WebClient {BaseAddress = "https://api.data.gov/ed/collegescorecard/"};


            string result = client.DownloadString(
                $"v1/schools/?fields=school.name,school.city,school.state,school.zip,2014.admissions.admission_rate.overall,2014.student.size&per_page=20&school.name={searchText}&school.operating=1&2014.student.size__range=0..&2014.academics.program_available.assoc_or_bachelors=true&school.degrees_awarded.predominant__range=1..3&school.degrees_awarded.highest__range=2..4&api_key=chTquJ84cMVe4GV8k9oboKZp9e3Otxl0M1LLFvmx");

            return new SearchResult() {ResultString = result};
        }

        #endregion
    }
}