export interface ProcurementModel {
  id: string;
  budget: number;
  entity: string;
  item: string;
  quantity: number;
  unitPrice: number;
  totalPrice: number;
  date: Date;
  supplier: string;
  includeInactive?: boolean;
  createdAt: Date;
  isActive?: boolean;
  files: DocumentFile[];
}

export interface DocumentFile {
  id: string;
  name: string;
  size: number;
  uploadDate: Date;
}
