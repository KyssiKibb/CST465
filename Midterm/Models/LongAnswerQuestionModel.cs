using System.ComponentModel.DataAnnotations;

namespace Midterm.Models
{
	public class LongAnswerQuestionModel : TestQuestionModel
	{
		[Required]
		public virtual string Answer { get; set; }
	}
}
