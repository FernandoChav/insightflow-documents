using AutoMapper;
using InsightFlow.Documents.Api.Application.DTOs;
using InsightFlow.Documents.Api.Domain.Entities;

namespace InsightFlow.Documents.Api.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // 1. De Request a Entidad (CreateDocumentDto -> Document)
            CreateMap<CreateDocumentDto, Document>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.UserId)) // Mapeo manual de UserId -> OwnerId
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon ?? "📄")) // Valor por defecto si es nulo
                .ForMember(dest => dest.Content, opt => opt.Ignore()) // El contenido se inicializa vacío manualmente o en constructor
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            // 2. De Entidad a Response (Document -> DocumentResponse)
            CreateMap<Document, DocumentResponse>();

            // 3. Para Update (UpdateDocumentDto -> Document)
            // Usamos ForAllMembers para ignorar nulos automáticamente si quisieras, 
            // pero en PATCH solemos hacerlo manual en el servicio para control fino. 
            // Dejaremos este mapeo básico por si acaso.
            CreateMap<UpdateDocumentDto, Document>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}