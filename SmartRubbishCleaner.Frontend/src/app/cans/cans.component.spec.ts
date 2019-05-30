import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CansComponent } from './cans.component';

describe('CansComponent', () => {
  let component: CansComponent;
  let fixture: ComponentFixture<CansComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CansComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
