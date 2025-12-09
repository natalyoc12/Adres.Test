import {
  Component,
  TemplateRef,
  ViewChild,
  AfterViewInit,
  ChangeDetectorRef,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  TableComponent,
  Column,
} from '../../shared/components/table/table.component';
import { PaginationComponent } from '../../shared/components/pagination/pagination.component';
import { RouterModule } from '@angular/router';
import { FiltersComponent } from '../../shared/components/filters/filters.component';
import { StatusBadgeComponent } from '../../shared/components/status-badge/status-badge.component';
import { GetProcurementsUseCase } from '../../../../domain/usecases/get-procurements.usecase';
import { firstValueFrom } from 'rxjs';
import { ProcurementModel } from '../../../../domain/models/procurement.model';
import { FilterValues } from '../../../../domain/models/filters.model';

@Component({
  selector: 'app-procurement',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableComponent,
    PaginationComponent,
    FiltersComponent,
    RouterModule,
    StatusBadgeComponent,
  ],
  templateUrl: './procurement.component.html',
  styleUrls: ['./procurement.component.css'],
})
export class ProcurementComponent implements AfterViewInit {
  constructor(
    private readonly cd: ChangeDetectorRef,
    private readonly getProcurementsUseCase: GetProcurementsUseCase
  ) {}

  filters: FilterValues = {
    search: '',
    entity: '',
    supplier: '',
    item: '',
    dateFrom: '',
    dateTo: '',
    includeInactive: false,
  };

  currentPage = 1;
  pageSize = 10;
  totalPages = 1;
  totalItems = 0;
  sortColumn = '';
  sortDirection: 'asc' | 'desc' = 'asc';
  deactivateId: string | null = null;

  sortedData: ProcurementModel[] = [];
  pagedData: ProcurementModel[] = [];

  procurments: ProcurementModel[] = [];

  columns: Column[] = [];

  @ViewChild('statusTpl', { static: true }) statusTpl!: TemplateRef<any>;
  @ViewChild('actionsTpl', { static: true }) actionsTpl!: TemplateRef<any>;

  ngAfterViewInit(): void {
    this.columns = [
      {
        header: 'Presupuesto',
        accessor: 'budget',
        sortable: true,
        cell: (item: ProcurementModel) => `$${item.budget.toLocaleString()}`,
      },
      { header: 'Unidad', accessor: 'entity', sortable: true },
      {
        header: 'Tipo de Bien o Servicio',
        accessor: 'item',
        sortable: true,
      },
      { header: 'Cantidad', accessor: 'quantity', sortable: true },
      {
        header: 'Valor Unitario',
        accessor: 'unitPrice',
        cell: (item: ProcurementModel) => `$${item.unitPrice.toLocaleString()}`,
      },
      {
        header: 'Valor Total',
        accessor: 'totalPrice',
        sortable: true,
        cell: (item: ProcurementModel) =>
          `<span class="font-semibold">$${item.totalPrice.toLocaleString()}</span>`,
      },
      {
        header: 'Fecha',
        accessor: 'date',
        sortable: true,
        cell: (item: ProcurementModel) =>
          new Date(item.date).toLocaleDateString(),
      },
      { header: 'Proveedor', accessor: 'supplier', sortable: true },
      {
        header: 'Estado',
        accessor: 'includeInactive',
        template: this.statusTpl,
      },
      { header: 'Acción', accessor: 'id', template: this.actionsTpl },
    ];

    this.getProcurements();
    this.cd.detectChanges();
  }

  private getProcurements() {
    const procurments$ = this.getProcurementsUseCase.execute({
      page: this.currentPage,
      pageSize: this.pageSize,
      filter: this.filters,
    });

    firstValueFrom(procurments$).then((result) => {
      this.pagedData = result.records || [];
      this.totalPages = result.totalPages || 1;
      this.totalItems = result.totalRecords || 0;
    });
  }

  private recalc() {
    if (this.sortColumn) {
      this.pagedData.sort((a: any, b: any) => this.compareForSort(a, b));
    }
  }

  private compareForSort(a: any, b: any) {
    const av = a[this.sortColumn as keyof ProcurementModel];
    const bv = b[this.sortColumn as keyof ProcurementModel];
    if (av == null) return -1;
    if (bv == null) return 1;
    if (typeof av === 'number' && typeof bv === 'number')
      return (av - bv) * (this.sortDirection === 'asc' ? 1 : -1);
    return (
      String(av).localeCompare(String(bv)) *
      (this.sortDirection === 'asc' ? 1 : -1)
    );
  }

  handleSort(column: string) {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }
    this.recalc();
  }

  handleFilterChange(val: FilterValues) {
    this.filters = val;
    this.currentPage = 1;
    this.getProcurements();
  }

  changePage(page: number) {
    this.currentPage = Math.max(1, Math.min(this.totalPages, page));
    this.getProcurements();
  }

  changePageSize(size: number) {
    this.pageSize = size;
    this.currentPage = 1;
    this.getProcurements();
  }
}
