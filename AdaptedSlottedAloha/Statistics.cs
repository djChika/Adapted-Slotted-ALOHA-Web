namespace AdaptedSlottedAloha
{
    public class Statistics
    {
        public int PackagesGenerated { get; set; }
        public int PackagesLeavedSystem { get; set; }
        private int PackagesLifeTime { get; set; }
        private int NumberOfBackloggedPackages { get; set; }
        private int NumberOfBackloggedFrames { get; set; }
        public int Collisions { get; set; }

        public int BackloggedPackages => PackagesGenerated - PackagesLeavedSystem;

        public void IncreasePackagesLifeTime(int lifeTime)
        {
            PackagesLifeTime += lifeTime;
        }

        public void IncreaseNumberOfBackloggedFramesAndPackages()
        {
            if (PackagesGenerated - PackagesLeavedSystem > 0)
                NumberOfBackloggedFrames++;
            NumberOfBackloggedPackages += PackagesGenerated - PackagesLeavedSystem;
        }

        public double AverageOfBackloggedPackages
        {
            get
            {
                if (NumberOfBackloggedFrames > 0)
                    return (double)NumberOfBackloggedPackages / NumberOfBackloggedFrames;
                return 0;
            }
        }

        public double AverageOfPackagesLifeTime
        {
            get
            {
                if (PackagesLeavedSystem > 0)
                    return (double)PackagesLifeTime / PackagesLeavedSystem;
                return 0;
            }
        }
    }
}
