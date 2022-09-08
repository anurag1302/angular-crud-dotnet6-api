import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/models/person';
import { PersonService } from 'src/services/person.service';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.scss'],
})
export class CreatePersonComponent implements OnInit {
  addPersonRequest: Person = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    email: '',
    phone: '',
    address: '',
    postalZip: '',
    country: '',
  };

  constructor(private personService: PersonService, private router: Router) {}

  ngOnInit(): void {}

  addAPerson() {
    this.personService.addAPerson(this.addPersonRequest).subscribe({
      next: (response) => {
        this.router.navigate(['list']);
      },
      error: (xhr) => {
        console.log(xhr);
      },
    });
  }
}
