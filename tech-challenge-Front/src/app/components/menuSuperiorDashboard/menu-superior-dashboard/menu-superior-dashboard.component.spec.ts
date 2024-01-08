import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuSuperiorDashboardComponent } from './menu-superior-dashboard.component';

describe('MenuSuperiorDashboardComponent', () => {
  let component: MenuSuperiorDashboardComponent;
  let fixture: ComponentFixture<MenuSuperiorDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MenuSuperiorDashboardComponent]
    });
    fixture = TestBed.createComponent(MenuSuperiorDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
