using AutoMapper;
using GranaFacil.Data.Dtos.Conta;
using GranaFacil.Data.Dtos.Entrada;
using GranaFacil.Data.Dtos.Gasto;
using GranaFacil.Data.Dtos.Meta;
using GranaFacil.Data.Dtos.Reserva;
using GranaFacil.Data.Dtos.Usuario;
using GranaFacil.Models;

namespace GranaFacil.Profiles
{
    public class GranaFacilProfile : Profile
    {
        public GranaFacilProfile()
        {
            CreateMap<CreateEntradaDto, Entrada>();
            CreateMap<UpdateEntradaDto, Entrada>(); 
            CreateMap<Entrada, ReadEntradaDto>();

            CreateMap<CreateReservaDto, Reserva>();
            CreateMap<UpdateReservaDto, Reserva>();
            CreateMap<Reserva, ReadReservaDto>();

            CreateMap<CreateGastoDto, Gasto>();
            CreateMap<UpdateGastoDto, Gasto>();
            CreateMap<Gasto, ReadGastoDto>();

            CreateMap<CreateContaDto, Conta>();
            CreateMap<UpdateContaDto, Conta>();
            CreateMap<Conta, ReadContaDto>();

            CreateMap<CreateMetaDto, Meta>();
            CreateMap<UpdateMetaDto, Meta>();
            CreateMap<Meta, ReadMetaDto>();

            CreateMap<RegisterUsuarioDto, Usuario>();
            CreateMap<Usuario, ReadUsuarioDto>();

        }
    }
}