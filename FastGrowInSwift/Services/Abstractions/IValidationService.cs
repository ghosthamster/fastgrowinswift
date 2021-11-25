using EasyCSharpApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services.Abstractions
{
    public interface IValidationService
    {
        AnswerDTO ValidateAnswer(int id);
        AnswerDTO ValidateAnswer(AnswerDTO answer);
    }
}
