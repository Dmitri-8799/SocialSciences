using System;
using SQLite;

namespace SocialSciencesDecember2023.RadioButtons3
{
    public class TableRB3
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string question
        {
            get; set;
        }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public int AnswerNr { get; set; }
        public string IfWrong { get; set; }
        public string IfRight { get; set; }

    }
}

