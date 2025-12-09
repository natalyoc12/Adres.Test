import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ProcurementModel } from '../../../domain/models/procurement.model';
import { PaginatedDataModel } from '../../../domain/models/paginated-data.model';
import { ProcurementMapper } from '../mapper/procurement.mapper';
import { ProcurementRepository } from '../../../domain/repositories/procurement.respository';
import { ProcurementEntity } from '../entities/procurement-entity';
import { APIResponse } from '../entities/api-response-entity';
import { FilterValues } from '../../../domain/models/filters.model';

@Injectable({
  providedIn: 'root',
})
export class ProcurementImplRepository extends ProcurementRepository {
  private readonly procurementMapper = new ProcurementMapper();
  private readonly BASE_URL = 'http://localhost:8080/api/v1';

  constructor(private readonly http: HttpClient) {
    super();
  }

  override getProcurements(
    page: number,
    pageSize: number,
    filters: FilterValues
  ): Observable<PaginatedDataModel<ProcurementModel>> {
    let params = new HttpParams();
    params = params.append('entity', filters.entity || '');
    params = params.append('supplier', filters.supplier || '');
    params = params.append('item', filters.item || '');
    params = params.append(
      'includeInactive',
      String(filters.includeInactive || false)
    );
    if (filters.dateFrom) {
      params = params.append('dateFrom', filters.dateFrom);
    }
    if (filters.dateTo) {
      params = params.append('dateTo', filters.dateTo);
    }
    params = params.append('search', filters.search || '');
    params = params.append('page', page.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http
      .get<APIResponse<PaginatedDataModel<ProcurementEntity>>>(
        `${this.BASE_URL}/procurements`,
        { params }
      )
      .pipe(map((response) => response.data));
  }

  override getProcurement(id: string): Observable<ProcurementModel> {
    return this.http
      .get<APIResponse<ProcurementEntity>>(
        `${this.BASE_URL}/procurements/${id}`
      )
      .pipe(map((response) => this.procurementMapper.mapFrom(response.data)));
  }
}
