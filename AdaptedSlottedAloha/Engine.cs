using System;
using System.Collections.Generic;
using MathNet.Numerics.Distributions;

namespace AdaptedSlottedAloha
{
    public class Engine
    {
        public int NumberOfStations; //combobox1
        public double InputFlow; //combobox2
        public int NumberOfFrames; //combobox3
        public bool Adapted;

        private Server _server;
        public Statistics Statistics;
        private List<Station> _stations = new List<Station>();

        public Engine(int numberOfStations, double inputFlow, int numberOfFrames, bool adapted)
        {
            NumberOfStations = numberOfStations;
            InputFlow = inputFlow;
            NumberOfFrames = numberOfFrames;
            Adapted = adapted;
            CreateObjects(numberOfStations, inputFlow, numberOfFrames);
            Calculate(numberOfFrames);
        }

        public void Calculate(int numberOfFrames)
        {
            for (var i = 0; i < numberOfFrames; i++)
            {
                GeneratePackages(NumberOfStations);
                GenerateRandomProbabilities(NumberOfStations);
                SendPackages(NumberOfStations);
                IncreasePackagesLifeTime(NumberOfStations);
                CheckCollision(NumberOfStations, InputFlow);
                DecreaseBacklogTimers(NumberOfStations);
                Statistics.IncreaseNumberOfBackloggedFramesAndPackages();
                _server.IncreaseCurrentFrameCounter();
            }
        }

        public object GetStatistics()
        {
            Calculate(NumberOfFrames);
            return Statistics;
        }

        private void DecreaseBacklogTimers(int numberOfStations)
        {
            for (var i = 0; i < numberOfStations; i++)
                _stations[i].DecreaseBacklogTime();
        }

        private void CheckCollision(int numberOfStations, double inputFlow)
        {
            if (!_server.IsCollision(_server.CurrentFrame, numberOfStations))
            {
                for (var i = 0; i < numberOfStations; i++)
                    if (_server.IsPackageSent(i, _server.CurrentFrame))
                    {
                        _stations[i].DestroyPackage();
                        Statistics.IncreasePackagesLifeTime(_stations[i].LifeTime);
                        _stations[i].ResetLifeTime();
                        Statistics.PackagesLeavedSystem++;
                    }
                _server.CheckEstimationAfterSuccessfulOrEmpty(inputFlow);
            }
            else if (_server.IsCollision(_server.CurrentFrame, numberOfStations))
            {
                for (var i = 0; i < numberOfStations; i++)
                    if (_server.IsPackageSent(i, _server.CurrentFrame))
                        _stations[i].GenerateBacklogTime();
                Statistics.Collisions++;
                _server.CheckEstimationAfterConflict(inputFlow);
            }
        }

        private void IncreasePackagesLifeTime(int numberOfStations)
        {
            for (var i = 0; i < numberOfStations; i++)
                if (_stations[i].IsPackageExist())
                    _stations[i].IncreaseLifeTime();
        }

        private void SendPackages(int numberOfStations)
        {
            for (var i = 0; i < numberOfStations; i++)
                _server.Frames[i, _server.CurrentFrame] = _stations[i].Package(_server.Estimation, Adapted);
        }

        private void GenerateRandomProbabilities(int numberOfStations)
        {
            for (var i = 0; i < numberOfStations; i++)
                _stations[i].GenerateRandomProbability();
        }

        private void GeneratePackages(int numberOfStations)
        {
            for (var i = 0; i < numberOfStations; i++)
                if (!_stations[i].IsPackageExist())
                {
                    _stations[i].GeneratePackage();
                    if (_stations[i].IsPackageExist())
                    {
                        _stations[i].ResetLifeTime();
                        Statistics.PackagesGenerated++;
                    }
                }
        }

        private void CreateObjects(int numberOfStations, double inputFlow, int numberOfFrames)
        {

            for (var i = 0; i < numberOfStations; i++)
            {
                var station = new Station();
                _stations.Add(station);
            }
            Station.Poisson = new Poisson(inputFlow / numberOfStations);
            Station.Random = new Random();
            _server = new Server(numberOfStations, numberOfFrames);
            Statistics = new Statistics();
        }
    }
}
