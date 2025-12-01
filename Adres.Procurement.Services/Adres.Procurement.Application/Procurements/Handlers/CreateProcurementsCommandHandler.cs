using Adres.Procurement.Application.Procurements.Commands;
using Adres.Procurement.Domain.Entities;
using Adres.Procurement.Domain.Interfaces;
using MediatR;

namespace Adres.Procurement.Application.Procurements.Handlers;

public class CreateProcurementCommandHandler(
    IProcurementRepository repository) : IRequestHandler<CreateProcurementCommand, ProcurementEntity>
{
    private readonly IProcurementRepository _repository = repository;

    public async Task<ProcurementEntity> Handle(CreateProcurementCommand request, CancellationToken cancellationToken)
    {
        ProcurementEntity.ProcurementInfo procurementRecord = new(
            request.Budget,
            request.Entity,
            request.Item,
            request.Quantity,
            request.UnitPrice,
            request.UnitPrice * (decimal)request.Quantity,
            request.Date,
            request.Supplier,
            request.Files,
            true
        );

        ProcurementEntity procurement = new(procurementRecord)
        {
            Files = await BuildProcurementFiles(request, cancellationToken)
        };

        return await _repository.SaveAsync(procurement);
    }

    private static async Task<List<ProcurementFileEntity>> BuildProcurementFiles(CreateProcurementCommand request, CancellationToken cancellationToken)
    {
        List<ProcurementFileEntity> files = [];

        foreach (ProcurementFileEntity file in request.Files)
        {
            string fileName = $"{Guid.NewGuid()}.{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(request.StoragePath, fileName);

            Directory.CreateDirectory(request.StoragePath);

            await File.WriteAllBytesAsync(filePath, file.Content, cancellationToken);

            ProcurementFileEntity fileEntity = new()
            {
                FileName = file.FileName,
                FilePath = filePath,
                ContentType = file.ContentType,
                Size = file.Content.Length
            };

            files.Add(fileEntity);
        }

        return files;
    }
}
