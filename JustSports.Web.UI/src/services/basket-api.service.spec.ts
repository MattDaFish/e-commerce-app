import { TestBed } from '@angular/core/testing';

import { BasketApiService } from './basket-api.service';

describe('BasketApiService', () => {
  let service: BasketApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BasketApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
