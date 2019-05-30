import { TestBed } from '@angular/core/testing';

import { HeadListenerService } from './head-listener.service';

describe('HeadListenerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HeadListenerService = TestBed.get(HeadListenerService);
    expect(service).toBeTruthy();
  });
});
