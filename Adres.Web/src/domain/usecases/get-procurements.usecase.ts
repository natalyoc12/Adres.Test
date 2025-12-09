import { Observable } from 'rxjs';
import { UseCase } from '../base/use-case';
import { PaginatedDataModel } from '../models/paginated-data.model';
import { ProcurementRepository } from '../repositories/procurement.respository';
import { ProcurementModel } from '../models/procurement.model';
import { FilterValues } from '../models/filters.model';

export class GetProcurementsUseCase
  implements
    UseCase<
      { filter: FilterValues; page: number; pageSize: number },
      PaginatedDataModel<ProcurementModel>
    >
{
  constructor(private readonly procurementRepository: ProcurementRepository) {}

  execute(params: {
    page: number;
    pageSize: number;
    filter: FilterValues;
  }): Observable<PaginatedDataModel<ProcurementModel>> {
    return this.procurementRepository.getProcurements(
      params.page,
      params.pageSize,
      params.filter
    );
  }
}
