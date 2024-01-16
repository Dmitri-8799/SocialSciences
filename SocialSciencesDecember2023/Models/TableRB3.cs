using System;
using Microsoft.EntityFrameworkCore;
namespace SocialSciencesEF2024.TableRb3
{
	public partial class TableRB3
	{
	
        public int id { get ; set; }
		
        public string? question { get; set; }
		
	public string? option1 { get; set; }
        public string? option2 { get; set; }
	public string? option3 { get; set; }
		
	public int answerNr { get; set; }

        public string? ifRight { get; set; }
        public string? ifWrong { get; set; }
        
	}
}


