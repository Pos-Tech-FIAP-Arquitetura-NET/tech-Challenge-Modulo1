import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DolarChartsComponent } from './dolar-charts.component';

describe('DolarChartsComponent', () => {
  let component: DolarChartsComponent;
  let fixture: ComponentFixture<DolarChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DolarChartsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DolarChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
