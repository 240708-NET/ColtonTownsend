namespace PfProj.Helpers;

using AutoMapper;
using PfProj.Entities;
using PfProj.Models.DataModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> Model
        CreateMap<CreateRequest, DataModel>();

        // UpdateRequest -> Model
        CreateMap<UpdateRequest, DataModel>();
    }
}