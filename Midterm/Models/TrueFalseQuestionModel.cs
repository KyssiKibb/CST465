using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace Midterm;

public class TrueFalseQuestionModel : TestQuestionModel
{
    [Required]
    [RegularExpression("true|false", ErrorMessage = "Has to be value true or false")]
    public override string Answer{get;set;}
}