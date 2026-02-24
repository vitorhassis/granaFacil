using AutoMapper;
using GranaFacil.Models;
using GranaFacil.Data.Dtos.Entrada;
using GranaFacil.Data.Dtos.Gasto;
using GranaFacil.Data.Dtos.Reserva;

namespace GranaFacil.Profiles
{
    public class EntradaProfile : Profile
    {
        public EntradaProfile()
        {
            // =========================
            // ENTRADA
            // =========================
            CreateMap<Entrada, ReadEntradaDto>();

            CreateMap<CreateEntradaDto, Entrada>();
            CreateMap<UpdateEntradaDto, Entrada>();


            // =========================
            // RESERVA
            // =========================
            CreateMap<Reserva, ReadReservaDto>();

            CreateMap<CreateReservaDto, Reserva>();
            CreateMap<UpdateReservaDto, Reserva>();


            // =========================
            // GASTO
            // =========================
            CreateMap<Gasto, ReadGastoDto>();

            CreateMap<CreateGastoDto, Gasto>();
            CreateMap<UpdateGastoDto, Gasto>();
        }
    }
}