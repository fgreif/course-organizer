import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LvaListViewComponent } from './lva-list-view/lva-list-view.component';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotesComponent } from './notes/notes.component';
import { LvaTableAllComponent } from './lva-table-all/lva-table-all.component';
import { LvaCreateFormComponent } from './lva-create-form/lva-create-form.component';

const routes = [
  { path: 'home', component: HomeComponent, pathMatch: 'full' },
  { path: 'erstellen', component: LvaCreateFormComponent},
  { path:'kursliste', component: LvaTableAllComponent},
  { path: 'statistiken', component: DashboardComponent},
  { path: 'notizen', component: NotesComponent},
  // { path: 'overview', component: }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})
export class AppRoutingModule { }
