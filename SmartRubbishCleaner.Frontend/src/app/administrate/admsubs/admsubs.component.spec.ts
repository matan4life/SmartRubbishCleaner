import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmsubsComponent } from './admsubs.component';

describe('AdmsubsComponent', () => {
  let component: AdmsubsComponent;
  let fixture: ComponentFixture<AdmsubsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmsubsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmsubsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
