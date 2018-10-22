import { Component, OnInit } from '@angular/core';
import { Preview } from '../preview';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public contacts: Preview[];
  public count: number;

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.getContacts();
  }

  getContacts(): void {
    this.contactService.getContacts().subscribe(result => { this.contacts = result; this.count = result.length });
  }

  trackByFn(index: any, item: any) {
    return index;
  }

  delete(id: string, index: number, $event): void {
    this.contactService.deleteContact(id).subscribe(l => { });
    this.contacts.splice(index, 1);
    $event.stopPropagation();
  }
}
