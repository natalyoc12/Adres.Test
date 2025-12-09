import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-status-badge',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './status-badge.component.html',
  styleUrls: ['./status-badge.component.css'],
})
export class StatusBadgeComponent {
  @Input() status: boolean = true;
  @Input() className = '';

  get label(): string {
    return this.status ? 'Activo' : 'Inactivo';
  }

  get classes(): Record<string, boolean> {
    return {
      'badge-base': true,
      'badge-active': this.status === true,
      'badge-inactive': this.status === false,
    };
  }
}
