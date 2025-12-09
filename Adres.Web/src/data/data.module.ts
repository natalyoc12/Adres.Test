import { ProcurementImplRepository } from './procurement/repositories/procurements-impl.repository';
import { ProcurementRepository } from '../domain/repositories/procurement.respository';
import { GetProcurementUseCase } from '../domain/usecases/get-procurement.usecase';
import { GetProcurementsUseCase } from '../domain/usecases/get-procurements.usecase';

export const PROCUREMENT_PROVIDERS = [
  { provide: ProcurementRepository, useClass: ProcurementImplRepository },
  {
    provide: GetProcurementsUseCase,
    deps: [ProcurementRepository],
    useFactory: (repo: ProcurementRepository) =>
      new GetProcurementsUseCase(repo),
  },
  {
    provide: GetProcurementUseCase,
    deps: [ProcurementRepository],
    useFactory: (repo: ProcurementRepository) =>
      new GetProcurementUseCase(repo),
  },
];
