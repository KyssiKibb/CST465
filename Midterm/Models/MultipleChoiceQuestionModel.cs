using System.ComponentModel.DataAnnotations;

namespace Midterm.Models
{
	public class MultipleChoiceQuestionModel : TestQuestionModel
	{
		[Required]
		public virtual string Answer { get; set; }
	}
}
