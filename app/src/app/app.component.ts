import { Component, OnInit } from '@angular/core';
import { Person } from 'src/models/person';
import { PersonService } from 'src/services/person.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Persons App';
  persons: Person[] = [];

  constructor(private personService: PersonService) {}

  ngOnInit(): void {
    this.getPersons();
  }

  getPersons() {
    this.personService.getEmployees().subscribe((response) => {
      this.persons = response.data;
    });
  }
}
