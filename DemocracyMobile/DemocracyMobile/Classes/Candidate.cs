using DemocracyApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemocracyMobile.Classes
{
   public class Candidate
    {
        public int CandidateId { get; set; }
        public int QuantityVotes { get; set; }
        public User User  { get; set; }

        //aqui pinto el list viws coon un toString:
        public override string ToString()
        {
            return $"Candidate: CandidateId = {this.CandidateId}, QuantityVotes = {this.QuantityVotes}, User = {this.User}";
        }
    }
}
