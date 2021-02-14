using Application.Features.Persons.Queries.GetAllPersons;
using Application.Features.Products.Commands.CreatePerson;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdatePerson;
using Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllPersonsQuery, GetAllPersonsParameter>();
            CreateMap<CreatePersonCommand, Person>();

            CreateMap<Person, UpdatePersonCommand>().ReverseMap(); ;
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<Person, GetAllPersonsViewModel>().ReverseMap();
        }
    }
}
