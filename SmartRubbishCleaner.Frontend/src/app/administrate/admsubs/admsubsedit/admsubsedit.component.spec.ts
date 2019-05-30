import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmsubseditComponent } from './admsubsedit.component';

describe('AdmsubseditComponent', () => {
  let component: AdmsubseditComponent;
  let fixture: ComponentFixture<AdmsubseditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmsubseditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmsubseditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
