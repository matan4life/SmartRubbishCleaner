import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmdeviceseditComponent } from './admdevicesedit.component';

describe('AdmdeviceseditComponent', () => {
  let component: AdmdeviceseditComponent;
  let fixture: ComponentFixture<AdmdeviceseditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmdeviceseditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmdeviceseditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
