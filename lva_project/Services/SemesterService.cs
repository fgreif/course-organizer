using System.Linq;
using lva_project.Exceptions;
using lva_project.Models;

namespace lva_project.Services;

public interface ISemesterService
{
    void CreateSemester(Semester semester);
    Semester ReadSemester(int id);
    IEnumerable<Semester> ReadAllSemester();
    void UpdateSemester(int id, Semester semester);
    void DeleteSemester(int id);
}
public class SemesterService : ISemesterService
{
    private readonly LvaContext _lvaContext;
    private readonly ILogger<Semester> _logger;

    public SemesterService(LvaContext lvaContext, ILogger<Semester> logger)
    {
        _lvaContext = lvaContext;
        _logger = logger;
    }
    
    public void CreateSemester(Semester semester)
    {
        if (_lvaContext.Semesters.Any(l => l.SemId.Equals(semester.SemId)))
        {
            throw new SemesterException($"Semester with ID {semester.SemId} already exists!");
        }

        _lvaContext.Semesters.Add(semester);
        _lvaContext.SaveChanges();
        _logger.LogInformation($"Semester with ID {semester.SemId} successfully added!", semester);
    
    }

    public Semester ReadSemester(int id)
    {
        if (!_lvaContext.Semesters.Any(s => s.SemId.Equals(id)))
        {
            throw new SemesterException($"Semester with ID {id} not found!");
        }
        return _lvaContext.Semesters.First(s => s.SemId.Equals(id));
    
    }

    public IEnumerable<Semester> ReadAllSemester()
    {
        if (!_lvaContext.Semesters.Any())
        {
            _logger.LogInformation("Currently no Semester! Holiday :)");
            throw new SemesterException("No Semesters in List");
        }

        return _lvaContext.Semesters.ToList();
    }

    public void UpdateSemester(int id, Semester semester)
    {
        var semesterFromDb = _lvaContext.Semesters.Find(id);
        if (semesterFromDb == null)
        {
            throw new SemesterException($"Semester with ID {id} not found in Database!");
        }

        if (semesterFromDb.SemId != id)
        {
            throw new SemesterException("Mismatching IDs!");
        }

        semesterFromDb.SemId = semester.SemId;
        semesterFromDb.SemName = semester.SemName;
        _lvaContext.SaveChanges();
        _logger.LogInformation($"Semester with ID {id} successfully updated!", semester);

    }

    public void DeleteSemester(int id)
    {
        var semesterFromDb = _lvaContext.Semesters.Find(id);
        if (semesterFromDb == null)
        {
            throw new SemesterException($"Semester with ID {id} not found in Database!");
        }

        _lvaContext.Remove(semesterFromDb);
        _lvaContext.SaveChanges();
        _logger.LogInformation($"Semester with ID {id} successfully deleted!");

        
    }
}