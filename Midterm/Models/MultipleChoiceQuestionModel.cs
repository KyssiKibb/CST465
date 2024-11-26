using System.ComponentModel.DataAnnotations;

namespace Midterm
{
	public class MultipleChoiceQuestionModel : TestQuestionModel
	{
		[Required]
		public virtual string Answer { get; set; }
		[Required] //when i have the choices here instead of in the base model it requires casting in TakeTest (unless you do partial view which does the casting)
		public List<string>? Choices { get; set; }
	}
}
