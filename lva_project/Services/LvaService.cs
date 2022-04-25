using lva_project.Exceptions;
using lva_project.Models;

namespace lva_project.Services;

public interface ILvaService
{
    void CreateLva(Lva lva);
    Lva ReadLva(int id);
    IEnumerable<Lva> ReadAllLva();
    void UpdateLva(int id, Lva lva);
    void DeleteLva(int id);
    IEnumerable<Lva> ReadAllPerSemester(int semId);

}

public class LvaService : ILvaService
{
    private readonly LvaContext _lvaContext;
    private readonly ILogger<Lva> _logger;

    public LvaService(LvaContext lvaContext, ILogger<Lva> logger)
    {
        _lvaContext = lvaContext;
        _logger = logger;
    }
    public void CreateLva(Lva lva)
    {
        if (_lvaContext.Lvas.Any(l => l.LvaId.Equals(lva.LvaId)))
        {
            throw new LvaException($"LVA with ID {lva.LvaId} already exists!");
        }

        _lvaContext.Lvas.Add(lva);
        _lvaContext.SaveChanges();
        _logger.LogInformation($"LVA with ID {lva.LvaId} successfully added!", lva);
    }

    public Lva ReadLva(int id)
    {
        if (!_lvaContext.Lvas.Any(l => l.LvaId.Equals(id)))
        {
            throw new LvaException($"LVA with ID {id} not found!");
        }
        return _lvaContext.Lvas.First(l => l.LvaId.Equals(id));
    }

    public IEnumerable<Lva> ReadAllLva()
    {
        if (!_lvaContext.Lvas.Any())
        {
            _logger.LogInformation("Currently no LVAs! Holiday :)");
            throw new LvaException("No LVAs in List");
        }

        return _lvaContext.Lvas.ToList();
    }

    public IEnumerable<Lva> ReadAllPerSemester(int semId)
    {
        if (!_lvaContext.Lvas.Any())
        {
            _logger.LogInformation("Currently no LVAs! Holiday :)");
            throw new LvaException("No LVAs in List");
        }

        return _lvaContext.Lvas.ToList().FindAll(l => l.SemId.Equals(semId));
    }

    public void UpdateLva(int id, Lva lva)
    {
        var lvaFromDb = _lvaContext.Lvas.Find(id);
        if (lvaFromDb == null)
        {
            throw new LvaException($"LVA with ID {id} not found in Database!");
        }

        if (id != lva.LvaId)
        {
            throw new LvaException("Mismatching IDs!");
        }

        //update the LVA in the database with the new values
        lvaFromDb.LvaExam = lva.LvaExam;
        lvaFromDb.LvaInstitute = lva.LvaInstitute;
        lvaFromDb.LvaName = lva.LvaName;
        lvaFromDb.LvaRoom = lva.LvaRoom;
        lvaFromDb.LvaNumber = lva.LvaNumber;
        lvaFromDb.LvaCreatedOn = lva.LvaCreatedOn;
        lvaFromDb.LvaTeacher = lva.LvaTeacher;
        lvaFromDb.LvaType = lva.LvaType;
        
        _lvaContext.SaveChanges();
        _logger.LogInformation($"LVA with ID {id} successfully updated!", lva);
    }

    public void DeleteLva(int id)
    {
        var lvaFromDb = _lvaContext.Lvas.Find(id);
        if (lvaFromDb == null)
        {
            throw new LvaException($"LVA with ID {id} not found in Database!");
        }

        _lvaContext.Remove(lvaFromDb);
        _lvaContext.SaveChanges();
        _logger.LogInformation($"LVA with ID {id} successfully deleted!");
    }
}