using backend.Data;
using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class ResourceService : IResourceService
{
    private readonly AppDbContext _context;

    public ResourceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ResourceDto>> GetAllResourcesAsync()
    {
        return await _context.Resources
            .Select(r => new ResourceDto { Id = r.Id, Name = r.Name })
            .ToListAsync();
    }

    public async Task<ResourceDto> CreateResourceAsync(CreateResourceDto dto)
    {
        var resource = new Resource { Name = dto.Name };
        _context.Resources.Add(resource);
        await _context.SaveChangesAsync();

        return new ResourceDto { Id = resource.Id, Name = resource.Name };
    }

    public async Task<List<SlotDto>> GetResourceSlotsAsync(int resourceId)
    {
        return await _context.Slots
            .Where(s => s.ResourceId == resourceId)
            .OrderBy(s => s.StartTime)
            .Select(s => new SlotDto
            {
                Id = s.Id,
                ResourceId = s.ResourceId,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                BookedByUserId = s.BookedByUserId
            })
            .ToListAsync();
    }

    public async Task GenerateSlotsForResourceAsync(int resourceId, DateTime date)
    {
        var resourceExists = await _context.Resources.AnyAsync(r => r.Id == resourceId);
        if (!resourceExists) throw new Exception("Resource not found");

        var startTime = date.Date.AddHours(9);
        var endTime = date.Date.AddHours(18);

        var existingSlots = await _context.Slots
            .AnyAsync(s => s.ResourceId == resourceId && s.StartTime >= startTime && s.StartTime < endTime);

        if (existingSlots) throw new Exception("Slots for this date already exist.");

        var currentSlotTime = startTime;
        while (currentSlotTime < endTime)
        {
            _context.Slots.Add(new Slot
            {
                ResourceId = resourceId,
                StartTime = currentSlotTime,
                EndTime = currentSlotTime.AddHours(1)
            });
            currentSlotTime = currentSlotTime.AddHours(1);
        }

        await _context.SaveChangesAsync();
    }
}