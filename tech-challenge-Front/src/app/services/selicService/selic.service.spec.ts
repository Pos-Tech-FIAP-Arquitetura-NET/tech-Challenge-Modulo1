import { TestBed } from '@angular/core/testing';

import { SelicService } from './selic.service';

describe('SelicService', () => {
  let service: SelicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SelicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
