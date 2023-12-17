import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FecthDataComponent } from './fecth-data.component';

describe('FecthDataComponent', () => {
  let component: FecthDataComponent;
  let fixture: ComponentFixture<FecthDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FecthDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FecthDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
