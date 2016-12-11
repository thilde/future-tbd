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
                $"v1/schools/?fields=id,school.name,school.city,school.state,school.zip,2014.admissions.admission_rate.overall,2014.student.size,school.degrees_awarded.highest,2013.cost.attendance.academic_year,2013.cost.tuition.in_state,2013.cost.tuition.out_of_state&per_page=100&school.name={searchText}&school.operating=1&2014.student.size__range=0..&2014.academics.program_available.assoc_or_bachelors=true&school.degrees_awarded.predominant__range=1..3&api_key=chTquJ84cMVe4GV8k9oboKZp9e3Otxl0M1LLFvmx");

            return new SearchResult() {ResultString = result};
        }

        public SearchResult SearchByState(string state)
        {
            var client = new WebClient { BaseAddress = "https://api.data.gov/ed/collegescorecard/" };


            string result = client.DownloadString(
                $"v1/schools/?fields=id,school.name,school.city,school.state,school.zip,2014.admissions.admission_rate.overall,2014.student.size,school.degrees_awarded.highest,2013.cost.attendance.academic_year,2013.cost.tuition.in_state,2013.cost.tuition.out_of_state&per_page=100&school.state={state}&school.operating=1&2014.student.size__range=0..&2014.academics.program_available.assoc_or_bachelors=true&school.degrees_awarded.predominant__range=1..3&api_key=chTquJ84cMVe4GV8k9oboKZp9e3Otxl0M1LLFvmx");

            return new SearchResult() { ResultString = result };
        }

        #endregion
    }
}