using lab4.model;

namespace lab4.dto
{
    public class WorkerDto
    {
        public Worker Worker { get; set; }
        public int PremiumSum { get; set; }

        public WorkerDto(Worker worker, int premiumSum)
        {
            this.Worker = worker;
            this.PremiumSum = premiumSum;
        }
    }
}