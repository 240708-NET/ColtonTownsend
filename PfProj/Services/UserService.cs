namespace PfProj.Services;

using AutoMapper;
using PfProj.Entities;
using PfProj.Helpers;
using PfProj.Models.DataModels;
using Services;

public interface ISharedService
{
    IEnumerable<DataModel> GetAll();
    DataModel GetById(int id);
    bool Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class ModelService : ISharedService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ModelService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<DataModel> GetAll()
    {
        return _context.DataModels;
    }

    public DataModel GetById(int id)
    {
        return getModel(id);
    }

    public bool Create(CreateRequest model)
    {
        // map model to new object
        var target = _mapper.Map<DataModel>(model);

        // generate reader and read
        var reader = new Reader();
        int observationLimit = 500;
        if (target.ObservationLimit != null)
            observationLimit = (int) target.ObservationLimit;
        reader.ReadFile(target.FilePath, observationLimit, target.TestingColName, target.TargetColName);
        // fetch from reader
        List<double> TestingColName = reader.getrm(); // test;rm
        List<double> TargetColName = reader.getmedv(); // target;medv
        if (!TestingColName.Any() || !TargetColName.Any()){ // bad colnames or filename
            Console.WriteLine("Bad ColName or FileName");
            return false;
        }
        // calculate variables
        DataModeling calculator = new DataModeling();
        target.Covar = calculator.covar(TestingColName,TargetColName);
        target.Cor = calculator.cor(TestingColName,TargetColName);
        target.NumObservations = reader.getObservations();
        // save
        _context.DataModels.Add(target);
        _context.SaveChanges();
        return true;
    }
    public void Update(int id, UpdateRequest model)
    {
        var target = getModel(id);
        
        _mapper.Map(model, target);
        _context.DataModels.Update(target);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var target = getModel(id);
        _context.DataModels.Remove(target);
        _context.SaveChanges();
    }

    // helper methods

    private DataModel getModel(int id)
    {
        var target = _context.DataModels.Find(id);
        if (target == null) throw new KeyNotFoundException("ID not found");
        return target;
    }
}