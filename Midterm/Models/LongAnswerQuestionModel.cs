using System.ComponentModel.DataAnnotations;

namespace Midterm
{
	public class LongAnswerQuestionModel : TestQuestionModel
	{
		[Required]
		public virtual string Answer { get; set; }
	}
}
