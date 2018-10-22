import { Component, OnInit } from '@angular/core';
import { Details } from '../details';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent implements  OnInit{
  public contact: Details;
  private id: string;
  public phoneMessage: string;
  public emailMessage: string;
  public saveMessage: string;

  constructor(public location: Location, private route: ActivatedRoute, private contactService: ContactService, public router: Router) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getContact();
  }

  getContact(): void {
    this.contactService.getContact(this.id).subscribe(result => { this.contact = result });
  }

  trackByFn(index: any, item: any) {
    return index;
  }

  goBack(): void {
    this.location.back();
  }

  addPhone(): void {
    this.contact.phones.push({id: 0, number: "", contactId: this.contact.id});
  }

  deletePhone(index: number): void {
    this.contact.phones.splice(index, 1);
  }

  addEmail(): void {
    this.contact.emails.push({ id: 0, address: "", contactId: this.contact.id });
  }

  deleteEmail(index: number): void {
    this.contact.emails.splice(index, 1);
  }

  addTag(): void {
    this.contact.tags.push({ id: 0, title: "", contactId: this.contact.id });
  }

  deleteTag(index: number): void {
    this.contact.tags.splice(index, 1);
  }

  delete(): void {
    this.contactService.deleteContact(this.id).subscribe(l => { this.router.navigateByUrl(""); });
  }

  save(): void {
    this.saveMessage = "Contact failed to edit";
    if (this.contact.phones.length && !this.contact.phones.every(hasOnlyDigits))
      this.phoneMessage = "Phone numbers consist of only numbers and cannot be empty";
    else this.phoneMessage = "";
    if (this.contact.emails.length && !this.contact.emails.every(isEmail))
      this.emailMessage = 'Email addresses look like "email@address.example" and cannot be empty';
    else this.emailMessage = "";
    if (this.phoneMessage == "" && this.emailMessage == "")
      this.contactService.editContact(this.id, this.contact).subscribe(l => { this.saveMessage = "Contact successfully edited" });
  }
}

function hasOnlyDigits(value) {
  return /^\d+$/.test(value.number);
}

function isEmail(value) {
  var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(String(value.address).toLowerCase());
}
