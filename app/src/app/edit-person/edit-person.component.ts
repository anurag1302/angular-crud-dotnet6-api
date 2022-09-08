import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/models/person';
import { PersonService } from 'src/services/person.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.scss'],
})
export class EditPersonComponent implements OnInit {
  existingPerson: Person = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    email: '',
    phone: '',
    address: '',
    postalZip: '',
    country: '',
  };
  constructor(
    private routeMap: ActivatedRoute,
    private personService: PersonService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.routeMap.paramMap.subscribe({
      next: (response) => {
        const id = response.get('id');
        if (id) {
          this.personService.getPersonById(id).subscribe({
            next: (response) => {
              this.existingPerson = response.data;
            },
            error: (xhr) => {
              console.log(xhr);
            },
          });
        }
      },
      error: (xhr) => {
        console.log(xhr);
      },
    });
  }

  editAPerson() {
    this.personService.editAPerson(this.existingPerson).subscribe({
      next: (response) => {
        this.router.navigate(['list']);
      },
      error: (xhr) => {
        console.log(xhr);
      },
    });
  }

  deletePerson(id: string) {
    this.personService.deleteAPerson(id).subscribe({
      next: (response) => {
        this.router.navigate(['list']);
      },
      error: (xhr) => {
        console.log(xhr);
      },
    });
  }
}
