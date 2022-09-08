import { Component, OnInit } from '@angular/core';
import { Person } from 'src/models/person';
import { PersonService } from 'src/services/person.service';

@Component({
  selector: 'app-list-person',
  templateUrl: './list-person.component.html',
  styleUrls: ['./list-person.component.scss'],
})
export class ListPersonComponent implements OnInit {
  persons: Person[] = [];
  constructor(private personService: PersonService) {}

  ngOnInit(): void {
    this.getPersons();
  }

  getPersons() {
    this.personService.getPersons().subscribe({
      next: (response) => {
        this.persons = response.data;
      },
      error: (xhr) => {
        console.log(xhr);
      },
    });
  }
}
