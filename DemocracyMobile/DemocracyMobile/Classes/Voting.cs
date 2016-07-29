using DemocracyApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemocracyMobile.Classes
{
   public class Voting
    {
        public int VotingId { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public bool IsForAllUsers { get; set; }

        public bool IsEnabledBlankVote { get; set; }

        public int QuantityVotes { get; set; }

        public int QuantityBlankVotes { get; set; }

        public User Winner { get; set; }

        public State State { get; set; }

        public List<Candidate> Candidates { get; set; }

        public string DateTimeStartEdited
        {
            get
            {
                return string.Format("Starts: {0:g}", DateTimeStart);
            }
        }

        public string DateTimeEndEdited
        {
            get
            {
                return string.Format("Ends: {0:g}", DateTimeEnd);
            }
        }

        public string QuantityVotesEdited
        {
            get
            {
                return string.Format("Votes: {0:N0}", QuantityVotes);
            }
        }


        public override string ToString()
        {
            return string.Format("[Voting: VotingId={0}, Description={1}, Remarks={2}, DateTimeStart={3}, " +
                "DateTimeEnd={4}, IsForAllUsers={5}, IsEnabledBlankVote={6}, QuantityVotes={7}, " +
                "QuantityBlankVotes={8}, Winner={9}, State={10}, Candidates={11}]",
                VotingId, Description, Remarks, DateTimeStart, DateTimeEnd, IsForAllUsers,
                IsEnabledBlankVote, QuantityVotes, QuantityBlankVotes, Winner, State, Candidates);
        }


    }
}
