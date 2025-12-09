import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { StatusBadgeComponent } from '../../../shared/components/status-badge/status-badge.component';
import { SeparatorComponent } from '../../../shared/components/separator/separator.component';
import { GetProcurementUseCase } from '../../../../../domain/usecases/get-procurement.usecase';
import { firstValueFrom } from 'rxjs';
import { ProcurementModel } from '../../../../../domain/models/procurement.model';

interface DocumentFile {
  id: string;
  name: string;
  size: number;
  uploadDate: string;
}

interface HistoryEntry {
  id: string;
  action: string;
  user: string;
  timestamp: string;
  changes?: { field: string; before?: string; after?: string }[];
}

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    StatusBadgeComponent,
    SeparatorComponent,
  ],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent {
  acquisitionId: string | null = null;

  showDeactivateDialog = false;
  showActivateDialog = false;

  acquisitionData: ProcurementModel | null = null;

  documents: DocumentFile[] = [
    {
      id: '1',
      name: 'Documento1.pdf',
      size: 245000,
      uploadDate: '2025-01-10',
    },
    {
      id: '2',
      name: 'Documento2.pdf',
      size: 180000,
      uploadDate: '2025-01-11',
    },
    {
      id: '3',
      name: 'Documento3.pdf',
      size: 92000,
      uploadDate: '2025-01-12',
    },
  ];

  recentHistory: HistoryEntry[] = [
    {
      id: '3',
      action: 'Actualizado',
      user: 'Laura',
      timestamp: '2025-01-25T14:30:00',
      changes: [{ field: 'Cantidad', before: '15', after: '20' }],
    },
    {
      id: '2',
      action: 'Documento subido',
      user: 'Pedro',
      timestamp: '2025-01-20T10:15:00',
    },
    {
      id: '1',
      action: 'Creado',
      user: 'Leidy',
      timestamp: '2025-01-10T11:30:00',
    },
  ];

  constructor(
    private readonly route: ActivatedRoute,
    private readonly getProcurementUseCase: GetProcurementUseCase
  ) {
    this.acquisitionId = this.route.snapshot.paramMap.get('id');
    this.getProcurement();
  }

  private getProcurement() {
    const procurment$ = this.getProcurementUseCase.execute({
      id: this.acquisitionId || '',
    });

    firstValueFrom(procurment$).then((result) => {
      this.acquisitionData = {
        ...result,
        isActive: (result as any).isActive ?? true,
        files: (result as any).files ?? [],
      };
    });
  }

  formatFileSize(bytes: number) {
    if (bytes === 0) return '0 Bytes';
    const k = 1024;
    const sizes = ['Bytes', 'KB', 'MB', 'GB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return Math.round((bytes / Math.pow(k, i)) * 100) / 100 + ' ' + sizes[i];
  }

  handleDeactivate() {
    console.log('Deactivating acquisition:', this.acquisitionData?.id);
    globalThis.alert('Acquisition deactivated');
    this.showDeactivateDialog = false;
  }

  handleActivate() {
    console.log('Activating acquisition:', this.acquisitionData?.id);
    globalThis.alert('Acquisition activated');
    this.showActivateDialog = false;
  }

  downloadDocument(docId: string) {
    console.log('Downloading document:', docId);
  }

  downloadPdf() {
    console.log('Downloading acquisition PDF:', this.acquisitionData?.id);
  }
}
