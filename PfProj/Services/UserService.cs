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
    void Create(CreateRequest model);
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

    public void Create(CreateRequest model)
    {
        // map model to new object
        var target = _mapper.Map<DataModel>(model);

        // generate reader and perform calculations
        var reader = new Reader();
        int observationLimit = 500;
        //if (model.ObservationLimit != null)
        //    observationLimit = (int) model.ObservationLimit;
        reader.ReadFile(model.FilePath, observationLimit);
        // fetch from reader
        List<double> rm = reader.getrm();
        List<double> medv = reader.getmedv();
        // calculate variables
        DataModeling calculator = new DataModeling();
        target.Covar = calculator.covar(rm,medv);
        target.Cor = calculator.cor(rm,medv);
        target.NumObservations = reader.getObservations();
        // save
        _context.DataModels.Add(target);
        _context.SaveChanges();
    }
    public void Update(int id, UpdateRequest model)
    {
        var target = getModel(id);
        
        // generate reader and perform calculations
        var reader = new Reader();
        int observationLimit = 500;
        //if (model.ObservationLimit != null)
        //    observationLimit = (int) model.ObservationLimit;
        reader.ReadFile(model.FilePath, observationLimit);
        // fetch from reader
        List<double> rm = reader.getrm();
        List<double> medv = reader.getmedv();
        // calculate variables
        DataModeling calculator = new DataModeling();
        target.Covar = calculator.covar(rm,medv);
        target.Cor = calculator.cor(rm,medv);
        target.NumObservations = reader.getObservations();
        
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