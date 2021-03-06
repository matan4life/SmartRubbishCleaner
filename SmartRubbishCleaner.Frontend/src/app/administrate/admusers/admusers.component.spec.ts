import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmusersComponent } from './admusers.component';

describe('AdmusersComponent', () => {
  let component: AdmusersComponent;
  let fixture: ComponentFixture<AdmusersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdmusersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
