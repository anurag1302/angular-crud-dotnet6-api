export interface Person {
  id: string;
  name: string;
  phone: string;
  email: string;
  address: string;
  postalZip: string;
  country: string;
}

export interface ApiResponseCollection {
  data: Person[];
  isSuccess: boolean;
  statusCode: number;
  message: string;
  errors?: any;
}

export interface ApiResponse {
  data: Person;
  isSuccess: boolean;
  statusCode: number;
  message: string;
  errors?: any;
}
