import { Observable } from 'rxjs';
import { UseCase } from '../base/use-case';
import { ProcurementModel } from '../models/procurement.model';
import { ProcurementRepository } from '../repositories/procurement.respository';

export class GetProcurementUseCase
  implements UseCase<{ id: string }, ProcurementModel>
{
  constructor(private readonly procurementRepository: ProcurementRepository) {}

  execute(params: { id: string }): Observable<ProcurementModel> {
    return this.procurementRepository.getProcurement(params.id);
  }
}
