import { Inject } from '@angular/core';
import { Details } from './details';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Preview } from './preview';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class ContactService {
  constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

  getContacts(): Observable<Preview[]> {
    return this.http.get<Preview[]>(this.baseUrl + 'api/contactlist/GetList');
  }

  getContact(id: string): Observable<Details> {
    return this.http.get<Details>(this.baseUrl + 'api/ContactList/GetContact/' + id);
  }

  editContact (id: string, contact: Details): Observable<Details> {
    return this.http.put<Details>(this.baseUrl + 'api/ContactList/EditContact/' + id, contact);
  }

  addContact (contact: Details,): Observable<Details> {
    return this.http.post<Details>(this.baseUrl + 'api/ContactList/CreateContact', contact, httpOptions);
  }
  
  deleteContact (id: string): Observable<Object> {
    return this.http.delete(this.baseUrl + "api/ContactList/DeleteContact/" + id);
  }

  searchContacts(searching: string): Observable<Details[]> {
    return this.http.get<Details[]>(this.baseUrl + "api/ContactList/Search/" + searching);
  }
}
