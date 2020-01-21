using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedit01.Models
{
    public class Voting
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public long ArticleId { get; set; }

        public DateTime LastVoting { get; set; }

        public bool VotingUp { get; set; }

        public bool VotingDown { get; set; }
    }
}