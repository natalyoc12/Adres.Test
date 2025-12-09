import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProcurementComponent } from './procurement.component';
import { ChangeDetectorRef } from '@angular/core';
import { GetProcurementsUseCase } from '../../../../domain/usecases/get-procurements.usecase';

describe('ProcurementComponent', () => {
  let component: ProcurementComponent;
  let fixture: ComponentFixture<ProcurementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProcurementComponent],
      providers: [
        { provide: ChangeDetectorRef, useValue: { detectChanges: () => {} } },
        { provide: GetProcurementsUseCase, useValue: { execute: () => {} } },
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(ProcurementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
