import { TestBed } from '@angular/core/testing';

import { BoundService } from './bound.service';

describe('BoundService', () => {
  let service: BoundService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BoundService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
