import { Phone } from "./Phone";
import { Email } from "./email";
import { Tag } from "./tag";

export class Details {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  jobTitle: string;
  phones: Phone[];
  emails: Email[];
  tags: Tag[];

  constructor() {
    this.id = 0;
    this.firstName = "";
    this.lastName = "";
    this.address = "";
    this.jobTitle = "";
    this.phones = [];
    this.emails = [];
    this.tags = [];
  }
}
