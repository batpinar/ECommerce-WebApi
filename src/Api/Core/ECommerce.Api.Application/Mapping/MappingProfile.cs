using AutoMapper;
using ECommerce.Api.Application.Features.Commands.CategoryCommands.CreateCategoryCommands;
using ECommerce.Api.Application.Features.Commands.CategoryCommands.UpdateCategoryCommands;
using ECommerce.Api.Application.Features.Commands.ProductBrandCommands.CreateProductBrandCommands;
using ECommerce.Api.Application.Features.Commands.ProductModelCommands.CreateProductModelCommands;
using ECommerce.Api.Application.Features.Commands.ProductModelCommands.UpdateProductModelCommands;
using ECommerce.Api.Domain.Models;
using ECommerce.Common.Models.Queries;
using ECommerce.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region User Mapping
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();
            CreateMap<User, GetUserDetailViewModel>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            #endregion

            #region Category Mapping
            CreateMap<CreateCategoryCommand, Category>()
                .ReverseMap();
            CreateMap<Category, GetCategoryViewModel>()
                .ForMember(x => x.ProductBrandCount, y => y.MapFrom(z => z.ProductBrands.Count));
            CreateMap<Category, GetAllCategoryViewModel>()
                .ForMember(x => x.ProductBrandCount, y => y.MapFrom(z => z.ProductBrands.Count));
            #endregion

            #region ProductBrand Mapping
            CreateMap<CreateProductBrandCommand, ProductBrand>()
                .ReverseMap();
            CreateMap<ProductBrand, GetProductBrandViewModel>()
                .ForMember(x => x.ProductModelCount, y => y.MapFrom(z => z.ProductModels.Count));
            CreateMap<ProductBrand, GetAllProductBrandViewModel>()
                .ForMember(x => x.ProductModelCount, y => y.MapFrom(z => z.ProductModels.Count));
            #endregion

            #region ProductModel Mapping
            CreateMap<CreateProductModelCommand, ProductModel>()
    .ReverseMap();
            CreateMap<UpdateProductModelCommand, ProductModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
            #endregion
        }
    }
}
