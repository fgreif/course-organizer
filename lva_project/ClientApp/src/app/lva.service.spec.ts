import { TestBed } from '@angular/core/testing';

import { LvaService } from './lva.service';

describe('LvaService', () => {
  let service: LvaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LvaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
