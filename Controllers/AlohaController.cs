using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AdaptedSlottedAloha.Web.Controllers
{
    [Route("api/[controller]")]
    public class AlohaController : Controller
    {
        public class InputParameters
        {
            public int NumberOfStations { get; set; } //combobox1
            public double InputFlow { get; set; } //combobox2
            public int NumberOfFrames { get; set; } //combobox3
            public int NumberOfIterations { get; set; }
        }

        public class OutputResults<T>
        {
            public T NotAdapted { get; set; }
            public T Adapted { get; set; }
        }

        public class Stats
        {
            public int[] PackagesGenerated;
            public int[] PackagesLeavedSystem;
            public int[] Collisions;
            public int[] BackloggedPackages;
            public double[] AverageOfBackloggedPackages;
            public double[] AverageOfPackagesLifeTime;
            //public Statistics[] statistics { get; set; } = new Statistics[numberOfIterations];

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

        public class AverageStats
        {
            public double PackagesGenerated;
            public double PackagesLeavedSystem;
            public double Collisions;
            public double BackloggedPackages;
            public double AverageOfBackloggedPackages;
            public double AverageOfPackagesLifeTime;
        }

        [HttpPost("[action]")]
        public object Calculation([FromBody]InputParameters inputParameters)
        {
            var adapted = new Stats(inputParameters.NumberOfIterations);
            var notadapted = new Stats(inputParameters.NumberOfIterations);

            for (var i = 0; i < inputParameters.NumberOfIterations; i++)
            {
                var adaptedAloha = new AdaptedSlottedAloha.Engine(
                    inputParameters.NumberOfStations,
                    inputParameters.InputFlow,
                    inputParameters.NumberOfFrames, true);

                adapted.PackagesGenerated[i] = adaptedAloha.Statistics.PackagesGenerated;
                adapted.PackagesLeavedSystem[i] = adaptedAloha.Statistics.PackagesLeavedSystem;
                adapted.Collisions[i] = adaptedAloha.Statistics.Collisions;
                adapted.BackloggedPackages[i] = adaptedAloha.Statistics.BackloggedPackages;
                adapted.AverageOfBackloggedPackages[i] = adaptedAloha.Statistics.AverageOfBackloggedPackages;
                adapted.AverageOfPackagesLifeTime[i] = adaptedAloha.Statistics.AverageOfPackagesLifeTime;


                var notAdaptedAloha = new AdaptedSlottedAloha.Engine(
                    inputParameters.NumberOfStations,
                    inputParameters.InputFlow,
                    inputParameters.NumberOfFrames, false);

                notadapted.PackagesGenerated[i] = notAdaptedAloha.Statistics.PackagesGenerated;
                notadapted.PackagesLeavedSystem[i] = notAdaptedAloha.Statistics.PackagesLeavedSystem;
                notadapted.Collisions[i] = notAdaptedAloha.Statistics.Collisions;
                notadapted.BackloggedPackages[i] = notAdaptedAloha.Statistics.BackloggedPackages;
                notadapted.AverageOfBackloggedPackages[i] = notAdaptedAloha.Statistics.AverageOfBackloggedPackages;
                notadapted.AverageOfPackagesLifeTime[i] = notAdaptedAloha.Statistics.AverageOfPackagesLifeTime;
            }

            var adaptedAverage = new AverageStats
            {
                PackagesGenerated = adapted.PackagesGenerated.Average(),
                PackagesLeavedSystem = adapted.PackagesLeavedSystem.Average(),
                Collisions = adapted.Collisions.Average(),
                BackloggedPackages = adapted.BackloggedPackages.Average(),
                AverageOfBackloggedPackages = adapted.AverageOfBackloggedPackages.Average(),
                AverageOfPackagesLifeTime = adapted.AverageOfPackagesLifeTime.Average()
            };
            var notadaptedAverage = new AverageStats
            {
                PackagesGenerated = notadapted.PackagesGenerated.Average(),
                PackagesLeavedSystem = notadapted.PackagesLeavedSystem.Average(),
                Collisions = notadapted.Collisions.Average(),
                BackloggedPackages = notadapted.BackloggedPackages.Average(),
                AverageOfBackloggedPackages = notadapted.AverageOfBackloggedPackages.Average(),
                AverageOfPackagesLifeTime = notadapted.AverageOfPackagesLifeTime.Average()
            };

            var outputResults = new OutputResults<AverageStats>
            {
                Adapted = adaptedAverage,
                NotAdapted = notadaptedAverage,
            };
            return outputResults;
        }
    }
}
