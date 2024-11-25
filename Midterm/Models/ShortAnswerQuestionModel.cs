using System.ComponentModel.DataAnnotations;

namespace Midterm
{
	public class ShortAnswerQuestionModel : TestQuestionModel
	{
		[Required]
		[StringLength(100, ErrorMessage = "Maximum length of answer for Short Answer is 100 characters")]
		public override string Answer { get; set; }
	}
}
