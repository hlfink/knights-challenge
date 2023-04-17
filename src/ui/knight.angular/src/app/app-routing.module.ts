import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchComponent } from './components/search/search.component';
import { NewComponent } from './components/new/new.component'

const routes: Routes = [
  { path: 'search/:heroes', component: SearchComponent },
  { path: 'new', component: NewComponent },
  { path: 'search', component: SearchComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
