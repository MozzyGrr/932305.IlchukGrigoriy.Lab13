using lab13.Models;

namespace lab13.Services
{
    public interface IQuizService
    {
        public Quiz LoadCurrentQuiz();
        public QuizQuestion GenerateNextQuestion(Quiz quiz);
        public QuizQuestion LoadCurrentQuestion(Quiz quiz);
        public void SubmitAnswer(QuizAnswer answer, Quiz quiz);
        public void finish(Quiz quiz);
    }
}