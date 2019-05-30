import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmsubsaddComponent } from './admsubsadd.component';

describe('AdmsubsaddComponent', () => {
  let component: AdmsubsaddComponent;
  let fixture: ComponentFixture<AdmsubsaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmsubsaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmsubsaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
