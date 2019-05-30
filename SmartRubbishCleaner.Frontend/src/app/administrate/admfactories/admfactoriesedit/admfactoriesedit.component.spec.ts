import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmfactorieseditComponent } from './admfactoriesedit.component';

describe('AdmfactorieseditComponent', () => {
  let component: AdmfactorieseditComponent;
  let fixture: ComponentFixture<AdmfactorieseditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmfactorieseditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmfactorieseditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
