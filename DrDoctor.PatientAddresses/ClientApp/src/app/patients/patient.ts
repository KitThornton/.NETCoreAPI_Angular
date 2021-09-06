import { IPatient } from "./ipatient";

export class Patient implements IPatient {

  constructor(person: IPatient) {
    this.id = person.id;
    this.firstName = person.firstName;
    this.lastName = person.lastName;
    this.gender = person.gender;
    this.nhsNumber = person.nhsNumber;
    this.hospitalNumber = person.hospitalNumber;
    this.dateOfBirth = person.dateOfBirth;
    this.dateOfDeath = person.dateOfDeath;
    this.addressLine1 = person.addressLine1;
    this.addressLine2 = person.addressLine2;
    this.addressLine3 = person.addressLine3;
    this.addressLine4 = person.addressLine4;
    this.postCode = person.postCode;
  }

  id: number;
  firstName: string;
  lastName: string;
  gender: string;
  nhsNumber: string;
  hospitalNumber: string;
  dateOfBirth: Date;
  dateOfDeath?: Date;
  addressLine1: string;
  addressLine2: string;
  addressLine3: string;
  addressLine4: string;
  postCode: string;

  get fullName(): string {
    return `${this.firstName} ${this.lastName}`;
  }

  get getFormattedAddress(): string {
    // TODO: Step 4
    //
    // Implement the getFormattedAddress function.

    // Each "addressLine" should be separated by a newline,
    // followed by the "postCode" on the final line.
    // 
    // For example:
    //
    // {
    //    addressLine1: '221b Baker St',
    //    addressLine2: 'Marylebone  ',
    //    addressLine3: '',
    //    addressLine4: '      London',
    //    postCode: 'NW1 6XE'
    // }
    //
    // would become
    //
    // 221b Baker St
    // Marylebone
    // London
    // NW1 6XE
    //

    return "TODO: Step 4";
  }

  get isPalindrome(): boolean {

    // TODO: Step 5
    //
    // Implement the isPalindrome function.

    // The function should return true when fullName is spelled the same
    // forwards as it is backwards.

    // The function should ignore any spaces and should also be case insensitive.
    //
    // for example: 'Bo Bob' is a palindrome as 'bobob' === 'bobob'

    return false;
  }
}

