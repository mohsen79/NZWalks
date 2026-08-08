using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController(NZWalksDbContext dbContext) : ControllerBase
{
    private readonly NZWalksDbContext _db = dbContext;

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Region> regions = _db.Region.ToList();
        List<RegionDto> reginoDto = [];

        foreach (Region region in regions)
        {
            reginoDto.Add(new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            });
        }

        return Ok(reginoDto);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(Guid id)
    {
        Region region = _db.Region.FirstOrDefault(r => r.Id == id);
        RegionDto regionDto = new RegionDto
        {
            Id = region.Id,
            Code = region.Code,
            Name = region.Name,
            RegionImageUrl = region.RegionImageUrl
        };

        if (region == null) return NotFound();

        return Ok(regionDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        Region newRegion = new Region
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl,
        };

        _db.Region.Add(newRegion);
        _db.SaveChanges();

        RegionDto regionDto = new RegionDto
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl,
        };

        return RedirectToAction(nameof(GetById), new { id = regionDto.Id });
    }
}