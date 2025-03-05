using AutoMapper;
using MyMongoProject.Dtos.CategoryDtos;
using MyMongoProject.Dtos.CustomerDtos;
using MyMongoProject.Dtos.DepartmentDtos;
using MyMongoProject.Dtos.DiscountDtos;
using MyMongoProject.Dtos.ProductDtos;
using MyMongoProject.Dtos.SellingDtos;
using MyMongoProject.Entities;

namespace MyMongoProject.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();


            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Department, ResultDepartmentDto>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentDto>().ReverseMap();

            CreateMap<Customer, ResultCustomerWithCategoryDto>().ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.DepartmentName));


            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryCto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();


            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ForMember(x => x.CategoryId, y => y.MapFrom(z => z.Category.CategoryName));

            CreateMap<Selling,CreateSellingDto>().ReverseMap();
            CreateMap<Selling,GetByIdSellingDto>().ReverseMap();
            CreateMap<Selling,ResultSellingDto>().ForMember(x=>x.ProductId,y=>y.MapFrom(z=>z.Product.ProductName));


        }
    }
}
