import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyReportingPlansDetailsComponent } from './daily-reporting-plans-details.component';

describe('DailyReportingPlansDetailsComponent', () => {
  let component: DailyReportingPlansDetailsComponent;
  let fixture: ComponentFixture<DailyReportingPlansDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DailyReportingPlansDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyReportingPlansDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
