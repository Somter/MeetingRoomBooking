using backend.DTOs;

namespace backend.Interfaces
{
    public interface IResourceService
    {
        Task<List<ResourceDto>> GetAllResourcesAsync();
        Task<ResourceDto> CreateResourceAsync(CreateResourceDto dto);
        Task<List<SlotDto>> GetResourceSlotsAsync(int resourceId);
        Task GenerateSlotsForResourceAsync(int resourceId, DateTime date);
    }
}
