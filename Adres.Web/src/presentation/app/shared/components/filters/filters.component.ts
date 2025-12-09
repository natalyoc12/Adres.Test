import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
} from '@angular/forms';
import { FilterValues } from '../../../../../domain/models/filters.model';

@Component({
  selector: 'app-filters',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css'],
})
export class FiltersComponent {
  @Output() filterChange = new EventEmitter<FilterValues>();

  filtrosForm: FormGroup;

  constructor(private readonly fb: FormBuilder) {
    this.filtrosForm = this.fb.group({
      search: [''],
      entity: [''],
      supplier: [''],
      item: [''],
      dateFrom: [null],
      dateTo: [null],
      includeInactive: ['active'],
    });
  }

  updateFilter() {
    const filtros = this.filtrosForm.value;
    filtros.includeInactive = this.getStatusValue(filtros.includeInactive);
    this.filterChange.emit(filtros);
  }

  getStatusValue(status: string) {
    if (status === 'active') return false; // Only actives
    if (status === 'inactive') return true; // Include inactives
    return '';
  }

  resetFilters() {
    this.filtrosForm.reset();
    this.filtrosForm.controls['includeInactive'].setValue('active');
    this.updateFilter();
  }
}
