using lab13.Models;

namespace lab13.Services
{
    public class QuizService : IQuizService
    {
        Random _rand = new();
        public static Quiz? currentQuiz;

        public Quiz LoadCurrentQuiz()
        {
            if (currentQuiz == null) currentQuiz = new Quiz();
            return currentQuiz;
        }

        public void SubmitAnswer(QuizAnswer answer, Quiz quiz)
        {
            if (quiz.quizQuestionAnswers.Count < quiz.quizQuestions.Count)
                quiz.addAnswerQuestion(answer);
        }

        public QuizQuestion GenerateNextQuestion(Quiz quiz)
        {
            int firstNumber = _rand.Next(10);
            int secondNumber = _rand.Next(10);
            string operation = "+";
            int answer = secondNumber + firstNumber;

            if (_rand.Next(2) > 0)
            {
                operation = "-";
                answer = firstNumber - secondNumber;
            }

            QuizQuestion quest = new(firstNumber, secondNumber, operation, answer);
            quiz.addQuestion(quest);

            return quest;
        }

        public void finish(Quiz quiz)
        {
            quiz.reset();
        }

        public QuizQuestion LoadCurrentQuestion(Quiz quiz)
        {
            if (quiz.quizQuestions.Count == 0) return GenerateNextQuestion(quiz);
            return quiz.quizQuestions.Last();
        }
    }
}
