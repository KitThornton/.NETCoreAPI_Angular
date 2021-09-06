export interface IPatient {
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
}
