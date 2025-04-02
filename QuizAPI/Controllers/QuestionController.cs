using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuestionController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {

            var random5Qns = await (_context.Questions
                .Select(x => new
                {
                    QnId = x.QnId,
                    QnInWords = x.QnInWords,
                    ImaageName = x.ImageName,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                })
                .OrderBy(y => Guid.NewGuid())
                .Take(5)
                ).ToListAsync();

            return Ok(random5Qns);
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Question/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QnId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<IEnumerable<Question>>> RetreiveAnswers(int[] qnIds)
        {
            try
            {
                // Ensure that the array is not null and contains values.
                if (qnIds == null || qnIds.Length == 0)
                {
                    return BadRequest("Question IDs are required.");
                }

                // Convert qnIds to a comma-separated string
                var qnIdsString = string.Join(",", qnIds);

                // Create the SQL query
                var sqlQuery = @$"
            SELECT QnId, QnInWords, ImageName, Option1, Option2, Option3, Option4, Answer
            FROM Questions
            WHERE QnId IN ({qnIdsString})
        ";

                // Execute the raw SQL query and map the results
                var answers = await _context.Questions
                    .FromSqlRaw(sqlQuery)
                    .Select(y => new
                    {
                        QnId = y.QnId,
                        QnInWords = y.QnInWords,
                        ImageName = y.ImageName,
                        Options = new string[] { y.Option1, y.Option2, y.Option3, y.Option4 },
                        Answer = y.Answer
                    })
                    .ToListAsync();

                return Ok(answers);
            }
            catch (SqlException ex)
            {
                // Log the exception and return a detailed error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QnId == id);
        }
    }
}
