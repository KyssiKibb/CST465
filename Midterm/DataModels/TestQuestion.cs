using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class TestQuestion
    {
        public int ID { get; set; }
        public string QuestionType { get;set; }
        public string Question { get; set; }
        public List<string>  Choices {get;set;}
        
    }
}