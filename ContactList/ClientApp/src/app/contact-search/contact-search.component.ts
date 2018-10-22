import { Component, OnInit } from '@angular/core';
import { Preview } from '../preview';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contact-search',
  templateUrl: './contact-search.component.html',
  styleUrls: ['./contact-search.component.css']
})
export class ContactSearchComponent implements OnInit{
  contacts: Preview[];
  searching: string;
  searched: boolean;
  count: number;

  constructor(private contactService: ContactService) {  }

  ngOnInit() {
    this.searched = false;
  }

  search(): void {
    if(this.searching !== undefined && this.searching.trim())
      this.contactService.searchContacts(this.searching).subscribe(result => {
        this.contacts = result;
        this.searched = true;
        this.count = this.contacts.length;
      }, error => console.error(error));
  }

  clear(): void {
    this.contacts = [];
    this.searched = false;
    this.count = 0;
  }
}
