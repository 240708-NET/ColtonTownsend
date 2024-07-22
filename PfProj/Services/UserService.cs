namespace PfProj.Services;

using AutoMapper;
using BCrypt.Net;
using PfProj.Entities;
using PfProj.Helpers;
using PfProj.Models.DataModels;

public interface IUserService
{
    IEnumerable<DataModel> GetAll();
    DataModel GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class UserService : IUserService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public UserService(
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

        // save
        _context.DataModels.Add(target);
        _context.SaveChanges();
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