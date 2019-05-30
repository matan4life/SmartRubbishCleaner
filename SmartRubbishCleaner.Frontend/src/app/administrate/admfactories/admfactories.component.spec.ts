import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmfactoriesComponent } from './admfactories.component';

describe('AdmfactoriesComponent', () => {
  let component: AdmfactoriesComponent;
  let fixture: ComponentFixture<AdmfactoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmfactoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmfactoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
