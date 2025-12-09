import {
  Component,
  EventEmitter,
  Input,
  Output,
  TemplateRef,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

export interface Column {
  header: string;
  accessor: string;
  sortable?: boolean;
  cell?: (item: any) => any;
  template?: TemplateRef<any>;
}

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent {
  @Input() data: any[] = [];
  @Input() columns: Column[] = [];

  @Input() sortColumn?: string;
  @Input() sortDirection?: 'asc' | 'desc';
  @Output() onSort = new EventEmitter<string>();
  @Output() cellAction = new EventEmitter<{ action: string; id: string }>();

  sort(column: string) {
    this.onSort.emit(column);
  }

  getCellValue(item: any, accessor: string) {
    if (!accessor) return '';

    const parts = accessor.split('.');
    let value = item;
    
    for (const p of parts) {
      if (value == null) return '';
      value = value[p];
    }

    return value;
  }

  constructor(private readonly sanitizer: DomSanitizer) { }

  toHtml(value: any): SafeHtml {
    if (value == null) return '';
    return this.sanitizer.bypassSecurityTrustHtml(String(value));
  }

  onTableClick(event: Event) {
    const target = event.target as HTMLElement | null;
    
    if (!target) return;

    const el = target.closest('[data-action][data-id]');
    
    if (!el) return;
    
    const htmlEl = el as HTMLElement;
    const action = htmlEl.dataset['action'];
    const id = htmlEl.dataset['id'];
    
    if (action && id) {
      this.cellAction.emit({ action, id });
    }
  }
}
