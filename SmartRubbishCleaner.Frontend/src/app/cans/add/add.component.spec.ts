import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Add1Component } from './add.component';

describe('Add1Component', () => {
  let component: Add1Component;
  let fixture: ComponentFixture<Add1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Add1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Add1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
