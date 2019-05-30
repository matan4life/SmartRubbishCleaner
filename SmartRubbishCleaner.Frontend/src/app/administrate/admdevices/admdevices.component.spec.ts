import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmdevicesComponent } from './admdevices.component';

describe('AdmdevicesComponent', () => {
  let component: AdmdevicesComponent;
  let fixture: ComponentFixture<AdmdevicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmdevicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmdevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
