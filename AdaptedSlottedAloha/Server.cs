namespace AdaptedSlottedAloha
{
    internal class Server
    {
        public int[,] Frames { get; set; } = new int[1000, 500000];
        public int CurrentFrame { get; set; }
        public void IncreaseCurrentFrameCounter()
        {
            CurrentFrame++;
        }

        public bool IsCollision(int frame, int numberOfStations)
        {
            var collision = 0;
            for (var i = 0; i < numberOfStations; i++)
            {
                if (IsPackageSent(i, frame))
                {
                    collision++;
                }
            }
            switch (collision)
            {
                case 0:
                    return false;
                case 1:
                    return false;
                default:
                    return true;
            }
        }

        public bool IsPackageSent(int station, int frame)
        {
            return Frames[station, frame] != 0;
        }

        public double PreviousEstimation { get; set; }
        public double Estimation { get; set; }

        public void CheckEstimationAfterSuccessfulOrEmpty(double lambda)
        {
            PreviousEstimation = Estimation;
            Estimation = PreviousEstimation + lambda - 1;
            if (Estimation < lambda)
                Estimation = lambda;
        }

        public void CheckEstimationAfterConflict(double lambda)
        {
            PreviousEstimation = Estimation;
            Estimation = PreviousEstimation + lambda + 1.39;
        }
    }
}
