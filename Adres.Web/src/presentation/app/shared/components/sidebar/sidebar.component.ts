import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule, NavigationEnd } from '@angular/router';
import { Subscription } from 'rxjs';

type NavItem = { name: string; href: string };

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnDestroy {
  navigation: NavItem[] = [{ name: 'Adquisiciones', href: '' }];

  currentPath = '';
  private readonly sub: Subscription;

  constructor(private readonly router: Router) {
    this.currentPath = this.router.url || '/';
    this.sub = this.router.events.subscribe((e) => {
      if (e instanceof NavigationEnd) {
        this.currentPath = e.urlAfterRedirects || e.url;
      }
    });
  }

  isActive(href: string) {
    if (href === '/') return this.currentPath === '/';
    return this.currentPath === href || this.currentPath.startsWith(href);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
}
