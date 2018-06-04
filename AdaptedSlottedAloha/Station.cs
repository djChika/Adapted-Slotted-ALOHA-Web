using System;
using MathNet.Numerics.Distributions;

namespace AdaptedSlottedAloha
{
    internal class Station
    {
        private int _package;
        public int LifeTime { get; private set; }
        private int _backlogTime;
        private double _probability;
        public static Poisson Poisson;
        public static Random Random = new Random();

        public void GeneratePackage()
        {
            _package = Poisson.Sample();
        }

        public void GenerateBacklogTime()
        {
            if (IsPackageExist())
                _backlogTime = Random.Next(20);
        }

        public bool IsPackageExist()
        {
            return _package != 0;
        }

        public void IncreaseLifeTime()
        {
            LifeTime++;
        }

        public void ResetLifeTime()
        {
            LifeTime = 0;
        }

        public void DecreaseBacklogTime()
        {
            if (IsBacklogged())
                _backlogTime--;
        }

        public int BacklogTime()
        {
            return _backlogTime;
        }

        public bool IsBacklogged()
        {
            return _backlogTime != 0;
        }

        public void GenerateRandomProbability()
        {
            if (IsPackageExist())
                _probability = Random.NextDouble();
        }

        public bool IsAllowToSend(double estimation)
        {
            return _probability <= 1 / estimation;
        }

        public int Package(double estimation, bool adapted)
        {
            if (!IsPackageExist() || IsBacklogged()) return 0;
            if (!adapted)
                return _package;
            if (IsAllowToSend(estimation))
                return _package;
            GenerateBacklogTime();

            return 0;
        }

        public void DestroyPackage()
        {
            _package = 0;
        }
    }
}
