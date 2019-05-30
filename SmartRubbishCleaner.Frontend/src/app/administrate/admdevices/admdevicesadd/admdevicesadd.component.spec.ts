import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmdevicesaddComponent } from './admdevicesadd.component';

describe('AdmdevicesaddComponent', () => {
  let component: AdmdevicesaddComponent;
  let fixture: ComponentFixture<AdmdevicesaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmdevicesaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmdevicesaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
