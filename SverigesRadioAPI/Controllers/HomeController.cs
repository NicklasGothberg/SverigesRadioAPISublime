using Microsoft.AspNetCore.Mvc;
using SverigesRadioAPI.Models;
using SverigesRadioAPI.SverigesRadio.Models;
using SverigesRadioAPI.ViewModels;

namespace SverigesRadioAPI.Controllers
{
    public class HomeController : Controller
    {
        private const string CONTROLLER_NAME = "HomeController";

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var sr = new SverigesRadio.SverigesRadio();

            List<RadioProgram> programs;

            try
            {
                programs = await sr.GetProgramsAsync(false, true, ProgramCategoryEnum.Humor);
            }
            catch (ArgumentNullException exception)
            {
                this._logger.LogError(exception,
                    "GetProgramsAsync returned null {}",
                    CONTROLLER_NAME);

                var viewModel = new ErrorViewModel();
                viewModel.RequestId = "1";
                return View("Error", viewModel);
            }
            catch (HttpRequestException exception)
            {
                this._logger.LogError(exception, 
                    "GetProgramsAsync returned a non successful status code {}",
                    CONTROLLER_NAME);

                var viewModel = new ErrorViewModel();
                viewModel.RequestId = "1";
                return View("Error", viewModel);
            }

            var toReturn = new List<ProgramPodcastViewModel>();

            foreach (var program in programs.OrderBy(program => program.Channel.Id))
            {
                try
                {
                    var podFiles = await sr.GetPodfilesAsync(program.Id);

                    //NOTE: Not all programs with "Haspods" set to true actually have any podfiles.
                    if (!podFiles.Any()) continue;

                    toReturn.Add(new ProgramPodcastViewModel
                    {
                        Podfiles = podFiles,
                        Program = program
                    });
                }
                catch (ArgumentNullException exception)
                {
                    this._logger.LogError(exception,
                        "GetPodfilesAsync returned null {}",
                        CONTROLLER_NAME);
                }
                catch (HttpRequestException exception)
                {
                    this._logger.LogError(exception,
                        "GetPodfilesAsync returned a non successful status code {}",
                        CONTROLLER_NAME);
                }
            }

            return View(toReturn);
        }
    }
}