using Newtonsoft.Json;
using SverigesRadioAPI.SverigesRadio.Models;

namespace SverigesRadioAPI.SverigesRadio
{
    public class SverigesRadio
    {
        private const string BASE_URL = @"http://api.sr.se/api/v2/";
        private readonly HttpClient _httpClient = new();

        /// <summary>
        /// Gets all the pod files associated with a programId
        /// </summary>
        /// <param name="programId">ProgramId to find PodFiles for</param>
        /// <returns>List of podfiles</returns>
        public async Task<List<Podfile>> GetPodfilesAsync(int programId)
        {
            var queryParams = $"?programid={programId}&format=json";
            var response = await this._httpClient.GetAsync(new Uri($"{BASE_URL}{Endpoints.PodFiles}{queryParams}"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var toReturn = JsonConvert.DeserializeObject<PodfileList>(content);

            ArgumentNullException.ThrowIfNull(toReturn);

            return toReturn.Podfiles;
        }

        /// <summary>
        /// Gets all the programs belonging to a certain categoryId
        /// </summary>
        /// <param name="isArchived">Includes archived programs or not</param>
        /// <param name="hasPod">Only include programs with pods</param>
        /// <param name="category">Category of program</param>  
        /// <returns>A list of radio programs</returns>
        public async Task<List<RadioProgram>> GetProgramsAsync(bool isArchived, bool hasPod, ProgramCategoryEnum category)
        {
            var queryParams = $"?filter=program.isarchived&filterValue={isArchived}&filter=program.haspod&filterValue={hasPod}&programcategoryid={(int)category}&format=json";

            var response = await this._httpClient.GetAsync(new Uri($"{BASE_URL}{Endpoints.Programs}{queryParams}"));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var programList = JsonConvert.DeserializeObject<ProgramList>(content);
            ArgumentNullException.ThrowIfNull(programList);

            var programsToReturn = programList.Programs;

            while (!string.IsNullOrEmpty(programList.Pagination.NextPage))
            {
                programList = await GetPaginationPage<ProgramList>(programList.Pagination);
                programsToReturn.AddRange(programList.Programs);
            }

            return programsToReturn;
        }

        /// <summary>
        /// Gets the data from the Pagination Nextpage Url.
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>All the data from the NextPage Url parsed to its corresponding model</returns>
        private async Task<T> GetPaginationPage<T>(Pagination pagination)
        {
            var response = await this._httpClient.GetAsync(pagination.NextPage);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<T>(content);
            ArgumentNullException.ThrowIfNull(model);

            return model;
        }
    }
}