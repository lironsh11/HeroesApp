using System;

namespace HeroesApp.DataModels
{
    public class HeroeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abilty { get; set; }
        public int GuideID { get; set; }
        public DateTime StartDate { get; set; }
        public string SuiteColors { get; set; }
        public decimal StartingPower { get; set; }
        public decimal CurrentPower { get; set; }
    }
}
