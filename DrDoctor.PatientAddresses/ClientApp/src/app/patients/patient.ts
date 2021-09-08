import {IPatient} from "./ipatient";

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
    // Initialise array of address lines
    let addressLines = [];

    // For each line, trim leading & trailing white spaces and add to array
    // Ignore if undefined. Shorthand if statements to be concise, easily readable
    if ( this.addressLine1 ) { addressLines.push(this.addressLine1.trim()) }
    if ( this.addressLine2 ) { addressLines.push(this.addressLine2.trim()) }
    if ( this.addressLine3 ) { addressLines.push(this.addressLine3.trim()) }
    if ( this.addressLine4 ) { addressLines.push(this.addressLine4.trim()) }
    if ( this.postCode ) { addressLines.push(this.postCode.trim()) }

    // For each sanitised and non-null address line, append and add new line
    let formattedAddress = "";
    addressLines.map(e => formattedAddress += e + "\n");

    return formattedAddress;
  }

  get isPalindrome(): boolean {

    // TODO: Step 5
    // Firstly, remove all white space in name and set to lower case for comparison
    const fullName = this.fullName.replace(/ /g, "").toLowerCase();

    // Reverse the name by creating a string array, reversing it and re-joining to form a string
    const reverse = fullName.split('').reverse().join('');

    // Compare backward and forward solutions
    return fullName === reverse;
  }
}
