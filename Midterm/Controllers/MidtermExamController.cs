using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Midterm.Models;
namespace Midterm;

//TODO:  Is something missing here? 
public class MidtermExamController : Controller
{
    private readonly MidtermExam _Exam;
    private readonly IConfiguration _Config;
    
    public MidtermExamController(IConfiguration conf, IOptions<MidtermExam> exam)
    {
        _Exam = exam.Value;
    }
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("TakeTest")]
    [HttpGet]
    public IActionResult TakeTest()
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        return View(questionModels);
    }
    [Route("SubmitTest")]
    [HttpPost]
    public IActionResult TakeTest(List<TestQuestionModel> model)
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        //TODO: At this point you will only have the raw answers in the model.  Questions did not get posted back.
        //You will need to get the questions again from GetQuestionModels(), then set the answer values on the retrieved list by
        //  matching the two lists based on ID
        if(!ModelState.IsValid)
        {
            return View(questionModels);
        }

        //TODO: Change the below so that it loads the DisplayResults view, passing in the model
        return View();
        
    }
    private List<TestQuestionModel> GetQuestionModels()
    {
        List<TestQuestionModel> questionModels = new List<TestQuestionModel>();
        foreach(var question in _Exam.Questions)
        {
            if (question.QuestionType == "TrueFalseQuestion")
            {
                TrueFalseQuestionModel tfQuestion = new TrueFalseQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
            }
            else if (question.QuestionType == "ShortAnswerQuestion")
            {
                ShortAnswerQuestionModel saQuestion = new ShortAnswerQuestionModel();
                saQuestion.ID = question.ID;
                saQuestion.Question = question.Question;
                questionModels.Add(saQuestion);
            }
            else if (question.QuestionType == "LongAnswerQuestion")
            {
                LongAnswerQuestionModel laQuestion = new LongAnswerQuestionModel();
                laQuestion.ID = question.ID;
                laQuestion.Question = question.Question;
                questionModels.Add(laQuestion);
            }
            else if (question.QuestionType == "MultipleChoiceQuestion")
            { 
            }
            
            //TODO: Implement creating the rest of the question models here. Multiple choice questions will require setting the choices.
        }
        return questionModels;
    }
}