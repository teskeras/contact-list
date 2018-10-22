import { Component, OnInit } from '@angular/core';
import { Details } from '../details';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent implements OnInit {
  public details: Details;
  public phoneMessage: string;
  public emailMessage: string;

  constructor(private location: Location, public router: Router, private contactService: ContactService) {  }

  ngOnInit() {
    this.details = new Details;
  }

  trackByFn(index: any, item: any) {
    return index;
  }

  goBack(): void {
    this.location.back();
  }

  addPhone(): void {
    this.details.phones.push({ id: 0, number: "", contactId: this.details.id });
  }

  deletePhone(index: number): void {
    this.details.phones.splice(index, 1);
  }

  addEmail(): void {
    this.details.emails.push({ id: 0, address: "", contactId: this.details.id });
  }

  deleteEmail(index: number): void {
    this.details.emails.splice(index, 1);
  }

  addTag(): void {
    this.details.tags.push({ id: 0, title: "", contactId: this.details.id });
  }

  deleteTag(index: number): void {
    this.details.tags.splice(index, 1);
  }

  addContact(): void {
    if (this.details.phones.length && !this.details.phones.every(hasOnlyDigits))
      this.phoneMessage = "Phone numbers consist of only numbers and cannot be empty";
    else this.phoneMessage = "";
    if (this.details.emails.length && !this.details.emails.every(isEmail))
      this.emailMessage = 'Email addresses look like "email@address.example" and cannot be empty';
    else this.emailMessage = "";
    if (this.phoneMessage == "" && this.emailMessage == "")
      this.contactService.addContact(this.details).subscribe(i => { this.router.navigateByUrl("contact/" + i); });
  }
}
  function hasOnlyDigits(value) {
    return /^\d+$/.test(value.number);
}

  function isEmail(value) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(value.address).toLowerCase());
}
