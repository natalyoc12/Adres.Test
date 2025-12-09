import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-separator',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './separator.component.html',
  styleUrls: ['./separator.component.css'],
})
export class SeparatorComponent {
  @Input() className = '';
  @Input() orientation: 'horizontal' | 'vertical' = 'horizontal';
  @Input() decorative = true;

  get computedClass(): string {
    const base = 'bg-border shrink-0';
    const orientClass =
      this.orientation === 'horizontal'
        ? 'data-[orientation=horizontal]:h-px data-[orientation=horizontal]:w-full'
        : 'data-[orientation=vertical]:h-full data-[orientation=vertical]:w-px';
    return `${base} ${orientClass} ${this.className}`.trim();
  }
}
