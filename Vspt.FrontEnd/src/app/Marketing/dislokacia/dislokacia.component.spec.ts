import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DislokaciaComponent } from './dislokacia.component';

describe('DislokaciaComponent', () => {
  let component: DislokaciaComponent;
  let fixture: ComponentFixture<DislokaciaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DislokaciaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DislokaciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
