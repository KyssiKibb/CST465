using System.ComponentModel.DataAnnotations;

namespace Midterm.Models
{
	public class ShortAnswerQuestionModel : TestQuestionModel
	{
		[Required]
		public override string Answer { get; set; }
	}
}
