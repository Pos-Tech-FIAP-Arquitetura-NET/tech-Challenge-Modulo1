import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalInvestirComponent } from './modal-investir.component';

describe('ModalInvestirComponent', () => {
  let component: ModalInvestirComponent;
  let fixture: ComponentFixture<ModalInvestirComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalInvestirComponent]
    });
    fixture = TestBed.createComponent(ModalInvestirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
