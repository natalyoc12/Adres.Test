import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css'],
})
export class PaginationComponent {
  @Input() currentPage = 1;
  @Input() totalPages = 1;
  @Input() pageSize = 10;
  @Input() totalItems = 0;

  @Output() pageChange = new EventEmitter<number>();
  @Output() pageSizeChange = new EventEmitter<number>();

  get startItem(): number {
    return (this.currentPage - 1) * this.pageSize + 1;
  }

  get endItem(): number {
    return Math.min(this.currentPage * this.pageSize, this.totalItems);
  }

  get pageButtons(): number[] {
    const maxButtons = Math.min(5, this.totalPages || 1);
    const pages: number[] = [];
    for (let i = 0; i < maxButtons; i++) {
      let pageNumber: number;
      if (this.totalPages <= 5) {
        pageNumber = i + 1;
      } else if (this.currentPage <= 3) {
        pageNumber = i + 1;
      } else if (this.currentPage >= this.totalPages - 2) {
        pageNumber = this.totalPages - 4 + i;
      } else {
        pageNumber = this.currentPage - 2 + i;
      }

      if (pageNumber < 1) pageNumber = 1;
      if (pageNumber > this.totalPages) pageNumber = this.totalPages;
      if (!pages.includes(pageNumber)) pages.push(pageNumber);
    }
    return pages;
  }

  changePage(page: number) {
    if (page < 1) page = 1;
    if (page > this.totalPages) page = this.totalPages;
    if (page === this.currentPage) return;
    this.pageChange.emit(page);
  }

  changePageSize(value: string | number) {
    const size = typeof value === 'string' ? Number(value) : value;
    if (!Number.isNaN(size) && size > 0) {
      this.pageSizeChange.emit(size);
    }
  }
}
