import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestimentComponent } from './investiment.component';

describe('InvestimentComponent', () => {
  let component: InvestimentComponent;
  let fixture: ComponentFixture<InvestimentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvestimentComponent]
    });
    fixture = TestBed.createComponent(InvestimentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
