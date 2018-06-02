using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptedSlottedAlohaWeb.Controllers.Aloha;
using Microsoft.AspNetCore.Mvc;

namespace AdaptedSlottedAlohaWeb.Controllers
{
    [Route("api/[controller]")]
    public class AlohaController : Controller
    {
        [HttpGet("[action]")]
        public string Data()
        {
            return "Hello, I'm Vera!";
        }

        public class InputParameters
        {
            public int NumberOfStations { get; set; } //combobox1
            public double InputFlow { get; set; } //combobox2
            public int NumberOfFrames { get; set; } //combobox3
            public int NumberOfIterations { get; set; }
        }

        public class OutputResults
        {
            public Stats NotAdapted { get; set; }
            public Stats Adapted { get; set; }
        }

        public class Stats
        {
            public int[] PackagesGenerated { get; set; }
            public int[] PackagesLeavedSystem { get; set; }
            public int[] Collisions { get; set; }
            public int[] BackloggedPackages { get; set; }
            public double[] AverageOfBackloggedPackages { get; set; }
            public double[] AverageOfPackagesLifeTime { get; set; }
            //public Statistics[] statistics { get; set; } = new Statistics[5];

            public Stats(int numberOfIterations)
            {
                PackagesGenerated = new int[numberOfIterations];
                PackagesLeavedSystem = new int[numberOfIterations];
                Collisions = new int[numberOfIterations];
                BackloggedPackages = new int[numberOfIterations];
                AverageOfBackloggedPackages = new double[numberOfIterations];
                AverageOfPackagesLifeTime = new double[numberOfIterations];
            }
        }

        [HttpPost("[action]")]
        public object Calculation([FromBody]InputParameters inputParameters)
        {
            var adapted = new Stats(inputParameters.NumberOfIterations);
            var notadapted = new Stats(inputParameters.NumberOfIterations);

            for (var i = 0; i < inputParameters.NumberOfIterations; i++)
            {
                var adaptedAloha = new Aloha.Engine(
                    inputParameters.NumberOfStations,
                    inputParameters.InputFlow,
                    inputParameters.NumberOfFrames, true);

                adapted.PackagesGenerated[i] = adaptedAloha._statistics.PackagesGenerated;
                adapted.PackagesLeavedSystem[i] = adaptedAloha._statistics.PackagesLeavedSystem;
                adapted.Collisions[i] = adaptedAloha._statistics.Collisions;
                adapted.BackloggedPackages[i] = adaptedAloha._statistics.BackloggedPackages;
                adapted.AverageOfBackloggedPackages[i] = adaptedAloha._statistics.AverageOfBackloggedPackages;
                adapted.AverageOfPackagesLifeTime[i] = adaptedAloha._statistics.AverageOfPackagesLifeTime;


                var notAdaptedAloha = new Aloha.Engine(
                    inputParameters.NumberOfStations,
                    inputParameters.InputFlow,
                    inputParameters.NumberOfFrames, false);

                notadapted.PackagesGenerated[i] = notAdaptedAloha._statistics.PackagesGenerated;
                notadapted.PackagesLeavedSystem[i] = notAdaptedAloha._statistics.PackagesLeavedSystem;
                notadapted.Collisions[i] = notAdaptedAloha._statistics.Collisions;
                notadapted.BackloggedPackages[i] = notAdaptedAloha._statistics.BackloggedPackages;
                notadapted.AverageOfBackloggedPackages[i] = notAdaptedAloha._statistics.AverageOfBackloggedPackages;
                notadapted.AverageOfPackagesLifeTime[i] = notAdaptedAloha._statistics.AverageOfPackagesLifeTime;
            }
            var outputResults = new OutputResults()
            {
                NotAdapted = notadapted,
                Adapted = adapted
            };
            return outputResults;
        }


        /*[HttpPost("[action]")]
        public IActionResult CalculationOld([FromBody]InputParameters inputParameters)
        {
            var alohaEngine = new Aloha.Engine(inputParameters.NumberOfStations,
                inputParameters.InputFlow,
                inputParameters.NumberOfFrames);
            var outputResults = alohaEngine.GetStatistics();
            alohaEngine = null;
            return Json(outputResults);
        }*/
    }
}
