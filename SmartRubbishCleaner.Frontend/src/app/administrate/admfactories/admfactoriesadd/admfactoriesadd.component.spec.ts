import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmfactoriesaddComponent } from './admfactoriesadd.component';

describe('AdmfactoriesaddComponent', () => {
  let component: AdmfactoriesaddComponent;
  let fixture: ComponentFixture<AdmfactoriesaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmfactoriesaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmfactoriesaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
