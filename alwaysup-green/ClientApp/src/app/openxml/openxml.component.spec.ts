import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenxmlComponent } from './openxml.component';

describe('OpenxmlComponent', () => {
  let component: OpenxmlComponent;
  let fixture: ComponentFixture<OpenxmlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenxmlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenxmlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
