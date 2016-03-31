using System.ComponentModel.DataAnnotations;


namespace FragSwapperV2.Models.Db
{
    public class HostStates
    {
        public int ID { get; set; }
        public Host Host { get; set; }
        public State State { get; set; }
    }
}
