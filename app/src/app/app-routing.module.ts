import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePersonComponent } from './create-person/create-person.component';
import { EditPersonComponent } from './edit-person/edit-person.component';
import { HomeComponent } from './home/home.component';
import { ListPersonComponent } from './list-person/list-person.component';

const routes: Routes = [
  {
    path: 'list',
    component: ListPersonComponent,
  },
  {
    path: 'edit/:id',
    component: EditPersonComponent,
  },
  {
    path: 'create',
    component: CreatePersonComponent,
  },
  {
    path: '',
    component: HomeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
