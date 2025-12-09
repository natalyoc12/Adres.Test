import { Observable } from 'rxjs';
import { ProcurementModel } from '../models/procurement.model';
import { PaginatedDataModel } from '../models/paginated-data.model';
import { FilterValues } from '../models/filters.model';

export abstract class ProcurementRepository {
  abstract getProcurements(
    page: number,
    pageSize: number,
    filters: FilterValues
  ): Observable<PaginatedDataModel<ProcurementModel>>;

  abstract getProcurement(id: string): Observable<ProcurementModel>;
}
