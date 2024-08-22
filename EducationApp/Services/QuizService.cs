using EducationApp.Domain;
using EducationApp.Domain.Models;
using EducationApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class QuizService : IQuizService
{
    private readonly AppDbContext _context;

    public QuizService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
    {
        return await _context.Quizzes.ToListAsync();
    }

    public async Task<Quiz> GetQuizByIdAsync(int id)
    {
        return await _context.Quizzes.FindAsync(id);
    }

    public async Task<Quiz> CreateQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();
        return quiz;
    }

    public async Task<bool> UpdateQuizAsync(int id, Quiz quiz)
    {
        if (id != quiz.QuizId)
        {
            return false;
        }

        _context.Entry(quiz).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteQuizAsync(int id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);
        if (quiz == null)
        {
            return false;
        }

        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();
        return true;
    }
}
