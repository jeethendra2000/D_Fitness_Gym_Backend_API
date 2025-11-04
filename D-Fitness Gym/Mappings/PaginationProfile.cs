using AutoMapper;
using D_Fitness_Gym.Models.DTO.EmployeeDto;
using D_Fitness_Gym.Models.DTO.EnquiryDto;
using D_Fitness_Gym.Models.DTO.FeedbackDto;
using D_Fitness_Gym.Models.DTO.GymDto;
using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.DTO.OfferDto;
using D_Fitness_Gym.Models.DTO.PaginationDto;
using D_Fitness_Gym.Models.DTO.SubscriptionDto;
using D_Fitness_Gym.Models.DTO.TrainerDto;
using D_Fitness_Gym.Models.DTO.TransactionDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class PaginationProfile : Profile
    {
        public PaginationProfile()
        {
            // Map inner entities to their DTOs
            CreateMap<Gym, RetrieveGymDto>().ReverseMap();
            CreateMap<Employee, RetrieveEmployeeDto>().ReverseMap();
            CreateMap<Enquiry, RetrieveEnquiryDto>().ReverseMap();
            CreateMap<Feedback, RetrieveFeedbackDto>().ReverseMap();
            CreateMap<Offer, RetrieveOfferDto>().ReverseMap();
            CreateMap<Subscription, RetrieveSubscriptionDto>().ReverseMap();
            CreateMap<Membership, RetrieveMembershipDto>().ReverseMap();
            CreateMap<Trainer, RetrieveTrainerDto>().ReverseMap();
            CreateMap<Transaction, RetrieveTransactionDto>().ReverseMap();

            // Map PaginationMetadata<TSource> to RetrievePaginationDto<TDestination>
            // Tell AutoMapper to map inner generic types using the existing map
            // Generic mappings for pagination wrappers
            CreateMap(typeof(PaginationMetadata<>), typeof(RetrievePaginationDto<>))
                .ConvertUsing(typeof(PaginationMetadataConverter<,>));

            CreateMap(typeof(RetrievePaginationDto<>), typeof(RetrievePaginationDto<>))
                .ConvertUsing(typeof(RetrievePaginationDtoConverter<,>));
        }
    }

    // Custom converter to map PaginationMetadata<TSource> to RetrievePaginationDto<TDestination>
    public class PaginationMetadataConverter<TSource, TDestination> : ITypeConverter<PaginationMetadata<TSource>, RetrievePaginationDto<TDestination>>
    {
        public RetrievePaginationDto<TDestination> Convert(PaginationMetadata<TSource> source, RetrievePaginationDto<TDestination> destination, ResolutionContext context)
        {
            return new RetrievePaginationDto<TDestination>
            {
                CurrentPage = source.CurrentPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                TotalPages = source.TotalPages,
                Data = context.Mapper.Map<IEnumerable<TDestination>>(source.Data)
            };
        }
    }
    public class RetrievePaginationDtoConverter<TSource, TDestination> : ITypeConverter<RetrievePaginationDto<TSource>, RetrievePaginationDto<TDestination>>
    {
        public RetrievePaginationDto<TDestination> Convert(RetrievePaginationDto<TSource> source, RetrievePaginationDto<TDestination> destination, ResolutionContext context)
        {
            return new RetrievePaginationDto<TDestination>
            {
                CurrentPage = source.CurrentPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                PageSize = source.PageSize,
                TotalCount = source.TotalCount,
                TotalPages = source.TotalPages,
                Data = context.Mapper.Map<IEnumerable<TDestination>>(source.Data)
            };
        }
    }

}