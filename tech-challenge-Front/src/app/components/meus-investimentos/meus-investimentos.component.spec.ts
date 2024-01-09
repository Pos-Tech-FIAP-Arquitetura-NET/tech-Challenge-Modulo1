import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeusInvestimentosComponent } from './meus-investimentos.component';

describe('MeusInvestimentosComponent', () => {
  let component: MeusInvestimentosComponent;
  let fixture: ComponentFixture<MeusInvestimentosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MeusInvestimentosComponent]
    });
    fixture = TestBed.createComponent(MeusInvestimentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
