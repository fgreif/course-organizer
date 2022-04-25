import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LvaViewComponent } from './lva-view.component';

describe('LvaViewComponent', () => {
  let component: LvaViewComponent;
  let fixture: ComponentFixture<LvaViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LvaViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LvaViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
