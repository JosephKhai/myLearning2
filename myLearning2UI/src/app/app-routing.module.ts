import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { FecthDataComponent } from "./fecth-data/fecth-data.component";

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full'},
    { path: 'fetch-data', component:FecthDataComponent}
]

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]

})

export class AppRoutingModule{}