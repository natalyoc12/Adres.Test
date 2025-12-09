import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  @ViewChild('menuContainer', { read: ElementRef }) menuContainer!: ElementRef;

  isDropdownOpen = false;

  notifications = [
    { title: 'Nueva adquisición pendiente', time: 'Hace 2 minutos' },
    { title: 'Aprobación de presupuesto requerida', time: 'Hace 1 hora' },
  ];

  toggleDropdown(event?: Event) {
    if (event) {
      event.stopPropagation();
    }
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  closeDropdown() {
    this.isDropdownOpen = false;
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const target = event.target as HTMLElement;
    if (!this.menuContainer) return;
    if (!this.menuContainer.nativeElement.contains(target)) {
      this.isDropdownOpen = false;
    }
  }
}
