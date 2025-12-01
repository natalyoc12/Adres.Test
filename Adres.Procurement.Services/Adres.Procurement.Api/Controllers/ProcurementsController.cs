using Adres.Procurement.Api.Configurations;
using Adres.Procurement.Api.Dtos;
using Adres.Procurement.Api.Response;
using Adres.Procurement.Api.Utils;
using Adres.Procurement.Application.Procurements.Commands;
using Adres.Procurement.Application.Procurements.Queries;
using Adres.Procurement.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Adres.Procurement.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class ProcurementsController(IMediator mediator,
    IOptions<FileStorageOptions> storageOptions) : CustomControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly string _storagePath = storageOptions.Value.Path;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProcurementDto>>>> GetList()
    {
        IEnumerable<ProcurementEntity> procurements = await _mediator.Send(new GetProcurementsQuery());
        return OkResponse(procurements.Adapt<IEnumerable<ProcurementDto>>());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<ProcurementDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<IDictionary<string, string[]>>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<ProcurementDto>>> GetById(Guid id)
    {
        ProcurementEntity procurement = await _mediator.Send(new GetProcurementByIdQuery(id));
        ProcurementDto procurementDto = procurement.Adapt<ProcurementDto>();

        return OkResponse(procurementDto with { Files = BuildFilesDto(procurement.Files) });
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<ApiResponse<ProcurementDto>>> Create([FromForm] CreateProcurementCommandDto dto)
    {
        IEnumerable<ProcurementFileEntity> files = [];

        if (dto.Files != null && dto.Files.Any())
        {
            files = dto.Files.Select(file => new ProcurementFileEntity()
            {
                FileName = file.FileName,
                Size = file.Length,
                ContentType = file.ContentType,
                Content = FileUtils.GetFileBytes(file)
            });
        }

        var command = new CreateProcurementCommand(
            dto.Budget,
            dto.Entity,
            dto.Item,
            dto.Quantity,
            dto.UnitPrice,
            dto.Date,
            dto.Supplier,
            files,
            _storagePath
        );

        ProcurementEntity procurement = await _mediator.Send(command);
        return CreatedResponse(nameof(GetById), new { id = procurement.Id }, procurement.Adapt<ProcurementDto>());
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ApiResponse<object>>> Update(Guid id, UpdateProcurementDto dto)
    {
        UpdateProcurementCommand command = dto.Adapt<UpdateProcurementCommand>();
        UpdateProcurementCommand updatedCommand = command with { Id = id };

        await _mediator.Send(updatedCommand);
        return OkResponse<object>(null);
    }

    [HttpPatch("{id:guid}/status/{status}")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateStatus(Guid id, string status)
    {
        UpdateProcurementStatusCommand command = new(id, status);
        await _mediator.Send(command);

        return OkResponse<object>(null);
    }

    [HttpGet("{procurementId:guid}/files/{fileId:guid}")]
    public async Task<IActionResult> DownloadFile(Guid procurementId, Guid fileId)
    {
        ProcurementFileEntity file = await _mediator.Send(new GetProcurementFileQuery(procurementId, fileId));
        byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(file.FilePath);

        return File(fileBytes, file.ContentType, file.FileName);
    }

    private IEnumerable<ProcurementFileDto> BuildFilesDto(IEnumerable<ProcurementFileEntity> files)
    {
        string baseUrl = $"{Request.Scheme}://{Request.Host}";

        return [.. files.Select(file => new ProcurementFileDto(
            file.Id,
            file.FileName,
            file.ContentType,
            file.Size,
            $"{baseUrl}/api/v1/procurements/{file.ProcurementId}/files/{file.Id}"
        ))];
    }
}
