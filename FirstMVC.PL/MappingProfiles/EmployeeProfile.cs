using AutoMapper;
using FirstMVC.DAL.Model;
using FirstMVC.PL.ViewModels;

namespace FirstMVC.PL.MappingProfiles
{
    public class EmployeeProfile:Profile
    {

        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap(); 
        }

    }
}
