import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LvaListViewComponent } from './lva-list-view.component';

describe('LvaListViewComponent', () => {
  let component: LvaListViewComponent;
  let fixture: ComponentFixture<LvaListViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LvaListViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LvaListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
