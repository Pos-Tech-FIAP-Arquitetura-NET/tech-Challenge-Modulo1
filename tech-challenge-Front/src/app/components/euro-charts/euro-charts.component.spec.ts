import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EuroChartsComponent } from './euro-charts.component';

describe('EuroChartsComponent', () => {
  let component: EuroChartsComponent;
  let fixture: ComponentFixture<EuroChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EuroChartsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EuroChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
