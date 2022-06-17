import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountThankYouComponent } from './account-thank-you.component';

describe('AccountThankYouComponent', () => {
  let component: AccountThankYouComponent;
  let fixture: ComponentFixture<AccountThankYouComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountThankYouComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountThankYouComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
